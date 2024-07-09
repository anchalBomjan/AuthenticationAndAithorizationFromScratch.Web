using AuthenticationAndAithorizationFromScratch.Web.Models;
using Microsoft.AspNetCore.Mvc;
using OA.Data;
using OA.Repo.Interface;

namespace AuthenticationAndAithorizationFromScratch.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // GET: /Course/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var course = new Course
            {
                CourseName = viewModel.CourseName,
                CourseDescription = viewModel.CourseDescription,
                Credits = viewModel.Credits
            };

            await _courseRepository.AddCourse(course);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Course/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var courses = await _courseRepository.GetAllCourses();
            return View(courses);
        }

        // GET: /Course/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseRepository.GetCourseById(id);
            if (course == null)
            {
                return View("Error", new ErrorViewModel { RequestId = $"No course found with ID {id}" });
            }

            var viewModel = new CourseViewModel
            {
                CourseName = course.CourseName,
                CourseDescription = course.CourseDescription,
                Credits = course.Credits
            };

            return View(viewModel);
        }

        // POST: /Course/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseViewModel viewModel)
        {
            if (id <= 0 || !ModelState.IsValid)
            {
                return View(viewModel);
            }

            var course = await _courseRepository.GetCourseById(id);
            if (course == null)
            {
                return View("Error", new ErrorViewModel { RequestId = $"No course found with ID {id}" });
            }

            course.CourseName = viewModel.CourseName;
            course.CourseDescription = viewModel.CourseDescription;
            course.Credits = viewModel.Credits;

            await _courseRepository.UpdateCourse(course);
            return RedirectToAction(nameof(Index));
        }

        // POST: /Course/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseRepository.GetCourseById(id);
            if (course == null)
            {
                return View("Error", new ErrorViewModel { RequestId = $"No course found with ID {id}" });
            }

            await _courseRepository.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
