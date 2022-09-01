using Products.Data.DataTransfer;

namespace Products.ViewModels
{
    public class RemoveCategoryViewModel
    {
        public RemoveCategoryViewModel(CategoryDto category)
        {
            Category = category;
        }
        public CategoryDto Category { get; set; }
    }
}
