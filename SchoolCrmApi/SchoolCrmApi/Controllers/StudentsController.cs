using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolCrmApi.Models;
using SchoolCrmApi.Services.IServices;

namespace SchoolCrmApi.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            var createdStudent = await _studentService.AddAsync(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.Id }, createdStudent);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            var existingStudent = await _studentService.GetByIdAsync(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            var updatedStudent = await _studentService.UpdateAsync(student);
            return Ok(updatedStudent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var existingStudent = await _studentService.GetByIdAsync(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            var result = await _studentService.DeleteAsync(id);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting student");
            }
        }
    }
}
