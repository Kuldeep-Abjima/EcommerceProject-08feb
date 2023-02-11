using EcommerceProject.Interface;
using EcommerceProject.Models;
using EcommerceProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    public class WomensController : Controller
    {
        private readonly IWomensRepository _repository;
        private readonly IPhotoServices _photoServices;

        public WomensController(IWomensRepository repository, IPhotoServices photoServices)
        {
            _repository = repository;
            _photoServices = photoServices;
        }
        public async Task<IActionResult> Index()
        {
            var womens = await _repository.GetAll();

            return View(womens);
        }
        public IActionResult Create()
        {
            var womensCloth = new CreateWomenClothViewModel();
            return View(womensCloth);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateWomenClothViewModel cwcViewModel)
        {
           if(ModelState.IsValid)
           {
                var photo = await _photoServices.AddPhotoAsync(cwcViewModel.Image);
                var women = new WomensClothing()
                {
                    Name = cwcViewModel.Name,
                    Description = cwcViewModel.Description,
                    Image = photo.Url.ToString(),
                    Category = cwcViewModel.Category,
                };
                _repository.Add(women);
                return RedirectToAction("Index","Womens");
           }
            return View(cwcViewModel);
        }

        public async Task<IActionResult> Detail(int id)
        {
         
            var women = await _repository.GetByIdAsync(id);
            return View(women);
         
        }
    }
}
