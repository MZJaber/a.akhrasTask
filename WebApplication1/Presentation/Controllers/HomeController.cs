using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Presentation.Controllers
{
    [ApiController]
    [Route("errors")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error()
        {
            throw new NotImplementedException();
        }
    }
}
