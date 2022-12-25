
using Microsoft.AspNetCore.Mvc;

namespace LinkShorteningService.Models
{
    public class LinkStorageServiceModel
    {
        public Uri Url { get; set; } 
        public FileContentResult BarCode { get; set; }
    }
}
