using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hangfire_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HangfireController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from hangfire Api");
        }
  
    }
}
