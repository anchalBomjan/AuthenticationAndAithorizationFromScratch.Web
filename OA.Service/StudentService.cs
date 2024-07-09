using OA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service
{
    internal class StudentService:IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task CreateStudentAsync(StudentViewModel viewModel)
        {
            var student = new Student
            {
                StudentID = viewModel.StudentID,
                Name = viewModel.Name,
                Email = viewModel.Email
            };
            await _studentRepository.AddAsync(student);
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student> GetStudentByIdAsync(string id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task UpdateStudentAsync(string id, StudentViewModel viewModel)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                throw new ArgumentException($"No student found with ID {id}");
            }
            student.Name = viewModel.Name;
            student.Email = viewModel.Email;
            await _studentRepository.UpdateAsync(student);
        }

        public async Task DeleteStudentAsync(string id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                throw new ArgumentException($"No student found with ID {id}");
            }
            await _studentRepository.DeleteAsync(student);
        }
    }
}
