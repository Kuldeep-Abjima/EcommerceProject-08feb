using EcommerceProject.Models;

namespace EcommerceProject.Interface
{
    public interface IAppUserRepository
    {
        Task<AppUsers> GetUsersById(string id);
    }
}
