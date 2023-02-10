using EcommerceProject.Models;

namespace EcommerceProject.Interface
{
	public interface IMensRepository
	{
		Task<IEnumerable<MensClothing>> GetAll();

		Task<MensClothing> GetByIdAsync(int id);
		Task<MensClothing> GetByIdAsyncNoTracking(int id);
		bool Add(MensClothing mens);
		bool Update(MensClothing mens);

		bool Delete(MensClothing mens);

		bool Save();
	}
}
