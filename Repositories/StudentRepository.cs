using LibraryManagementSystem_MileStone_1.DataContext;
using LibraryManagementSystem_MileStone_1.Interfaces;
using LibraryManagementSystem_MileStone_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem_MileStone_1.Repositories
{
    public class StudentRepository : IStudent
    {
        private readonly LibraryDbContext _context;

        public StudentRepository(LibraryDbContext context)
        {
            _context = context;
        }
        //implementing using DbContext for GET-METHOD
        public Task<List<Student>> Index()
        {
            return  _context.Students.ToListAsync();
        }
    }
}
