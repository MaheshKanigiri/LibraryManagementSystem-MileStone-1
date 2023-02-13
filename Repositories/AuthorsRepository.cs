using LibraryManagementSystem_MileStone_1.DataContext;
using LibraryManagementSystem_MileStone_1.Interfaces;
using LibraryManagementSystem_MileStone_1.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem_MileStone_1.Repositories
{
    public class AuthorsRepository:IAuthors
    {
        private readonly LibraryDbContext _context;

        public AuthorsRepository(LibraryDbContext context)
        {
            _context = context;
        }

        //implementing using DbContext for GET-METHOD
        public async Task<List<Author>> Index()
        {
            return (await _context.Authors.ToListAsync());
        }
    }
}
