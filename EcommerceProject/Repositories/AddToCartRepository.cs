using EcommerceProject.Data;
using EcommerceProject.Interface;
using EcommerceProject.Models;
using EcommerceProject.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace EcommerceProject.Repositories
{
    public class AddToCartRepository : IAddToCartRepository
    {
        private readonly AppDbContext _context;
        private readonly IMensRepository _mensRepository;
        private readonly IWomensRepository _womensRepository;

        public AddToCartRepository(AppDbContext context, IMensRepository mensRepository, IWomensRepository womensRepository)
        {
            _context = context;
            _mensRepository = mensRepository;
            _womensRepository = womensRepository;
        }

        public async Task<bool> Add(Guid id)
        {
            var product = await _mensRepository.GetByGuid(id);
            if(product == null)
            {
                var WomenProduct = await _womensRepository.GetByGuid(id);
                if(WomenProduct != null)
                {
                    var womens = new ProductAddToCart()
                    {
                        WomensGuidID = WomenProduct.Identifier
                    };
                    _context.ProductATC.Add(womens);
                    return Save();
                }
                else
                {
                    return false;
                }
            }

            var Mens = new ProductAddToCart()
            {
                MensGuidId = product.Identifier
            };
            _context.ProductATC.Add(Mens);
            return Save();


        }

        public async Task<bool> Delete(Guid id)
        {
            var menproduct = await _context.ProductATC.FirstOrDefaultAsync(x => x.MensGuidId == id);
            if(menproduct == null)
            {
                var womenProduct = await _context.ProductATC.FirstOrDefaultAsync(x=> x.WomensGuidID== id);
                _context.ProductATC.Remove(womenProduct);
                return Save();
            }
            _context.ProductATC.Remove(menproduct);
            return Save();

        }

 

        public async Task<List<AddToCartViewModel>> GetProducts()
        {
            var ProductsId = await _context.ProductATC.Select(x => new { x.MensGuidId, x.WomensGuidID}).ToListAsync();

            
            
            var mens = ProductsId.Select(x => x.MensGuidId).ToList();

            var Womens = ProductsId.Select(x => x.WomensGuidID).ToList();

            var menscloth = new MensClothing();
            var womencloth = new WomensClothing();

            var Prodclothing = new List<AddToCartViewModel>();

            if (mens != null)
            {
                foreach (var items in mens)
                {
                    if (items != Guid.Empty)
                    {
                        menscloth = await _mensRepository.GetByGuid(items);
                        var prod = new AddToCartViewModel()
                        {
                            Id = menscloth.Identifier,
                            Name = menscloth.Name,
                            Image = menscloth.Image,
                            Rate = menscloth.Description,
                            quantity = 1

                        };
                        /////////

                        Prodclothing.Add(prod);


                    }
                }
            }
            if(Womens != null)
            {
                foreach (var items in Womens)
                {
                    if (items != Guid.Empty)
                    {
                        womencloth = await _womensRepository.GetByGuid(items);
                        var prod = new AddToCartViewModel()
                        {
                            Id = womencloth.Identifier,
                            Name = womencloth.Name,
                            Image = womencloth.Image,
                            Rate = womencloth.Description,
                            quantity = 1

                        };
                        /////////

                        Prodclothing.Add(prod);


                    }
                }
            }
            return Prodclothing;
          
        }


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

        public bool Save()
        {
            var Saved = _context.SaveChanges();
            return Saved > 0 ? true : false;
        }
    }
}

