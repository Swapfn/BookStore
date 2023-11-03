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
        public async Task<IActionResult> AddBook(BookDTO model)
        {
            return Created("", await Service.AddBook(model));
        }
        [HttpGet]
        [Route("/getBooks")]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await Service.GetAll());
        }
        //[HttpPut]
        //[Route("/editBook")]
        //public IActionResult GetBooks()
        //{
        //    return Ok(Service.GetAll());
        //}
        //[HttpDelete]
        //[Route("/deleteBook")]
        //public IActionResult GetBooks()
        //{
        //    return Ok(Service.GetAll());
        //}
    }
}
