using LibraryManagementSystem_MileStone_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem_MileStone_1.Interfaces
{
    public interface IStudent
    {
        //get-students
        public  Task<List<Student>> Index();
    }
}
