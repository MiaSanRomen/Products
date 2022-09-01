using Products.Data.DataTransfer;

namespace Products.ViewModels
{
    public class RemoveProductViewModel
    {
        public RemoveProductViewModel(ProductDto product)
        {
            Product = product;
        }
        public ProductDto Product { get; set; }
    }
}
