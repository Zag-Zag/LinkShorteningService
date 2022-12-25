using Microsoft.AspNetCore.Mvc;

namespace LinkShorteningService.Controllers.Base;

public abstract class AbstractController : ControllerBase
{
    protected IActionResult ExecuteAnAction(Func<IActionResult> func)
    {
        try
        {
            return Ok(func());
        }
        catch (Exception ex)
        {
            return WebExeption(ex);
        }
    }

    protected async Task<IActionResult> ExecuteAnActionAsync(Func<IActionResult> func)
    {
        try
        {
            return Ok(await Task.Run(() => func()));
        }
        catch (Exception ex)
        {
            return WebExeption(ex);
        }
    }

    protected async Task<IActionResult> ExecuteAnActionAsync(Func<Task<IActionResult>> func)
    {
        try
        {
            return Ok(await func());
        }
        catch (Exception ex)
        {
            return WebExeption(ex);
        }
    }
    private IActionResult WebExeption(Exception ex) => StatusCode(500, ex.ToString());
}
