using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApiLibrary.Data;
using WebApiLibrary.Data.DTO;
using WebApiLibrary.Model;

namespace WebApiLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly AppApiLibraryDBContext _context;
        private readonly IMapper _mapper;
        public BooksController(AppApiLibraryDBContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        // GET: Books
        [HttpGet(Name = "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Book> BookList = await _context.Book.Include(_=>_.Caregories)
                .ToListAsync();
            return Ok(BookList);
        }
        [HttpGet("{id:int}", Name = "GetBooks")]
        public async Task<ActionResult> GetBooks(int? id)
        {
           
            if (id == 0)
            {
                return BadRequest();
            }

            var Book = await _context.Book.Include(_=>_.Caregories)
                .Where(u => u.Id == id).FirstOrDefaultAsync();
            if (Book is null )
            {
                return NotFound();
            }
            return Ok(Book);
        }
       
        [HttpPost]
        public async Task<ActionResult> CreateBook([FromBody]DTOBook DtoBook)
        {
            if (DtoBook is null)
                return NotFound();

            //Book bookNew = new Book();
            var bookNew = _mapper.Map<Book>(DtoBook);
            if (ModelState.IsValid)
            {
                await _context.AddAsync(bookNew);
                _context.SaveChanges();
            }
            return Ok(bookNew);
        }
        [HttpPut]
        public async Task<ActionResult> PutBook(DTOBook DtoBook)
        {
            if (DtoBook is null)
                return NotFound();
            var bookUpdate = _mapper.Map<Book>(DtoBook);
            if (ModelState.IsValid)
            {
                 _context.Update(bookUpdate);
                _context.SaveChanges();
            }
            return Ok(bookUpdate);
        }
        //[HttpPut("{id:int}", Name = "UpdateBook")]
        //public async Task<ActionResult> UpdateBook(int id, Book DtoBook)
        //{
            
        //    if (id != DtoBook.Id || DtoBook == null)
        //        return BadRequest();
            
        //    if (ModelState.IsValid)
        //    {
        //        DtoBook.FullName = DtoBook.FullName;
        //        DtoBook.InLibrart = DtoBook.InLibrart;

        //        _context.Update(DtoBook);
        //        _context.SaveChanges();
                
        //    }
        //    return Ok();
        //}
        [HttpDelete("{id:int}", Name = "DeleteBook")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            if (id == 0)
                return BadRequest();
            
            var DelBook = await _context.Book.Include(_=>_.Caregories)
                .Where(u => u.Id == id).FirstOrDefaultAsync();
            if (DelBook is null)
                return NotFound();

            _context.Remove(DelBook);            
            _context.SaveChanges();
            return NoContent();
        }
    }
}
