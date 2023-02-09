using EcommerceProject.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceProject.Models
{
    public class KidsClothing
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
