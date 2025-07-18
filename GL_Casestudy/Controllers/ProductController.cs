using GL_Casestudy.DAL;
using GL_Casestudy.DAL.DAO;
using GL_Casestudy.DAL.DomainClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GL_Casestudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        readonly AppDbContext _ctx;

        public ProductController(AppDbContext context)
        {
            _ctx = context;
        }

        [HttpGet]
        [Route("{catid}")]
        public async Task<ActionResult<List<Product>>> Index(int catid)
        {
            ProductDAO dao = new(_ctx!);
            List<Product> itemsForCategory = await dao.GetAllByBrand(catid);
            return itemsForCategory;
        }
    }
}
