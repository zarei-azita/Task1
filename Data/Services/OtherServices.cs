using Data.Interfaces;
using Data.Model;
using Entities;
using Entities.DB;

namespace Data.Services
{
    public class OtherServices : IOther
    {
        private MyDBContext _context;
        public OtherServices(MyDBContext context)
        {
            _context = context;
        }
        public List<Lesson> GetAllLesson()
        {
            return _context.Lessons.OrderBy(l=>l.Id).ToList();
        }

        public LessonDto GetLesson(int id)
        {
            LessonDto lessonDto = new LessonDto();
            var lesson = _context.Lessons.SingleOrDefault(l => l.Id == id);
            if (lesson == null)
                return lessonDto;

            lessonDto.Id = lesson.Id;
            lessonDto.ProfessorId = lesson.ProfessorId;
            lessonDto.CodeLesson = lesson.Code;
            lessonDto.Capacity = lesson.Capacity;
            lessonDto.NumberUnitLesson = lesson.Unit;

            return lessonDto;
        }

        public StudentDto GPAcalculation(int studentId)
        {
            StudentDto studentDto = new StudentDto();
            var student = _context.Students.SingleOrDefault(s => s.Id == studentId);
            if (student == null)
                return studentDto;

            double gpa = 0;
            int flag = 0;

            var studentLessons = _context.StudentLessons.Where(sl=>sl.StudentId == studentId).ToList();
            foreach (var item in studentLessons)
            {
                var scor = _context.Scores.FirstOrDefault(s => s.StudentLessonId == item.Id);
                if(scor != null)
                {
                    var lesson = _context.Lessons.FirstOrDefault(l => l.Id == item.LessonId);
                    double scorunit = lesson.Unit * scor.ScoreLesson;
                    gpa = gpa + scorunit;
                    flag = flag + lesson.Unit;
                }
            }
            if(gpa == 0)
                return studentDto;

            gpa = gpa / flag;

            student.GPA = gpa;
            _context.SaveChanges();

            studentDto.Id = studentId;
            studentDto.StudentId = student.StudentId;
            studentDto.EnteringYear = student.EnteringYear;
            studentDto.MeliCOde = student.MeliCOde;
            studentDto.GPA = gpa;

            return studentDto;
        }
    }
}
