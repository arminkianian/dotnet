using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPIWithRedisDB.Data;
using StudentAPIWithRedisDB.Models;

namespace StudentAPIWithRedisDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet("{Id}", Name = "GetStudentById")]
        public ActionResult<Student> GetStudentById(string Id)
        {
            var student = _studentRepository.GetStudentById(Id);

            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> AddStudent(Student student)
        {
            _studentRepository.AddStudent(student);
            return CreatedAtRoute(nameof(GetStudentById), new { Id = student.Id }, student);
        }

        [HttpGet(Name = "GetAllStudents")]
        public ActionResult<Student> GetAllStudents()
        {
            var students = _studentRepository.GetAllStudents();
            return Ok(students);
        }

        [HttpDelete("{id}")]
        public ActionResult<Student> DeleteStudent(string id)
        {
            var student = _studentRepository.DeleteStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPatch]
        public ActionResult<Student> UpdateStudent(Student student)
        {
            var studentToUpdate = _studentRepository.GetStudentById(student.Id);
            if (studentToUpdate == null)
            {
                return NotFound();
            }
            _studentRepository.UpdateStudent(student);
            return NoContent();
        }
    }
}