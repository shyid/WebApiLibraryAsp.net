using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApiLibrary.Data;
using WebApiLibrary.Model;

namespace WebApiLibrary.Controllers
{
    public class Books1Controller : Controller
    {
        private readonly AppApiLibraryDBContext _context;

        public Books1Controller(AppApiLibraryDBContext context)
        {
            _context = context;
        }

        // GET: Books1
        public async Task<IActionResult> Index()
        {
              return _context.Book != null ? 
                          View(await _context.Book.ToListAsync()) :
                          Problem("Entity set 'AppApiLibraryDBContext.Book'  is null.");
        }

        
    }
}
