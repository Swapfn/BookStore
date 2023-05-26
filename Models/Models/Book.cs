namespace Models.Models
{
    public class Book : Tenant
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<BookCategory> BookCategories { get; set; } = null!;
        public IEnumerable<BookAuthor> BookAuthors { get; set; }
        public IEnumerable<BookReview> BookReviews { get; set; }
        public Book()
        {
            BookReviews = new List<BookReview>();
            BookAuthors = new HashSet<BookAuthor>();
            BookCategories = new HashSet<BookCategory>();
        }
    }
}
