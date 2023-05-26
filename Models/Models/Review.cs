namespace Models.Models
{
    public class Review : Tenant
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public IEnumerable<BookReview> BooksReviews { get; set; }
        public Review()
        {
            BooksReviews = new List<BookReview>();
        }
    }
}
