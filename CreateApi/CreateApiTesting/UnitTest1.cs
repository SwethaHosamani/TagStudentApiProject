// using System;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Http;
// using Xunit;
// using Moq;
// using CreateApi.Controllers;
// using CreateApi.Models;
// using Microsoft.EntityFrameworkCore;

// namespace CreateApiTesting
// {
//     public class CreateControllerTests
//     {
//         [Fact]
//         public void AddStudent_ValidStudent_ReturnsCreatedResult()
//         {
//             // Arrange
//             var dbContext = new Mock<TestDemoContext>();
//             var controller = new CreateController(dbContext.Object);
//             var student = new StudentDatum
//             {
//                 StudentId = "STDN00780",
                
//                 Gender ='M',
//                 Nationlity="indian",
//                 PlaceOfBirth="gadag",
//                 StageId="MiddleSchool",
//                 GradeId="G-09",
//                 SectionId='A',
//                 Topic="dff",
//                 Semester='S',
//                 Relation="Father",
//                 VisitedResources=89,
//                 AnnouncementsView=80,
//                 Discussion=90,
//                 ParentAnsweringSurvey="Yes",
//                 ParentschoolSatisfaction="Good",
//                 StudentAbsenceDays="Under-7",
//                 StudentMarks=78,
//                 Classes='M'
//             };

//             // Act
//             var result = controller.AddStudent(student) as CreatedAtActionResult;

//             // Assert
//             Assert.NotNull(result);
//             Assert.Equal(StatusCodes.Status201Created, result.StatusCode);
//         }

//         [Fact]
//         public void GetByStudentId_ValidId_ReturnsOkResult()
//         {
//             // Arrange
//             var studentId = "STDN00780";
//             var student = new StudentDatum
//             {
//                 StudentId = studentId,
                
//             };

//             var dbContext = new Mock<TestDemoContext>();
//             dbContext.Setup(d => d.StudentData.Find(studentId)).Returns(student);

//             var controller = new CreateController(dbContext.Object);

//             // Act
//             var result = controller.GetByStudentId(studentId) as OkObjectResult;

//             // Assert
//             Assert.NotNull(result);
//             Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
//         }
//     }
// }
