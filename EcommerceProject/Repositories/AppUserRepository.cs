using EcommerceProject.Data;
using EcommerceProject.Interface;
using EcommerceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly AppDbContext _context;

        public AppUserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<AppUsers> GetUsersById(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }
    }
}
