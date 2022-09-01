using Products.Data.DataTransfer;

namespace Products.ViewModels
{
    public class CategoryDetailsViewModel : BaseViewModel
    {
        public CategoryDetailsViewModel(CategoryDto category, bool isDefaultCategory, ICollection<CategoryDto> categories) : base(categories)
        {
            Category = category;
            IsDefaultCategory = isDefaultCategory;
        }

        public CategoryDto Category { get; set; }
        public bool IsDefaultCategory { get; set; }
    }
}
