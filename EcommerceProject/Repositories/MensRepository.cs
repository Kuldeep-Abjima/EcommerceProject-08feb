using EcommerceProject.Data;
using EcommerceProject.Interface;
using EcommerceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Repositories
{
	public class MensRepository : IMensRepository
	{
		private readonly AppDbContext _context;

		public MensRepository(AppDbContext context) 
		{
			_context = context;
		}
		public bool Add(MensClothing mens)
		{
			_context.Add(mens);
			return Save();
		}

		public bool Delete(MensClothing mens)
		{
			_context.Remove(mens);
			return Save();
		}

		public async Task<IEnumerable<MensClothing>> GetAll()
		{
			var mens = _context.Mens.ToListAsync();
			return await mens;
		}

		public async Task<MensClothing> GetByIdAsync(int id)
		{
			var men = _context.Mens.FirstOrDefaultAsync(x => x.Id == id);
			return await men;
		}

        public async Task<MensClothing> GetByGuid(Guid id)
        {
            var men = await _context.Mens.FirstOrDefaultAsync(M => M.Identifier == id);

			return men;
        }

        public async Task<MensClothing> GetByIdAsyncNoTracking(int id)
		{
			var men = _context.Mens.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
			return await men;
		}

		
		public bool Update(MensClothing mens)
		{
			 _context.Mens.Update(mens);
			return Save();
		}
		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

	}
}
