namespace EcommerceProject.ViewModels
{
    public class AddToCartViewModel
    {

        public Guid Id { get; set; }
        public string? Name { get; set; }

        public string? Rate { get; set; }

        public string? Image { get; set; }

        public int? quantity { get; set; } = 1;


    }
}
