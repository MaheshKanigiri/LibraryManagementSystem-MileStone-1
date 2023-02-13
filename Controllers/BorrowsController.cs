using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem_MileStone_1.DataContext;
using LibraryManagementSystem_MileStone_1.Models;
using LibraryManagementSystem_MileStone_1.Interfaces;

namespace LibraryManagementSystem_MileStone_1.Controllers
{
    public class BorrowsController : Controller
    {
      
        
        private readonly LibraryDbContext _context;
        private readonly IBorrows _repo;

        public BorrowsController(LibraryDbContext context, IBorrows repo)
        {
            _context = context;
            _repo = repo;
        }
        //implementing GET-USING DEPENDENCY-INJECTION
        // GET: Borrows
        public async Task<IActionResult> Index()
        {
            //var libraryDbContext = _context.Borrows.Include(b => b.Book).Include(b => b.Student);
            //return View(await libraryDbContext.ToListAsync());
            return View(await _repo.Index());

        }

        // GET: Borrows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Borrows == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrows
                .Include(b => b.Book)
                .Include(b => b.Student)
                .FirstOrDefaultAsync(m => m.BorrowId == id);
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }

        // GET: Borrows/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        // POST: Borrows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BorrowId,StudentId,BookId,TakenDate,BroughtDate")] Borrow borrow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(borrow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", borrow.BookId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", borrow.StudentId);
            return View(borrow);
        }

        // GET: Borrows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Borrows == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrows.FindAsync(id);
            if (borrow == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", borrow.BookId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", borrow.StudentId);
            return View(borrow);
        }

        // POST: Borrows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BorrowId,StudentId,BookId,TakenDate,BroughtDate")] Borrow borrow)
        {
            if (id != borrow.BorrowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowExists(borrow.BorrowId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", borrow.BookId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", borrow.StudentId);
            return View(borrow);
        }

        // GET: Borrows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Borrows == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrows
                .Include(b => b.Book)
                .Include(b => b.Student)
                .FirstOrDefaultAsync(m => m.BorrowId == id);
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }

        // POST: Borrows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Borrows == null)
            {
                return Problem("Entity set 'LibraryDbContext.Borrows'  is null.");
            }
            var borrow = await _context.Borrows.FindAsync(id);
            if (borrow != null)
            {
                _context.Borrows.Remove(borrow);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowExists(int id)
        {
          return _context.Borrows.Any(e => e.BorrowId == id);
        }
    }
}
