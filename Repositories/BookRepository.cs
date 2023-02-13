using LibraryManagementSystem_MileStone_1.DataContext;
using LibraryManagementSystem_MileStone_1.Interfaces;
using LibraryManagementSystem_MileStone_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem_MileStone_1.Repositories
{
    public class BookRepository:IBooks
    {

        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }
        //implementing using DbContext for GET-METHOD
        public async Task<List<Book>> Index()
        {
            var libraryDbContext = _context.Books.Include(b => b.Author);
            return (await libraryDbContext.ToListAsync());
        }
    }
}
