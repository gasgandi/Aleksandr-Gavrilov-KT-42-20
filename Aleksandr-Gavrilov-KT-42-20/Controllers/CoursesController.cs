using Aleksandr_Gavrilov_KT_42_20.Database;
using Aleksandr_Gavrilov_KT_42_20.Filters.CourseFilters;
using Aleksandr_Gavrilov_KT_42_20.Interfaces.CoursesInterfaces;
using Aleksandr_Gavrilov_KT_42_20.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aleksandr_Gavrilov_KT_42_20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ILogger<CoursesController> _logger;
        private readonly ICoursesService _courseService;
        private StudentDbContext _context;

        public CoursesController(ILogger<CoursesController> logger, ICoursesService courseService, StudentDbContext context)
        {
            _logger = logger;
            _courseService = courseService;
            _context = context;
        }

        [HttpPost(Name = "GetCourseByGroup")]
        public async Task<IActionResult> GetCoursesByGroupAsync(CourseGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var courses = await _courseService.GetCoursesByGroupAsync(filter, cancellationToken);

            return Ok(courses);
        }

        [HttpPost("AddCourse", Name = "AddCourse")]
        public IActionResult CreateCourse([FromBody] Aleksandr_Gavrilov_KT_42_20.Models.Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Courses.Add(course);
            _context.SaveChanges();
            return Ok(course);
        }

        [HttpPut("EditCourse")]
        public IActionResult UpdateCourse(string title, [FromBody] Course updatedCourse)
        {
            var existingCourse = _context.Courses.FirstOrDefault(g => g.Title == title);

            if (existingCourse == null)
            {
                return NotFound();
            }

            existingCourse.Title = updatedCourse.Title;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("DeleteCourse")]
        public IActionResult DeleteCourse(string title, Aleksandr_Gavrilov_KT_42_20.Models.Course updatedCourse)
        {
            var existingCourse = _context.Courses.FirstOrDefault(g => g.Title == title);

            if (existingCourse == null)
            {
                return NotFound();
            }
            _context.Courses.Remove(existingCourse);
            _context.SaveChanges();

            return Ok();
        }
    }
}