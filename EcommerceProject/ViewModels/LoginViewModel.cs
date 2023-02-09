using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "EmailAddress")]
        [Required(ErrorMessage = "Email Address is Required")]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
