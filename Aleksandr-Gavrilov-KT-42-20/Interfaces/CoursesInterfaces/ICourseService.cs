using Aleksandr_Gavrilov_KT_42_20.Models;
using Aleksandr_Gavrilov_KT_42_20.Database;
using Microsoft.EntityFrameworkCore;
using Aleksandr_Gavrilov_KT_42_20.Filters.CourseFilters;

namespace Aleksandr_Gavrilov_KT_42_20.Interfaces.CoursesInterfaces
{
    public interface ICoursesService
    {
        public Task<Course[]> GetCoursesByGroupAsync(CourseGroupFilter filter, CancellationToken cancellationToken);
    }

    public class CourseService : ICoursesService
    {
        private readonly StudentDbContext _dbContext;
        public CourseService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Course[]> GetCoursesByGroupAsync(CourseGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var courses = _dbContext.Set<Course>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);

            return courses;
        }
    }
}