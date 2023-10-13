using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using ReadApi.Models;

namespace ReadApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ReadController : ControllerBase
{
   

    private readonly TestDemoContext _DBContext;

    public ReadController(TestDemoContext dBContext)
    {
        this._DBContext=dBContext;
    }

    

    [HttpGet("GetAll")]
public IActionResult GetAll()
{
    var students = this._DBContext.StudentData.ToList();

    if (students == null || students.Count == 0)
    {
        return NotFound("No students found");
    }

    return Ok(students);
}




[HttpGet("GetByStudentId/{studentId}")]
public IActionResult GetByStudentId(string studentId)
{
    var student = _DBContext.StudentData.FirstOrDefault(s => s.StudentId == studentId);

    if (student == null)
    {
        return NotFound();
    }

    return Ok(student);
}
}










    



   


   
 








        


