using Products.Data.DataTransfer;

namespace Products.ViewModels
{
    public class CategoryDetailsViewModel : BaseViewModel
    {
        public CategoryDetailsViewModel(CategoryDto category)
        {
            Category = category;
        }

        public CategoryDto Category { get; set; }
    }
}
