using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceProject.Models
{
    public class AppUsers : IdentityUser
    {
        public string? Name { get; set; }
        public string? ProfileImage { get; set; }


        [ForeignKey("Address")]
        public int? AddressID {get; set;}

        public Address? Address { get; set; }

    }
}
