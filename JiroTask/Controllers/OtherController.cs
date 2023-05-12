using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JiroTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherController : ControllerBase
    {
        public readonly IOther _other;
        public OtherController(IOther other)
        {
             _other = other;
        }

        [HttpGet]
        [Route("GetAllLesson")]
        public IActionResult GetAllLesson()
        {
            return Ok(_other.GetAllLesson());
        }

        [HttpGet]
        [Route("GetLessonById/{Id}")]
        public IActionResult GetLessonById(int Id)
        {
            var lesson = _other.GetLesson(Id);
            if (lesson.CodeLesson == null)
                return BadRequest("درس بااین شناسه یافت نشد");
            return Ok(lesson);
        }

        [HttpGet]
        [Route("GetGPAcalculatio/{studentId}")]
        public IActionResult GetGPAcalculatio(int studentId)
        {
            var moadel = _other.GPAcalculation(studentId);
            if (moadel.GPA == null)
                return BadRequest("خطایی رخ داد");

            return Ok(moadel);
        }

    }
}
