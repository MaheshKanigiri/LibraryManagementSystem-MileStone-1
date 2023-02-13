using LibraryManagementSystem_MileStone_1.Models;

namespace LibraryManagementSystem_MileStone_1.Interfaces
{
    public interface IBorrows
    {
        //get-borrow details
        public Task<List<Borrow>> Index();
    }
}
