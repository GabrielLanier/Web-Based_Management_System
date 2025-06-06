using GL_Casestudy.DAL;
using GL_Casestudy.DAL.DAO;
using GL_Casestudy.DAL.DomainClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GL_Casestudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        readonly AppDbContext _ctx;

        public BrandController(AppDbContext context)
        {
            _ctx = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Brand>>> Index()
        {
            BrandDAO dao = new(_ctx!);
            List<Brand> allCategories = await dao.GetAll();
            return allCategories;
        }
    }
    
}
