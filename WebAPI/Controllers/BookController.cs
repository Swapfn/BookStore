using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Services.Contracts;

namespace WebAPI.Controllers
{
    public class BookController : BaseController
    {
        public IBookService Service;
        public BookController(IBookService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("/addBook")]
        public IActionResult AddBook(BookDTO model)
        {
            return Created("", Service.AddBook(model));
        }
        [HttpGet]
        [Route("/getBooks")]
        public IActionResult GetBooks()
        {
            return Ok(Service.GetAll());
        }
    }
}
