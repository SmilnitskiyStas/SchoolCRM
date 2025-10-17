using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolCrmApi.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public StudentsController()
        {
            
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = new[]
            {
                new { Id = 1, Name = "Alice Johnson", Age = 20 },
                new { Id = 2, Name = "Bob Smith", Age = 22 },
                new { Id = 3, Name = "Charlie Brown", Age = 19 }
            };
            return Ok(students);
        }
    }
}
