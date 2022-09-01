using Products.Data.DataTransfer;

namespace Products.ViewModels
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {

        }
        public BaseViewModel(ICollection<CategoryDto> categories)
        {
            Categories = categories;
        }

        public ICollection<CategoryDto> Categories { get; set; }
    }
}
