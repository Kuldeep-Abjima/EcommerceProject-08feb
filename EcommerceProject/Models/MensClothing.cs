using EcommerceProject.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Models
{
    public class MensClothing
    {
        [Key]
        public long Id { get; set; }


        public Guid Identifier { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public string? Image { get; set; }

        public string Description { get; set; }

        public ClothingCategory Category { get; set; }


        [ForeignKey("AppUsers")]
        public string? AppUsersId { get; set; }

        public AppUsers? AppUser { get; set; }
    }
}
