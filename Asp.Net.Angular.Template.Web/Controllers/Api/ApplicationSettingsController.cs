using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net.Angular.Template.Service.ApplicationConfiguration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Asp.Net.Angular.Template.Web.Controllers.Api
{
  [Route("api/[controller]")]
  [ApiController]
  public class ApplicationSettingsController : ControllerBase
  {

    private readonly GlobalSettings applicationSettings;
    public ApplicationSettingsController(IOptionsMonitor<GlobalSettings> optionsMonitor)
    {
      applicationSettings = optionsMonitor.CurrentValue;
    }

    [HttpGet]
    public IActionResult GetApplicationSettings()
    {
      return Ok(applicationSettings);
    }
  }
}
