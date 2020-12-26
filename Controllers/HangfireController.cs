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

        [HttpPost]
        [Route("[action]")]
        public IActionResult Discount()
        {
            int delayInSeconds = 30;

            var jobID = BackgroundJob.Schedule(() => SendWelcomeEmail("Discount aplied"), TimeSpan.FromSeconds(delayInSeconds));

            return Ok($"JobId: {jobID}, Discound email will be sent after {delayInSeconds}  to user!");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult DatabaseUpdate()
        {
            RecurringJob.AddOrUpdate(() =>  Console.WriteLine("Database updated"), Cron.Minutely);
            
            return Ok($"Database check job initiated");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Confirm()
        {
            int delayInSeconds = 30;

            var parentJobId = BackgroundJob.Schedule(() => SendWelcomeEmail("You asked to unsubscribe"), TimeSpan.FromSeconds(delayInSeconds));

            BackgroundJob.ContinueJobWith(parentJobId, () => Console.WriteLine("You were unsubscribed"));
            return Ok("Confirmation job created");
        }


        public void SendWelcomeEmail(string text)
        {
            Console.WriteLine(text);
        }
  
    }
}
