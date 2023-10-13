// // using System;
// // using System.Collections.Generic;
// // using System.ComponentModel.DataAnnotations;
// // using System.Linq;
// // using Microsoft.AspNetCore.Mvc;
// // using Moq;
// // using updateapi.Controllers;
// // using updateapi.Models;
// // using Xunit;

// // namespace YourTestProjectNamespace
// // {
// //     public class StudentControllerTests
// //     {
// //         [Fact]
// //         public void UpdateStudent_ValidStudent_ReturnsOkResult()
// //         {
// //             // Arrange
// //             var dbContextMock = new Mock<TestDemoContext>();
// //             var controller = new StudentController(dbContextMock.Object);

// //             var existingStudent = new StudentDatum
// //             {
// //                 StudentId = "STDN00005",
// //                 Gender = "M",
                
// //             };

// //             var updatedStudent = new StudentDatum
// //             {
// //                 StudentId = "STDN00005",
// //                 Gender = "F",
                
// //             };

// //             dbContextMock.Setup(m => m.StudentData.FirstOrDefault(s => s.StudentId == "STDN00005"))
// //                         .Returns(existingStudent);

// //             // Act
// //             var result = controller.UpdateStudent(updatedStudent) as OkObjectResult;

// //             // Assert
// //             Assert.NotNull(result);
// //             Assert.Equal(200, result.StatusCode);

// //             var updatedResult = result.Value as StudentDatum;
// //             Assert.NotNull(updatedResult);
// //             Assert.Equal("F", updatedResult.Gender);
// //             // Assert other properties as needed
// //         }

// //         [Fact]
// //         public void UpdateStudent_InvalidData_ReturnsBadRequest()
// //         {
// //             // Arrange
// //             var dbContextMock = new Mock<TestDemoContext>();
// //             var controller = new StudentController(dbContextMock.Object);

// //             var invalidStudent = new StudentDatum
// //             {
                
// //             };

// //             // Act
// //             var result = controller.UpdateStudent(invalidStudent);

// //             // Assert
// //             Assert.IsType<BadRequestObjectResult>(result);
// //         }

// //         [Fact]
// //         public void UpdateStudent_NonExistingStudent_ReturnsNotFound()
// //         {
// //             // Arrange
// //             var dbContextMock = new Mock<TestDemoContext>();
// //             var controller = new StudentController(dbContextMock.Object);

// //             var updatedStudent = new StudentDatum
// //             {
// //                 StudentId = "STDN00005",
// //                 Gender = "F",
               
// //             };

// //             dbContextMock.Setup(m => m.StudentData.FirstOrDefault(s => s.StudentId == "STDN00005"))
// //                         .Returns((StudentDatum)null);

// //             // Act
// //             var result = controller.UpdateStudent(updatedStudent);

// //             // Assert
// //             Assert.IsType<NotFoundObjectResult>(result);
// //         }

// //         // Add more tests for different scenarios...
// //     }
// // }
// using System;
// using Microsoft.AspNetCore.Mvc;
// using Xunit;
// using Moq;
// using updateapi.Controllers;
// using updateapi.Models;

// namespace UpdateApiTests
// {
//     public class UpdateControllerTests
//     {
//         [Fact]
//         public void UpdateStudent_ExistingStudent_ReturnsNoContent()
//         {
//             // Arrange
//             var dbContext = new Mock<TestDemoContext>();
//             var controller = new UpdateController(dbContext.Object);
//             var studentId = "STDN0007";

//             var existingStudent = new StudentDatum
//             {
//                 StudentId = studentId,
                
               
                
//                 Gender ='M',
//                 Nationlity="GHKK",
//                 PlaceOfBirth="GKJHN",
//                 StageId="MiddleSchool",
//                 GradeId="G-07",
//                 SectionId='C',
//                 Topic="KLL",
//                 Semester='S',
//                 Relation="Mum",
//                 RaisedHands=0,
//                 VisitedResources=0,
//                 AnnouncementsView=0,
//                 Discussion=0,
//                 ParentAnsweringSurvey="No",
//                 ParentschoolSatisfaction="Good",
//                 StudentAbsenceDays="Under-7",
//                 StudentMarks=0,
//                 Classes='L'
                
//             };

//             dbContext.Setup(x => x.StudentData.SingleOrDefault(s => s.StudentId == studentId)).Returns(existingStudent);

//             var updatedStudent = new StudentDatum
//             {
//                 StudentId = studentId,
                
//                 Gender ='M',
//                 Nationlity="mjkl",
//                 PlaceOfBirth="hjkl",
//                 StageId="MiddleSchool",
//                 GradeId="G-07",
//                 SectionId='C',
//                 Topic="KLL",
//                 Semester='S',
//                 Relation="Mum",
//                 RaisedHands=0,
//                 VisitedResources=0,
//                 AnnouncementsView=0,
//                 Discussion=0,
//                 ParentAnsweringSurvey="No",
//                 ParentschoolSatisfaction="Good",
//                 StudentAbsenceDays="Under-7",
//                 StudentMarks=0,
//                 Classes='L'
//             };

//             // Act
//             var result = controller.UpdateStudent(studentId, updatedStudent) as NoContentResult;

//             // Assert
//             Assert.NotNull(result);
//             Assert.Equal(StatusCodes.Status204NoContent, result.StatusCode);
//             Assert.Equal(updatedStudent.Gender, existingStudent.Gender);
//             Assert.Equal(updatedStudent.Nationlity, existingStudent.Nationlity);
            

//         [Fact]
//         public void UpdateStudent_NonExistingStudent_ReturnsNotFound()
//         {
//             // Arrange
//             var dbContext = new Mock<TestDemoContext>();
//             var controller = new UpdateController(dbContext.Object);
//             var studentId = "STDN0001";

//             dbContext.Setup(x => x.StudentData.SingleOrDefault(s => s.StudentId == studentId)).Returns((StudentDatum)null);

//             var updatedStudent = new StudentDatum
//             {
//                 StudentId = studentId,
//                  Gender ='M',
//                 Nationlity="mjkl",
//                 PlaceOfBirth="hjkl",
//                 StageId="MiddleSchool",
//                 GradeId="G-07",
//                 SectionId='C',
//                 Topic="KLL",
//                 Semester='S',
//                 Relation="Mum",
//                 RaisedHands=0,
//                 VisitedResources=0,
//                 AnnouncementsView=0,
//                 Discussion=0,
//                 ParentAnsweringSurvey="No",
//                 ParentschoolSatisfaction="Good",
//                 StudentAbsenceDays="Under-7",
//                 StudentMarks=0,
//                 Classes='L'
//             };

//             // Act
//             var result = controller.UpdateStudent(studentId, updatedStudent) as NotFoundResult;

//             // Assert
//             Assert.NotNull(result);
//             Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
//         }
//     }
// }
