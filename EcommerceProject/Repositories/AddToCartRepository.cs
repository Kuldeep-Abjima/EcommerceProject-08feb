using EcommerceProject.Data;
using EcommerceProject.Interface;
using EcommerceProject.Models;

namespace EcommerceProject.Repositories
{
    public class AddToCartRepository : IAddToCartRepository
    {
        private readonly AppDbContext _context;
        private readonly MensRepository _mensRepository;

        public AddToCartRepository(AppDbContext context, MensRepository mensRepository)
        {
            _context = context;
            _mensRepository = mensRepository;
        }

        //public async Task<ProductAddToCart> Add(int id)
        //{
        //     var men = _mensRepository.GetByIdAsync(id);
        //     var productAtc =  new ProductAddToCart()
        //     {
        //         MensID= id,
        //         Quantity = 1,

        //     }
        //}






        //public async Task<bool> Add(int id, ProductAddToCart toCartModel)
        //{
        //    var mens = await _mensRepository.GetByIdAsync(id);

        //    _context.ProductATC.Add(toCartModel);
        //    return Save();

        //}

        //public bool Delete(ProductAddToCart toCart)
        //{
        //    _context.ProductATC.Remove(toCart);
        //    return Save();
        //}
        ////public async Task<ProductAddToCart> GetId(int id)
        ////{
        ////    var mens = await _mensRepository.GetByIdAsync(id);
            
        ////}

        //    public bool Save()
        //{
        //    var Saved = _context.SaveChanges();
        //    return Saved > 0 ? true : false;
        //}
    }
}

