
using Aspose.BarCode.Generation;
using Force.Crc32;
using Repository.Interface.Repositoryes;
using Servises.Interface;
using System.Drawing.Imaging;

using System.Text;


using System;
using System.Drawing;
using System.IO;
//using Microsoft.AspNetCore.Mvc;


namespace Servises;

public class ServiseLinkStorage : IServiseLinkStorage
{

    private readonly IRepositoryLinkStorage _repo;

    public ServiseLinkStorage(IRepositoryLinkStorage repo) => _repo = repo;
    
    public async Task<string> CreateShortToken(Uri uri)
    {
        var url = uri.ToString();
        var crc32 = $"{Crc32CAlgorithm.Compute(Encoding.ASCII.GetBytes(url)):X}";
        var models = await _repo.GetModelsAsync(e => e.LinkKey.Equals(crc32));

        if (models.Count.Equals(0))
        {
            await _repo.SaveAsync(new()
            {
                LinkKey = crc32,
                LinkValue = url
            });
        }
        //PhysicalFile
        return crc32;
    }

    public byte[] GenerateBarcodeForUrl(Uri uri)
    {
        using var generator = new BarcodeGenerator(EncodeTypes.QR, uri.ToString());
        generator.Parameters.Resolution = 400;

        return (byte[])new ImageConverter().ConvertTo(generator.GenerateBarCodeImage(), typeof(byte[]));
    }

    public async Task<byte[]> GenerateBarcodeForUrlAsync(Uri uri) => await Task.Run(() => GenerateBarcodeForUrl(uri));

    public async Task<Uri> RegistrationNewUrlAsync(Uri uri, string baseUrl) => CreateShortUri(await CreateShortToken(uri), baseUrl);
    private static Uri CreateShortUri(string kyeUri, string bseUrl )
    {
        if (!Uri.TryCreate(new Uri(bseUrl), kyeUri, out Uri newUri))
        {
            // TODO: Add text error
            throw new Exception();
        }
        return newUri;
    }

}
