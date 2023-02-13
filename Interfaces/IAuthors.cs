using LibraryManagementSystem_MileStone_1.Models;

namespace LibraryManagementSystem_MileStone_1.Interfaces
{
    public interface IAuthors
    {
        //get-authors
        public Task<List<Author>> Index();
    }
}
