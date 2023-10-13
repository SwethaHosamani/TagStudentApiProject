




using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using updateapi.Models;

namespace updateapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UpdateController : ControllerBase
    {
        private readonly TestDemoContext _DBContext;

        public UpdateController(TestDemoContext dBContext)
        {
            this._DBContext = dBContext;
        }

        [HttpPut("UpdateStudent/{studentId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateStudent(string studentId, [FromBody] StudentDatum updatedStudent)
        {
            if (updatedStudent == null)
            {
                return BadRequest("Invalid data");
            }

            var existingStudent = _DBContext.StudentData.SingleOrDefault(s => s.StudentId == studentId);

            if (existingStudent == null)
            {
                return NotFound();
            }

            try
            {
                // Update properties of the existing student
                existingStudent.Gender = updatedStudent.Gender;
                existingStudent.Nationlity = updatedStudent.Nationlity;
                existingStudent.PlaceOfBirth = updatedStudent.PlaceOfBirth;
                existingStudent.StageId = updatedStudent.StageId;
                existingStudent.GradeId = updatedStudent.GradeId;
                existingStudent.SectionId = updatedStudent.SectionId;
                existingStudent.Topic = updatedStudent.Topic;
                existingStudent.Semester = updatedStudent.Semester;
                existingStudent.Relation = updatedStudent.Relation;
                existingStudent.RaisedHands = updatedStudent.RaisedHands;
                existingStudent.VisitedResources = updatedStudent.VisitedResources;
                existingStudent.AnnouncementsView = updatedStudent.AnnouncementsView;
                existingStudent.Discussion = updatedStudent.Discussion;
                existingStudent.ParentAnsweringSurvey = updatedStudent.ParentAnsweringSurvey;
                existingStudent.ParentschoolSatisfaction = updatedStudent.ParentschoolSatisfaction;
                existingStudent.StudentAbsenceDays = updatedStudent.StudentAbsenceDays;
                existingStudent.StudentMarks = updatedStudent.StudentMarks;
                existingStudent.Classes = updatedStudent.Classes;

                _DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error occurred while updating the student: {ex.Message}");
            }

            return NoContent();
        }
    }
}
