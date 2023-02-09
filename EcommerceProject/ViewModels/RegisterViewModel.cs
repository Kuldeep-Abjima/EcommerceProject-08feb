using EcommerceProject.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EcommerceProject.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email Address is Required")]
        public string Email{ get; set; }


        [Required(ErrorMessage = "Name Is Required")]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name="Profile Image")]
        public IFormFile Image { get; set; }
    

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        [Compare("Password", ErrorMessage = "Password does'nt Match")]
        public string ConfirmPassword { get; set; }

        [Display(Name="Address")]
        public Address Address { get; set; }





    }
}
