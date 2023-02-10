using EcommerceProject.Interface;
using EcommerceProject.Models;
using EcommerceProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    public class MensController : Controller
    {
		private readonly IMensRepository _repository;
		private readonly IPhotoServices _photoServices;

		public MensController(IMensRepository repository, IPhotoServices photoServices)
        {
			_repository = repository;
			_photoServices = photoServices;
		}
        public async Task<IActionResult> Index()
        {
            IEnumerable <MensClothing> mensClothings = await _repository.GetAll();
            return View(mensClothings);
        }


        public async Task<IActionResult> Detail(int id)
        {
            var cloth =  await _repository.GetByIdAsync(id);
            return View(cloth);

        }

        public IActionResult Create()
        {
            var createMensClothViewModel = new CreateMensClothViewModel();
            return View(createMensClothViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMensClothViewModel cmcViewModel)
        {
            if (ModelState.IsValid)
            {
                var img = await _photoServices.AddPhotoAsync(cmcViewModel.Image);
                var mens = new MensClothing()
                {
                    Name = cmcViewModel.Name,
                    Description = cmcViewModel.Description,
                    Category = cmcViewModel.Category,
                    Image = img.Url.ToString()
                };
                _repository.Add(mens);
                return RedirectToAction("Index", "Mens");
            }
            return View(cmcViewModel);
        }


    }
}
