using EcommerceProject.Data.Enums;

namespace EcommerceProject.ViewModels
{
    public class EditMensClothViewModel
    {

        public string Name { get; set; }

        public IFormFile Image { get; set; }

        public string Description { get; set; }

        public ClothingCategory Category { get; set; }


        public string? URL { get; set; }

    }
}
