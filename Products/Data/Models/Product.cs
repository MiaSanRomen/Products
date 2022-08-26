using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string NoteCustom { get; set; }
        public decimal Price { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }        
        public Category Category { get; set; }
        [ForeignKey(nameof(GeneralNoteId))]
        public int GeneralNoteId { get; set; }
        public GeneralNote GeneralNote { get; set; }
        [ForeignKey(nameof(ImageId))]
        public int? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
