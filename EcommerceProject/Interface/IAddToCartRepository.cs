using EcommerceProject.ViewModels;

namespace EcommerceProject.Interface
{
    public interface IAddToCartRepository
    {
        Task<bool> Add(Guid id);
        Task<List<AddToCartViewModel>> GetProducts();
        Task<bool> Delete(Guid id);
    }
}
