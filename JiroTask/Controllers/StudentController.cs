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

        [HttpGet]
        [Route("GetStudentById/{ID}")]
        public IActionResult GetStudentById(int ID)
        {
            var student = _student.GetStudent(ID);
            if (student.StudentId == null)
                return BadRequest("دانشجو بااین شناسه یافت نشد");
            return Ok(student);
        }

        [HttpPost]
        [Route("TakingLessons")]
        public IActionResult TakingLessons(StudentLessonDto studentLesson)
        {
            string stuLes = _student.AddStudentLesson(studentLesson);
            return Ok(stuLes);
        }

        [HttpGet]
        [Route("GetStudentsLessons/{studentId}")]
        public IActionResult GetStudentsLessons(int studentId)
        {
            var lessons  = _student.GetLessonsForStudent(studentId);
            return Ok(lessons);
        }

        [HttpGet]
        [Route("GetScorsLesson/{studentId}")]
        public IActionResult GetScorsLesson(int studentId)
        {
            var scors = _student.GetScoreLesson(studentId);
            return Ok(scors);
        }

    }
}
