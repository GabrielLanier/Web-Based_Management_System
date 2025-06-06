using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GL_Casestudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Index()
        {
            return "This is the home page";
        }
    }
}
