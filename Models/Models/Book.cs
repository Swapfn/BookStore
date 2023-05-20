namespace Models.Models
{
    public class Book : Tenant
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
        public int ReviewId { get; set; }
        public Review Review { get; set; } = null!;
    }
}
