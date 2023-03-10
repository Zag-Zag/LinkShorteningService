
using LinkShorteningService.Controllers.Base;
using LinkShorteningService.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Servises.Interface;
using System;

namespace LinkStorageController.Controllers;
/// 
[ApiController]
[Route("api/[controller]")]
public class LinkStorageController : AbstractController
{
    private readonly IServiseLinkStorage _servise;
    /// 
    public LinkStorageController(IServiseLinkStorage servise) => _servise = servise;
    /// <summary>
    /// ?????????? ???????? url ? ??????? ? ??????? ???????????????? ????????? ?????? ? barCoda.
    /// </summary>
    [HttpPost]
    [Route("CreateShortLink")]
    public async Task<IActionResult> CreateShortLink(Uri url) => await ExecuteAnActionAsync(async () =>
    {
        var sjortUri = await _servise.RegistrationNewUrlAsync(url);
        return new LinkStorageServiceModel()
        {
            Url = sjortUri,
            BarCode = await Task.Run(async () => File(await _servise.GenerateBarcodeForUrlAsync(sjortUri), "image/jpg"))
        };
    });
}