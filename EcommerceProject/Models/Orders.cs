using EcommerceProject.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace EcommerceProject.Models
{
    public class Orders
    {
        [Key]
        public long Id { get; set; }

        public ICollection<MensClothing>? MensClothings { get; set; }
        public ICollection<KidsClothing>? KidsClothings { get; set; }

        public ICollection<WomensClothing>? WomensClothings { get; set;}


        [ForeignKey("AppUsers")]
        public string? AppUsersId { get; set; }
        public AppUsers? appUsers { get; set; } 
    }
}
