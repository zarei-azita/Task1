using Data.Interfaces;
using Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace JiroTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly IStudent _student;
        public StudentController(IStudent student)
        {
            _student = student;
        }

        [HttpPost]
        [Route("AddStudent")]
        public IActionResult AddStudent(StudentDto student)
        {
            string s = _student.AddStudent(student);
            return Ok(s);
        }

        [HttpGet]
        [Route("GetAllStudent")]
        public IActionResult GetAllStudent()
        {
            return Ok(_student.GetAllStudent());
        }
    }
}
