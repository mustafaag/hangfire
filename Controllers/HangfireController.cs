using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hangfire_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangfireController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from hangfire Api");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Welcome()
        {
            var jobId= BackgroundJob.Enqueue(() => SendWelcomeEmail("Welcome to our app!"));

            return Ok( $"JobId: {jobId}, Welcome email send to user!");
        }


        public void SendWelcomeEmail(string text)
        {
            Console.WriteLine(text);
        }
  
    }
}
