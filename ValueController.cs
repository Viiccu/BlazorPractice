using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ValueController : ControllerBase
{
    [HttpGet("getValues")]
    [Authorize]
    public IActionResult GetValues()
    {
        return Ok(new string[] { "good job", "you're authorized" });
    }
}