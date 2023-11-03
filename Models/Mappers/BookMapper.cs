using Models.DTO;
using Models.Models;
using Riok.Mapperly.Abstractions;

namespace Models.Mappers
{
    [Mapper]
    public partial class BookMapper
    {
        public partial BookDTO BookToBookDTO(Book book);
        public partial Book BookDTOToBook(BookDTO bookDTO);

    }
}
