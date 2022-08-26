using Products.Data.DataTransfer;

namespace Products.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        public ProductsViewModel(ICollection<ProductDto> products)
        {
            Products = products;
        }

        public ICollection<ProductDto> Products { get; set; }
    }
}
