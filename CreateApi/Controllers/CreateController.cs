using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CreateApi.Models;
using System.Text.RegularExpressions;


namespace CreateApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateController : ControllerBase
    {
        private readonly TestDemoContext _dbContext;

        public CreateController(TestDemoContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("AddStudent")]
        [ProducesResponseType(typeof(StudentDatum), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddStudent([FromBody] StudentDatum student)
        {
            if (student == null)
            {
                return BadRequest("Invalid data");
            }

            _dbContext.StudentData.Add(student);

            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest("Error occurred while adding the student");
            }

            return CreatedAtAction(nameof(GetByStudentId), new { studentId = student.StudentId }, student);
        }

    
    [HttpGet("GetByStudentId/{studentId}")]
public IActionResult GetByStudentId(string studentId)
{
    // Define a regular expression pattern for the expected format
    string pattern = @"^STDN\d{5}$";

    // Check if studentId matches the pattern
    if (!Regex.IsMatch(studentId, pattern))
    {
        return BadRequest("Invalid Student ID format. It must start with 'STDN' followed by 5 digits.");
    }

    // Find the student by studentId
    var student = _dbContext.StudentData.FirstOrDefault(s => s.StudentId == studentId);

    if (student == null)
    {
        return NotFound("Student not found");
    }

    return Ok(student);
}

      
    }
    }

