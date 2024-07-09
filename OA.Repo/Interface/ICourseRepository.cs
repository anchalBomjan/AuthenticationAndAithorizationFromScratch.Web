using OA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interface
{
    public  interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCourses();
        Task<Course> GetCourseById(int id);
        Task AddCourse(Course course);
        Task UpdateCourse(Course course);
        Task DeleteCourse(int id);
    }
}
