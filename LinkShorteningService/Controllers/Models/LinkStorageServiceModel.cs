using Microsoft.AspNetCore.Mvc;

namespace LinkShorteningService.Controllers.Models;

public class LinkStorageServiceModel
{
    public Uri Url { get; set; }
    public FileContentResult BarCode { get; set; }
}
