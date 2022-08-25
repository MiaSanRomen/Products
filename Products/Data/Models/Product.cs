namespace Products.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string NoteCustom { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }        
        public Category Category { get; set; }
        public int GeneralNoteId { get; set; }
        public GeneralNote GeneralNote { get; set; }
    }
}
