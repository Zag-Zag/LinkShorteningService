
using LinkShorteningService.Controllers.Base;
using LinkShorteningService.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Servises.Interface;

namespace LinkStorageController.Controllers;

[ApiController]
[Route("[controller]")]
public class LinkStorageController : AbstractController
{
    private readonly IServiseLinkStorage _servise;
    public LinkStorageController(IServiseLinkStorage servise)
    {
        _servise = servise;
    }

    [HttpPost]
    [Route("CreateShortLink")]
    public async Task<IActionResult> CreateShortLink(Uri url) => await ExecuteAnActionAsync(async () =>
    {
        var sjortUri = await _servise.RegistrationNewUrlAsync(url);
        return Ok(new LinkStorageServiceModel()
        {
            Url = sjortUri,
            BarCode = await Task.Run(async () => File(await _servise.GenerateBarcodeForUrlAsync(sjortUri), "image/jpg"))
        });
    }); 
}