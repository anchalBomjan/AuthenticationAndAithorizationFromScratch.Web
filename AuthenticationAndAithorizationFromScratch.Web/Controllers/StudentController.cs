using AuthenticationAndAithorizationFromScratch.Web.Models;
using Microsoft.AspNetCore.Mvc;
using OA.Service;

namespace AuthenticationAndAithorizationFromScratch.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: /Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                await _studentService.CreateStudentAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error creating student: {ex.Message}");
                return View(viewModel);
            }
        }

        // GET: /Student/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return View(students);
        }

        // GET: /Student/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View("Error", new ErrorViewModel { RequestId = "Invalid Student ID" });
            }

            try
            {
                var student = await _studentService.GetStudentByIdAsync(id);
                if (student == null)
                {
                    return View("Error", new ErrorViewModel { RequestId = $"No student found with ID {id}" });
                }
                return View(student);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error retrieving student: {ex.Message}");
                return View("Error", new ErrorViewModel { RequestId = $"Error retrieving student with ID {id}" });
            }
        }

        // POST: /Student/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, StudentViewModel viewModel)
        {
            if (string.IsNullOrEmpty(id) || !ModelState.IsValid)
            {
                return View(viewModel);
            }

            try
            {
                await _studentService.UpdateStudentAsync(id, viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error updating student: {ex.Message}");
                return View(viewModel);
            }
        }

        // POST: /Student/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _studentService.DeleteStudentAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error deleting student: {ex.Message}");
                return View("Error", new ErrorViewModel { RequestId = $"Error deleting student with ID {id}" });
            }
        }
}
