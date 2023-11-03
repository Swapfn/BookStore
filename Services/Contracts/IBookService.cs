using Models.DTO;

namespace Services.Contracts
{
    public interface IBookService
    {
        public Task <IEnumerable<BookDTO>> GetAll();
        public Task<BookDTO> AddBook(BookDTO model);
        public BookDTO EditBook(BookDTO model);
        public void DeleteBook(int id);
    }
}
