using EcommerceProject.Models;

namespace EcommerceProject.Interface
{
    public interface IWomensRepository
    {
        Task<IEnumerable<WomensClothing>> GetAll();

        Task<WomensClothing> GetByIdAsync(int id);
        Task<WomensClothing> GetByIdAsyncNoTracking(int id);
        bool Add(WomensClothing womens);
        bool Update(WomensClothing womens);

        bool Delete(WomensClothing womens);

        bool Save();
    }
}
