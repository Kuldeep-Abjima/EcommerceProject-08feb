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
        
        public async Task<IActionResult> Delete(int id)
        {
           var clubdetail = await _repository.GetByIdAsync(id);
           if(clubdetail == null)
           {
                return View("Error");
           }
            return View(clubdetail);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteMens(int id)
        {
            var clubdetails = await _repository.GetByIdAsync(id);
            if(clubdetails == null)
            {
                return View("Error");
            }
            var delete = _repository.Delete(clubdetails);
            return RedirectToAction("Index", "Mens");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var menscloth = await _repository.GetByIdAsync(id);
            if(menscloth == null)
            {
                return View("Error");
            }
            var menEdit = new EditMensClothViewModel()
            {
                Name = menscloth.Name,
                Description = menscloth.Description,
                Category = menscloth.Category,
                URL = menscloth.Image


            };
            return View(menEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditMensClothViewModel emcViewModel)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit mens cloth");
                return View("Edit", emcViewModel);
            }
            var mencloth = await _repository.GetByIdAsyncNoTracking(id);
            if (mencloth != null)
            {
                try
                {
                    await _photoServices.DeletePhotoAsync(mencloth.Image);

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "could not delete photo");
                    return View(emcViewModel);
                }

                var photoResult = await _photoServices.AddPhotoAsync(emcViewModel.Image);

                var mens = new MensClothing
                {
                    Id = id,
                    Name = emcViewModel.Name,
                    Description = emcViewModel.Description,
                    Image = photoResult.Url.ToString(),

                };
                _repository.Update(mens);
                return RedirectToAction("Index", "Mens");
            }
            else
            {
                return View(emcViewModel);
            }
            
        }


    }
}
