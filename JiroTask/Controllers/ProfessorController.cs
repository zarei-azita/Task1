using Data.Interfaces;
using Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace JiroTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        public readonly IProfessor _professor;
        public ProfessorController(IProfessor professor)
        {
            _professor = professor;
        }

        [HttpPost]
        [Route("AddProfessor")]
        public IActionResult AddProfessor(ProfessorDto professor)
        {
            string p = _professor.AddProfessor(professor);
            return Ok(p);
        }

        [HttpGet]
        [Route("GetAllProfessor")]
        public IActionResult GetAllProfessor()
        {
            return Ok(_professor.GetAllProfessor());
        }

        [HttpGet]
        [Route("GetProfessorById/{ID}")]
        public IActionResult GetProfessorById(int ID)
        {
            var professor = _professor.GetProfessor(ID);
            if (professor.Name == null)
                return BadRequest("مدرس بااین شناسه یافت نشد");
            return Ok(professor);
        }

        [HttpPost]
        [Route("AddLesson")]
        public IActionResult AddLesson(LessonDto lesson)
        {
            string les = _professor.AddLesson(lesson);
            return Ok(les);
        }

        [HttpGet]
        [Route("GetProfessorsLessons/{IdProfessor}")]
        public IActionResult GetProfessorsLessons(int IdProfessor)
        {
            return Ok(_professor.GetLessons(IdProfessor));
        }

        [HttpPost]
        [Route("CreateScoreForStudent")]
        public IActionResult CreateScoreForStudent(ScoreLessonDto scoreLesson)
        {
            string scor = _professor.AddScore(scoreLesson);
            return Ok(scor);
        }

        [HttpPost]
        [Route("UpdateScoreForStudent")]
        public IActionResult UpdateScoreForStudent(ScoreLessonDto scoreLesson)
        {
            string Upscor = _professor.UpdateScore(scoreLesson);
            return Ok(Upscor);
        }
    }
}
