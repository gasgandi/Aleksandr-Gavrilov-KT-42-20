using Aleksandr_Gavrilov_KT_42_20.Database;
using Aleksandr_Gavrilov_KT_42_20.Interfaces.CoursesInterfaces;
using Aleksandr_Gavrilov_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using Aleksandr_Gavrilov_KT_42_20.Filters.CourseFilters;

namespace AleksandrGavrilovKt_42_20.Tests
{
    public class CourseIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public CourseIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
            .UseInMemoryDatabase(databaseName: "student_db")
            .Options;
        }

        [Fact]
        public async Task GetCoursesByGroupAsync_KT4220_TwoObjects()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var courseService = new CourseService(ctx);

            var groups = new List<Group>
            {
                new Group
                {
                    GroupId =100,
                    GroupName = "KT-31-20"
                },
                new Group
                {
                    GroupId =200,
                    GroupName = "KT-41-20"
                }
            };

            await ctx.Set<Group>().AddRangeAsync(groups);
            await ctx.SaveChangesAsync();

            var course = new List<Course>
            {
                new Course
                {
                    CourseId = 1,
                    Title = "PISK",
                    GroupId = 200
                },
                new Course
                {
                    CourseId = 2,
                    Title = "PP",
                    GroupId = 200
                }
            };
            await ctx.Set<Course>().AddRangeAsync(course);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new CourseGroupFilter
            {
                GroupName = "KT-41-20"
            };
            var Result = await courseService.GetCoursesByGroupAsync(filter, CancellationToken.None);

            // Assert
            Assert.Empty(Result);
        }
    }
}
