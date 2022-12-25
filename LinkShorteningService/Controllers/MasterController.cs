using LinkShorteningService.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Servises.Interface;

namespace LinkShorteningService.Controllers;
/// 
[ApiController]
[Route("/")]
public class MasterController : AbstractController
{
    private readonly IServiseLinkStorage _servise;
    /// 
    public MasterController(IServiseLinkStorage servise) => _servise = servise;
    /// <summary>
    /// Вычисление оригинального url, на основании короткого и переадресация на страницу по адресу оригинального url.
    /// </summary>
    [HttpGet]
    [Route("/{shortKey}")]
    public async Task<IActionResult> Index(string shortKey) => 
        await ExecuteAnActionAsync(async () => await _servise.GetUrlByShortKeyAsync(shortKey), (e) => Redirect(e));
}
