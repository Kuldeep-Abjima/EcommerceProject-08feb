using EcommerceProject.Data;
using EcommerceProject.Interface;
using EcommerceProject.Models;
using EcommerceProject.Services;
using EcommerceProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUsers> _userManager;
        private readonly SignInManager<AppUsers> _signInManager;
        private readonly AppDbContext _context;
        private readonly IPhotoServices _photoServices;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IAppUserRepository _appUser;

        public AccountController(UserManager<AppUsers> userManager, SignInManager<AppUsers> signInManager, AppDbContext context, IPhotoServices photoServices, IHttpContextAccessor httpContext, IAppUserRepository appUser)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _photoServices = photoServices;
            _httpContext = httpContext;
            _appUser = appUser;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            var login = new LoginViewModel();
            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if(user == null)
            {
                TempData["Error"] = "Register your Email first";
                return RedirectToAction("Register", "Account");
            }

            var PassCheck = await _userManager.CheckPasswordAsync(user,loginViewModel.Password);
            if (PassCheck)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Index", "Home");
                }
                TempData["Error"] = "Wrong credentials. Please try again.";
                return View(loginViewModel);
            }
            TempData["Error"] = "Wrong credentials. Please try again.";
            return View(loginViewModel);


        }

        public IActionResult Register()
        {
            var respone = new RegisterViewModel();
            return View(respone);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel) 
        {
            if(!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            var user = await _userManager.FindByEmailAsync(registerViewModel.Email);
            if (user != null)
            {
                TempData["Error"] = "This Email Already Exist";
                return View(registerViewModel);

            }
            var ImageUpload = await _photoServices.AddPhotoAsync(registerViewModel.Image);
            var newAppUser = new AppUsers()
            {
                Name = registerViewModel.Name,
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email,
                Address = new Address
                {
                    City = registerViewModel.Address.City,
                    Street = registerViewModel.Address.Street,
                    State = registerViewModel.Address.State,
                    Country = registerViewModel.Address.Country,
                },
                ProfileImage = ImageUpload.Url.ToString()
                
            };

            var newUserResponse = await _userManager.CreateAsync(newAppUser, registerViewModel.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newAppUser, UserRoles.User);
            }
            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> User()
        {
            var curUser = _httpContext.HttpContext.User.getUserById();
            var user = await _appUser.GetUsersById(curUser);
            var profile = new UserProfileViewModel
            {
                Name = user.Name,
                ProfileImage = user.ProfileImage,
                //City = user.Address.City,
                //State = user.Address.State,

            };

            return View(profile);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        
    }
}
