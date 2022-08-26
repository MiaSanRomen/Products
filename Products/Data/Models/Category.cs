using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public ICollection<Product> Products { get; set; }
        [ForeignKey(nameof(ImageId))]
        public int? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
