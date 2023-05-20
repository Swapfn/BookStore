namespace Models.Models
{
    public class Category : Tenant
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public string TenantId { get; set; } = null!;
        public Category()
        {
            Books = new List<Book>();
        }
    }
}
