namespace Models.Models
{
    public class BookReview : Tenant
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
