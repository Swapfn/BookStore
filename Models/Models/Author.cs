namespace Models.Models
{
    public class Author : Tenant
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Nationality { get; set; }
        public IEnumerable<BookAuthor> BookAuthors { get; set; }
        public Author()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }
    }
}