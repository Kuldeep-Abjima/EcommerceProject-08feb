using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceProject.Models
{
    public class ProductAddToCart
    {
        [Key]
        public long Id { get; set; }


        public int? Quantity { get; set; } = 1;

        [ForeignKey("AppUsers")]
        public string? AppUserId { get; set; }

        [ForeignKey("Mens")]
        public int? MensID { get; set; }

        [ForeignKey("Womens")]
        public int? WomensID { get; set; }

    }
}
