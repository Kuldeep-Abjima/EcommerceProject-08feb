using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceProject.Models
{
    public class ProductAddToCart
    {
        [Key]
        public long Id { get; set; }

        public Guid Identifier { get; set; } = Guid.NewGuid();

        [ForeignKey("AppUsers")]
        public string? AppUserId { get; set; }


        public Guid MensGuidId { get; set; } = Guid.Empty;

        public Guid WomensGuidID { get; set; } = Guid.Empty;

    }
}
