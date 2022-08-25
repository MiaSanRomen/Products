namespace Products.Data.DataTransfer
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string NoteCustom { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }        
        public CategoryDto Category { get; set; }
        public int GeneralNoteId { get; set; }
        public GeneralNoteDto GeneralNote { get; set; }
    }
}
