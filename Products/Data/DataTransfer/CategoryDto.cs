using Products.Data.Models;

namespace Products.Data.DataTransfer
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int? ImageId { get; set; }
        public ImageDto Image { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
