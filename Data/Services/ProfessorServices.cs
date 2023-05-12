using Data.Interfaces;
using Data.Model;
using Entities;
using Entities.DB;

namespace Data.Services
{
    public class ProfessorServices :IProfessor
    {
        private MyDBContext _context;
        private static int IdScore = 1;

        public ProfessorServices(MyDBContext context)
        {
            _context = context;
        }

        public string AddLesson(LessonDto lesson)
        {
            var Lesson1 = _context.Lessons.SingleOrDefault(l => l.Id == lesson.Id);
            if (Lesson1 != null)
            {
                return "درس با این شناسه از قبل وجود دارد";
            }
            bool p = _context.Professors.Any(p => p.Id == lesson.ProfessorId);
            if(p == false)
            {
                return "مدرس با شناسه " + lesson.ProfessorId + "در مجموعه داده ما وجود ندارد";
            }

            Lesson NewLesson = new Lesson()
            {
                Id = lesson.Id,
                Capacity = lesson.Capacity,
                ProfessorId = lesson.ProfessorId,
                Code = lesson.CodeLesson,
                Unit = lesson.NumberUnitLesson
            };

            _context.Lessons.Add(NewLesson);
            _context.SaveChanges();
            return "درس با شناسه " + lesson.Id + " به لیست اضافه شد";
        }

        public string AddProfessor(ProfessorDto professor)
        {
            var pro = _context.Professors.SingleOrDefault(s => s.Id == professor.Id);
            if (pro != null)
            {
                return "مدرس با این شناسه از قبل وجود دارد";
            }

            Professor NewProfessor = new Professor()
            {
                Id = professor.Id,
                AcademicRank = professor.AcademicRank,
                Code = professor.Code,
                Name = professor.Name,
                Number_units_taught_so_far = professor.Number_units
            };

            _context.Professors.Add(NewProfessor);
            _context.SaveChanges();
            return "مدرس با شناسه " + professor.Id + " به لیست اضافه شد";
        }

        public string AddScore(ScoreLessonDto scoreLesson)
        {
            bool student = _context.Students.Any(s => s.Id == scoreLesson.IdStudent);
            if (student == false)
                return "دانشجویی بااین شناسه وجود ندارد";
            bool lesson = _context.Lessons.Any(l => l.Id == scoreLesson.IdLessson);
            if (lesson == false)
                return "درسی بااین شناسه ثبت نشده است";

            var studentLesson = _context.StudentLessons.SingleOrDefault(sl => sl.LessonId == scoreLesson.IdLessson && sl.StudentId == scoreLesson.IdStudent);
            if (studentLesson == null)
                return "این درس برای دانشجو ثبت نشده است";

            bool scor1 = _context.Scores.Any(s => s.StudentLessonId == studentLesson.Id);
            if (scor1 == true)
                return "نمره برای این درس دانشجو از قبل ثبت شده است";

            Score score = new Score()
            {
                Id = IdScore,
                StudentLessonId = studentLesson.Id,
                ScoreLesson = scoreLesson.Score
            };
            _context.Scores.Add(score);
            _context.SaveChanges();

            IdScore = IdScore + 1;

            return "نمره برای دانشجو ثبت گردید";        
        }

        public List<Professor> GetAllProfessor()
        {
            return _context.Professors.OrderBy(p => p.Id).ToList();
        }

        public List<Lesson> GetLessons(int IDprofessor)
        {
            return _context.Lessons.Where(l => l.ProfessorId == IDprofessor).OrderBy(l=>l.Id).ToList();
        }

        public ProfessorDto GetProfessor(int id)
        {
            ProfessorDto professorDto = new ProfessorDto();
            var professor = _context.Professors.SingleOrDefault(p => p.Id == id);
            if (professor == null)
                return professorDto;

            professorDto.AcademicRank = professor.AcademicRank;
            professorDto.Code = professor.Code;
            professorDto.Id = professor.Id;
            professorDto.Name = professor.Name;
            professorDto.Number_units = professor.Number_units_taught_so_far;

            return professorDto;

        }

        public string UpdateScore(ScoreLessonDto scoreLesson)
        {
            bool student = _context.Students.Any(s => s.Id == scoreLesson.IdStudent);
            if (student == false)
                return "دانشجویی بااین شناسه وجود ندارد";
            bool lesson = _context.Lessons.Any(l => l.Id == scoreLesson.IdLessson);
            if (lesson == false)
                return "درسی بااین شناسه ثبت نشده است";

            var studentLesson = _context.StudentLessons.SingleOrDefault(sl => sl.LessonId == scoreLesson.IdLessson && sl.StudentId == scoreLesson.IdStudent);
            if (studentLesson == null)
                return "این درس برای دانشجو ثبت نشده است";

            var scor1 = _context.Scores.SingleOrDefault(s => s.StudentLessonId == studentLesson.Id);
            if (scor1 == null)
                return "نمره برای این درس دانشجو ثبت نشده لطفا از منوی اضافه کردن نمره استفاده کنید";

            scor1.ScoreLesson = scoreLesson.Score;

            _context.SaveChanges();

            return "نمره دانشجو با موفقیت تغییر یافت";
        }
    }
}
