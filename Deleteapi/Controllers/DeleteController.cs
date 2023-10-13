using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Deleteapi.Models;
using System;
using System.Linq;

namespace Deleteapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteController : ControllerBase
    {
        private readonly TestDemoContext _DBContext;

        public DeleteController(TestDemoContext dBContext)
        {
            this._DBContext = dBContext;
        }

        [HttpDelete("DeleteByStudentId/{studentId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteByStudentId(string studentId)
        {
            var student = _DBContext.StudentData.SingleOrDefault(s => s.StudentId == studentId);

            if (student != null)
            {
                _DBContext.StudentData.Remove(student);
                _DBContext.SaveChanges();
                return NoContent();
            }

            return NotFound();
        }
    }
}
