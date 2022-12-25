
using Azure.Core;
using LinkShorteningService.Extension;
using LinkShorteningService.Models;
using Microsoft.AspNetCore.Mvc;
using Servises.Interface;

namespace LinkShorteningService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinkStorageController : ControllerBase
    {
        private readonly IServiseLinkStorage _servise;
        public LinkStorageController(IServiseLinkStorage servise)
        {
            _servise = servise;
        }

        [HttpPost]
        [Route("CreateShortLink")]
        public async Task<IActionResult> CreateShortLink(Uri url)
        {
            var sjortUri = await _servise.RegistrationNewUrlAsync(url, Request.BaseUrl());
            return Ok(new LinkStorageServiceModel()
            {
                Url = sjortUri,
                BarCode = File(await _servise.GenerateBarcodeForUrlAsync(sjortUri), "img/jpg")
            });
        }
    }
}