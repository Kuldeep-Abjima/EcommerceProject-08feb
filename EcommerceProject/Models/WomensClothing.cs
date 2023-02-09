using EcommerceProject.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Models
{
    public class WomensClothing
    {

        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public ClothingCategory Category { get; set; }


        [ForeignKey("AppUsers")]
        public string? AppUsersId { get; set; }

        public AppUsers? AppUser { get; set; }
    }
}
