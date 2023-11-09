using Microsoft.AspNetCore.Mvc;
using System;

namespace recipes_api.Controllers;

[ApiController]
[Route("license")]
[ApiExplorerSettings(IgnoreApi = true)]
public class LicenseController : ControllerBase
{

    [HttpGet("mit")]
    public IActionResult Get()
    {
        string locationPath = Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().Location
        );
        string licenseFilePath = Path.Combine(locationPath, "../../../LICENSE");
        StreamReader sr = new(licenseFilePath);
        var content = sr.ReadToEnd();
        return Ok(content);
    }
}
