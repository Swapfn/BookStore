namespace Models.Models
{
    public class Category : Tenant
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<BookCategory> BookCategories { get; set; }
        public Category()
        {
            BookCategories = new List<BookCategory>();
        }
    }
}
