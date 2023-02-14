using EcommerceProject.Models;

namespace EcommerceProject.Interface
{
	public interface IMensRepository
	{
		Task<IEnumerable<MensClothing>> GetAll();

		Task<MensClothing> GetByIdAsync(int id);
		Task<MensClothing> GetByIdAsyncNoTracking(int id);

        Task<MensClothing> GetByGuid(Guid id);

        bool Add(MensClothing mens);
		bool Update(MensClothing mens);

		bool Delete(MensClothing mens);

		bool Save();
	}
}
