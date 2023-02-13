using LibraryManagementSystem_MileStone_1.Models;

namespace LibraryManagementSystem_MileStone_1.Interfaces
{
    public interface IBooks
    {
        //get-books
        public Task<List<Book>> Index();
    }
}
