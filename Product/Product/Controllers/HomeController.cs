using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandlingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            throw new Exception("Exception in HomeController.");
        }
    }
}