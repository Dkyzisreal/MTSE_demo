namespace demo.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
