namespace Models.DTO
{
    public class BookDTO
    {
        public required string Name { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public decimal Price { get; set; }
    }
}
