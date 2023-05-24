using Models.DTO;

namespace Services.Contracts
{
    public interface IBookService
    {
        public IEnumerable<BookDTO> GetAll();
        public BookDTO AddBook(BookDTO model); 
    }
}
