using OA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interface
{
   public  interface IStudentRepository
    {
        Task AddAsync(Student student);
        Task<List<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(string id);
        Task UpdateAsync(Student student);
        Task DeleteAsync(Student student);
    }
}
