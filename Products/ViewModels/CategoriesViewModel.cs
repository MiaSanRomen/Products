using Products.Data.DataTransfer;

namespace Products.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        public CategoriesViewModel(ICollection<CategoryDto> categories)
        {
            Categories = categories;
        }

        public ICollection<CategoryDto> Categories { get; set; }
    }
}
