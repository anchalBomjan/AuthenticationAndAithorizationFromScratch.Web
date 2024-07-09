using OA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service
{
    public  interface IStudentService
    {
        Task CreateStudentAsync(StudentViewModel viewModel);
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(string id);
        Task UpdateStudentAsync(string id, StudentViewModel viewModel);
        Task DeleteStudentAsync(string id);
    }
}
