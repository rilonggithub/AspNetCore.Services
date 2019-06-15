using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [Route("[Controller]")]
    public class HealthCheckController : Controller
    {
        public HealthCheckController()
        {
        }

        [HttpGet("")]
        [HttpHead("")]
        public IActionResult Check()
        {
            return Ok("OK");
        }
    }
}