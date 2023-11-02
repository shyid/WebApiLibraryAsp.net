using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApiLibrary.Data;
using WebApiLibrary.Data.DTO;
using WebApiLibrary.Model;

namespace WebApiLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AppApiLibraryDBContext _context;
        private readonly IMapper _mapper;
        public AuthorsController(AppApiLibraryDBContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            if (_context.Authors == null)
            {
                return NotFound();
            }
            List<Author> listAuthors = await _context.Authors
              .Include(x=>x.AuthorBooks).ThenInclude(y=>y.Book)
             .ToListAsync();

            return listAuthors;
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            if (_context.Authors == null)
            {
                return NotFound();
            }
            var author = await _context.Authors
              .Include(x => x.AuthorBooks)
              .ThenInclude(y => y.Book)
              .FirstOrDefaultAsync(z => z.Id == id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }
        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor([FromBody] AuthorBookViewModel vm)
        {
            if (_context.Authors == null)
            {
                return Problem("Entity set 'AppApiLibraryDBContext.Authors'  is null.");
            }
            var authoeNew = new Author()
            {
                FullName = vm.Name
            };
            foreach (var item in vm.BookIds)
            {
                authoeNew.AuthorBooks.Add(new AuthorBook()
                {
                    Author = authoeNew,
                    BookId = item
                });
            }
            //var authoeNew = _mapper.Map<Author>(newAuthor);
            _context.Authors.Add(authoeNew);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = authoeNew.Id }, authoeNew);
        }
        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, [FromBody]AuthorBookViewModel vm)
        {
            var authorPut = await _context.Authors.Include(x => x.AuthorBooks)
                .ThenInclude(y => y.Book).FirstOrDefaultAsync(z => z.Id == id);

            authorPut.FullName = vm.Name;

            var existingIds = authorPut.AuthorBooks.Select(x=>x.Id).ToList();
            var selectesIds = vm.BookIds.ToList();
            var toAdd = selectesIds.Except(existingIds).ToList();
            var toRemove = existingIds.Except(selectesIds).ToList();
            
            authorPut.AuthorBooks = authorPut.AuthorBooks
                .Where(x=>!toRemove.Contains(x.BookId)).ToList();
            foreach (var item in toAdd)
            {
                authorPut.AuthorBooks.Add(new AuthorBook()
                {
                    BookId = item
                });
            }
           

            try
            {
                _context.Authors.Update(authorPut);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            if (_context.Authors == null)
            {
                return NotFound();
            }
            var author = await _context.Authors.FirstOrDefaultAsync(x=>x.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorExists(int id)
        {
            return (_context.Authors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
