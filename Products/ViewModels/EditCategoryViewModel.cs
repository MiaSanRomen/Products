using Products.Data.DataTransfer;

namespace Products.ViewModels
{
    public class EditCategoryViewModel : BaseViewModel
    {
        public EditCategoryViewModel() 
        {

        }
        public EditCategoryViewModel(CategoryDto category, ICollection<CategoryDto> categories, bool isNew = false) : base(categories)
        {
            Category = category;
            IsNew = isNew;
        }
        public bool IsNew { get; set; }
        public CategoryDto Category { get; set; }
    }
}
