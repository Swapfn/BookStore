using AutoMapper;
using Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Models.DTO;
using Models.Mappers;
using Models.Models;
using Services.Contracts;

namespace Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly ITenantService _tenant;
        private readonly BookMapper mapperly;
        public BookService(IUnitOfWork unitOfWork, IMapper mapper, IBookRepository bookRepository, ITenantService tenant)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bookRepository = bookRepository;
            _tenant = tenant;
            mapperly = new();
        }


        public async Task<BookDTO> AddBook(BookDTO model)
        {
            //Book entity = _mapper.Map<Book>(model);
            BookMapper mapper = new();
            Book entity = mapper.BookDTOToBook(model);
            await _bookRepository.Add(entity);
            entity.TenantId = _tenant.TenantId;
            _unitOfWork.SaveChanges();
            return model;
        }

        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public BookDTO EditBook(BookDTO model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookDTO>> GetAll()
        {
            return _mapper.Map<List<BookDTO>>(await _bookRepository.GetAll().ToListAsync());
        }
    }
}
