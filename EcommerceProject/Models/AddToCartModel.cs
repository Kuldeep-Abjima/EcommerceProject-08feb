using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceProject.Models
{
    public class AddToCartModel
    {
        public long Id { get; set; }    


        
        [ForeignKey("AppUsers")]
        public string AppUserId { get; set; }

        [ForeignKey("Mens")]
        public IEnumerable<int>? MensID { get; set; }

        [ForeignKey("Womens")]
        public IEnumerable<int>? WomensID { get; set; }

        //[ForeignKey("Ki")]
        //public IEnumerable<int>? WomensID { get; set; }




        public IEnumerable<WomensClothing>? WomensClothing { get;set; }
        public IEnumerable<MensClothing>? MensClothing { get; set;}
        public IEnumerable<KidsClothing>? KidsClothing { get; set;}
    
    }
}
