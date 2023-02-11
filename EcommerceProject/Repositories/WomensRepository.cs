using EcommerceProject.Data;
using EcommerceProject.Interface;
using EcommerceProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace EcommerceProject.Repositories
{
    public class WomensRepository : IWomensRepository
    {
        private readonly AppDbContext _context;

        public WomensRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(WomensClothing womens)
        {
            _context.Womens.Add(womens);
            return Save();

        }

        public bool Delete(WomensClothing womens)
        {
            _context.Womens.Remove(womens);
            return Save();
        }

        public async Task<IEnumerable<WomensClothing>> GetAll()
        {
            var womens =  _context.Womens.ToListAsync();
            return await womens;
        }

        public async Task<WomensClothing> GetByIdAsync(int id)
        {
              var Womens = _context.Womens.FirstOrDefaultAsync(w => w.Id == id);
              return await Womens;
        }

        public async Task<WomensClothing> GetByIdAsyncNoTracking(int id)
        {
            var women = _context.Womens.AsNoTracking().FirstOrDefaultAsync(w => w.Id == id);
            return await women;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(WomensClothing womens)
        {
            _context.Womens.Update(womens);
            return Save();
        }
    }
}
