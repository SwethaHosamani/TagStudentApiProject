// using System;
// using System.Linq.Expressions;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;

// using Xunit;
// using Moq;
// using DeleteApi.Controllers;
// using DeleteApi.Models;
// namespace DeleteApiTesting
// {
//  public class DeleteControllerTests{
// [Fact]
// public void DeleteByStudentId_ExistingStudent_ReturnsNoContent()
// {
//     // Arrange
//     var dbContextMock = new Mock<TestDemoContext>();
//     var controller = new DeleteController(dbContextMock.Object);

//     var studentId = "STDN00003";

//     var existingStudent = new StudentDatum
//     {
//         StudentId = studentId,
//         // Gender = 'M',
//         //         Nationlity = "indian",
//         //         PlaceOfBirth = "Odisha",
//         //         StageId = "MiddleSchool",
//         //         GradeId = "G-08",
//         //         SectionId = 'D',
//         //         Topic = "ECC",
//         //         Semester = 'S',
//         //         Relation = "Son",
//         //         RaisedHands = 5,
//         //         VisitedResources = 12,
//         //         AnnouncementsView = 13,
//         //         Discussion = 6,
//         //         ParentAnsweringSurvey = "Yes",
//         //         ParentschoolSatisfaction = "good",
//         //         StudentAbsenceDays = "below-7",
//         //         StudentMarks = 87,
//         //         Classes = 'A'
//     };

//     // Setup the context mock to return the existing student when queried
//     dbContextMock.Setup(m => m.StudentData.SingleOrDefault(It.IsAny<Expression<Func<StudentDatum, bool>>>()))
//                 .Returns(existingStudent);

//     // Assuming SaveChanges always succeeds in this test
//     dbContextMock.Setup(m => m.SaveChanges()).Returns(1);

//     // Act
//     var result = controller.DeleteByStudentId(studentId) as NoContentResult;

//     // Assert
//     Assert.NotNull(result);
//     Assert.Equal(StatusCodes.Status204NoContent, result.StatusCode);
// }}
// }
//=====================================================================using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Deleteapi.Controllers;
using Deleteapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace DeleteApiTests
{
    public class DeleteControllerTests
    {
        [Fact]
        public void DeleteByStudentId_ExistingStudent_ReturnsNoContent()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TestDemoContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new TestDemoContext(options))
            {
                var controller = new DeleteController(context);

                var studentId = "STDN00010";

                var existingStudent = new StudentDatum
                {
                    StudentId = studentId,
                    Gender = 'M'
                };

                context.StudentData.Add(existingStudent);
                context.SaveChanges();

                // Act
                var result = controller.DeleteByStudentId(studentId) as NoContentResult;

                // Assert
                Assert.NotNull(result);
                Assert.Equal(StatusCodes.Status204NoContent, result.StatusCode);
                Assert.Null(context.StudentData.FirstOrDefault(s => s.StudentId == studentId));
            }
        }

       [Fact]
        public void DeleteByStudentId_NonExistingStudent_ReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TestDemoContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new TestDemoContext(options))
            {
                var controller = new DeleteController(context);

                var studentId = "STDN00001"; // Assuming this ID doesn't exist

                // Act
                var result = controller.DeleteByStudentId(studentId) as NotFoundResult;

                // Assert
                Assert.NotNull(result);
                Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
            }
        }
       
    }
}
