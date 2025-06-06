using GL_Casestudy.DAL.DomainClasses;
using Microsoft.EntityFrameworkCore;

namespace GL_Casestudy.DAL.DAO
{
    public class BrandDAO
    {
        private readonly AppDbContext _db;

        public BrandDAO(AppDbContext ctx)
        {
            _db = ctx;
        }

        public async Task<List<Brand>> GetAll()
        {
            return await _db.Brands!.ToListAsync();
        }
    }
}
