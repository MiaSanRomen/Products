using Products.Data.DataTransfer;

namespace Products.ViewModels
{
    public class EditProductViewModel : BaseViewModel
    {
        public EditProductViewModel()
        {

        }
        public EditProductViewModel(ProductDto product, int categoryId, ICollection<CategoryDto> categories, bool isNew = false) : base(categories)
        {
            Product = product;
            IsNew = isNew;
            CategoryId = categoryId;
        }

        public bool IsNew { get; set; }
        public ProductDto Product { get; set; }
        public int CategoryId { get; set; }
    }
}
