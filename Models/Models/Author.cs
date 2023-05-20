namespace Models.Models
{
    public class Author : Tenant
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Nationality { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public Author()
        {
            Books = new HashSet<Book>();
        }
    }
}