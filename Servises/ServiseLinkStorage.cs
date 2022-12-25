
using Aspose.BarCode.Generation;
using Force.Crc32;
using Repository.Interface.Repositoryes;
using Servises.Interface;
using System.Text;
using System.Drawing;
using Microsoft.AspNetCore.Http;
using Servises.Extension;
using Microsoft.Extensions.Options;
using Servises.Options;
using System;
using System.Linq;
using DataBaseEf.Extension;

namespace Servises;

public class ServiseLinkStorage : IServiseLinkStorage
{
    private readonly IRepositoryLinkStorage _repo;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IOptions<ServiseOptions> _config;
    public ServiseLinkStorage(IRepositoryLinkStorage repo, IHttpContextAccessor httpContextAccessor, IOptions<ServiseOptions> config)
    {
        _repo = repo;
        _httpContextAccessor = httpContextAccessor;
        _config = config;
    }
    
    public async Task<string> CreateShortToken(Uri uri)
    {
        var url = uri.ToString();
        var crc32 = await GetCrc32Async(url);
        var models = await _repo.GetModelsAsync(e => e.LinkKey.Equals(crc32));

        if (models.Count.Equals(0))
        {
            await _repo.SaveAsync(new()
            {
                LinkKey = crc32,
                LinkValue = url
            });
        }
        return crc32;
    }

    private static async Task<string> GetCrc32Async(string url) => await Task.Run(() => $"{Crc32CAlgorithm.Compute(Encoding.ASCII.GetBytes(url)):X}");

    public byte[] GenerateBarcodeForUrl(Uri uri)
    {
        using var generator = new BarcodeGenerator(EncodeTypes.QR, uri.ToString());
        generator.Parameters.Resolution = _config.Value.CodeResolution;

        return (byte[])new ImageConverter().ConvertTo(generator.GenerateBarCodeImage(), typeof(byte[]));
    }

    public async Task<byte[]> GenerateBarcodeForUrlAsync(Uri uri) => await Task.Run(() => GenerateBarcodeForUrl(uri));

    public async Task<Uri> RegistrationNewUrlAsync(Uri uri) => CreateShortUri(await CreateShortToken(uri));

    private Uri CreateShortUri(string kyeUri) => Uri.TryCreate(new Uri(_httpContextAccessor.HttpContext.Request.BaseUrl()), kyeUri, out Uri newUri)
        ? newUri
        : throw new Exception(/*TODO: Add text exception*/);

    public async Task<string> GetUrlByShortKeyAsync(string shortKey)
    {
        var models = await _repo.GetModelsAsync(e => e.LinkKey.Equals(shortKey));
        if (models.Count.Equals(0))
        {
            throw new Exception(/*TODO: Add text exception*/);
        }
        return await Task.Run(() => models
            .Select(e => e.LinkValue)
            .FirstOrDefault());
    }
}
