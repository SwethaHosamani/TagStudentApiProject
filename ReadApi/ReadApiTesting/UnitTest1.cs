using System.Collections.Generic;
using ReadApi.Controllers;
using ReadApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace ReadApiTesting;

public class UnitTest1
{
    

    [Fact]
        public void GetAll_ReturnsOkResultWithData()
        {
            // Arrange
            var students = new List<StudentDatum>
            {
                new StudentDatum { StudentId = "STDN00001", Gender = 'M' },
                new StudentDatum { StudentId = "STDN00002", Gender = 'F' }
            };

            var dbContextMock = new Mock<TestDemoContext>();
            dbContextMock.Setup(x => x.StudentData).Returns(students.ToDbSet());

            var controller = new ReadController(dbContextMock.Object);

            // Act
            IActionResult result = controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(result);

            OkObjectResult okResult = (OkObjectResult)result;
            Assert.NotNull(okResult.Value);

            List<StudentDatum> studentsResult = okResult.Value as List<StudentDatum>;
            Assert.Equal(students.Count, studentsResult.Count);
        }

        [Fact]
        public void GetAll_ReturnsNotFoundResultWhenDataIsEmpty()
        {
            // Arrange
            var students = new List<StudentDatum>();

            var dbContextMock = new Mock<TestDemoContext>();
            dbContextMock.Setup(x => x.StudentData).Returns(students.ToDbSet());

            var controller = new ReadController(dbContextMock.Object);

            // Act
            IActionResult result = controller.GetAll();

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }

    public static class DbSetExtensions
    {
        public static DbSet<T> ToDbSet<T>(this IEnumerable<T> list) where T : class
        {
            var queryable = list.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            return mockSet.Object;
        }
    }
