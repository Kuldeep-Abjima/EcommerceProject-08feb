using EcommerceProject.Data;
using EcommerceProject.Interface;
using EcommerceProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    public class AddToCartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IAddToCartRepository _toCartRepository;
        private readonly IMensRepository _mensRepository;
        private readonly IWomensRepository _womensRepository;

        public AddToCartController(AppDbContext context,IAddToCartRepository toCartRepository, IMensRepository mensRepository, IWomensRepository womensRepository)
        {
            _context = context;
            _toCartRepository = toCartRepository;
            _mensRepository = mensRepository;
            _womensRepository = womensRepository;
        }



        public async Task<IActionResult> Index()
        {
            var pro = await _toCartRepository.GetProducts();
            return View(pro);
        }

        //[HttpGet]
        //public Task<IActionResult> Index()
        //{
           
        //    return View(pro);
            
        //}


        public async Task<IActionResult> Cart(Guid Id)
        {
            await _toCartRepository.Add(Id);
            return RedirectToAction("Index", "AddToCart");
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            await _toCartRepository.Delete(id);
            return RedirectToAction("Index", "AddToCart");
        }
        
    }
}
