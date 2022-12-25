using Microsoft.AspNetCore.Mvc;

namespace LinkShorteningService.Controllers.Models;

internal class LinkStorageServiceModel
{
    public Uri Url { get; set; }
    public FileContentResult BarCode { get; set; }
}
