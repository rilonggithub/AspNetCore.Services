using System;
using Microsoft.AspNetCore.Mvc;

namespace CatagoryService.Controllers
{
    [Route("[Controller]")]
    public class HealthCheckController:Controller
    {
        public HealthCheckController()
        {
        }
        [HttpGet("")]
        public IActionResult Check() => Ok("OK");
    }
}
