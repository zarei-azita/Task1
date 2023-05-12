using Data.Interfaces;
using Data.Model;
using Entities;
using Entities.DB;

namespace Data.Services
{
    public class StudentServices:IStudent
    {
        private MyDBContext _context;
        public StudentServices(MyDBContext context)
        {
            _context = context;
        }

        public string AddStudent(StudentDto student)
        {
            var stu = _context.Students.SingleOrDefault(s => s.Id == student.Id);
            if(stu != null)
            {
                return "دانشجو با این شناسه از قبل وجود دارد";
            }

            Student Newstudent = new Student()
            {
                Id = student.Id,
                EnteringYear = student.EnteringYear,
                MeliCOde = student.MeliCOde,
                StudentId = student.StudentId,
                GPA = student.GPA
            };

            _context.Students.Add(Newstudent);
            _context.SaveChanges();
            return "دانشجو " + student.Id + " به لیست اضافه شد";
        }

        public string AddStudentLesson(StudentLessonDto studentLesson)
        {
            bool student = _context.Students.Any(s => s.Id == studentLesson.StudentId);
            if (student == false)
                return "دانشجویی بااین شناسه" + studentLesson.StudentId + "پیدا نشد";
            bool lesson = _context.Lessons.Any(s => s.Id == studentLesson.LessonId);
            if (lesson == false)
                return "درسی بااین شناسه" + studentLesson.LessonId + "پیدا نشد";

            var studentLess1 = _context.StudentLessons.Any(sl => sl.Id == studentLesson.Id);
            if (studentLess1 == true)
                return "شناسه وارد شده برای Id از قبل وجود دارد";
            var studentLess2 = _context.StudentLessons.SingleOrDefault(sl => sl.StudentId == studentLesson.StudentId && sl.LessonId == studentLesson.LessonId);
            if (studentLess2 != null)
                return "دانشجو قبلا این درس را گرفته است";

            StudentLesson NewStudentLesson = new StudentLesson()
            {
                Id = studentLesson.Id,
                LessonId = studentLesson.LessonId,
                StudentId = studentLesson.StudentId
            };

            _context.StudentLessons.Add(NewStudentLesson);
            _context.SaveChanges();

            return "درس مورد نظر برای شما ثبت شد";
        }

        public List<Student> GetAllStudent()
        {
            return _context.Students.OrderBy(s=> s.Id).ToList();
        }

        public List<LessonStudentDto> GetLessonsForStudent(int studentID)
        {
            List<LessonStudentDto> listSL = new List<LessonStudentDto>();
            var studentLessons = _context.StudentLessons.Where(sl=>sl.StudentId == studentID).ToList();
            var student = _context.Students.SingleOrDefault(sl => sl.Id == studentID);
            
            foreach (var item in studentLessons)
            {
                var lesson = _context.Lessons.SingleOrDefault(l => l.Id == item.LessonId);
                LessonStudentDto lesson1 = new LessonStudentDto()
                {
                    Id = item.Id,
                    NumberStudent = student.StudentId,
                    CodeLesson = lesson.Code,
                    UnitLesson = lesson.Unit,
                    GPA = student.GPA
                };
                listSL.Add(lesson1);
            }
            return listSL;
        }

        public List<ScorLessonForStudentDto> GetScoreLesson(int studentID)
        {
            List<ScorLessonForStudentDto> scorLessonForStudents = new List<ScorLessonForStudentDto>();
            var listLesson = _context.StudentLessons.Where(sl=>sl.StudentId == studentID).ToList();
            foreach (var item in listLesson)
            {
                var scor = _context.Scores.SingleOrDefault(s => s.StudentLessonId == item.Id);
                if(scor != null)
                {
                    ScorLessonForStudentDto scor1 = new ScorLessonForStudentDto()
                    {
                        Id = scor.Id,
                        lessonId = item.LessonId,
                        ScoreLesson = scor.ScoreLesson
                    };
                    scorLessonForStudents.Add(scor1);
                }
            }
            return scorLessonForStudents;
        }

        public StudentDto GetStudent(int id)
        {
            StudentDto studentDto = new StudentDto();
            var student = _context.Students.SingleOrDefault(s => s.Id == id);
            if (student == null)
                return studentDto;

            studentDto.EnteringYear = student.EnteringYear;
            studentDto.MeliCOde = student.MeliCOde;
            studentDto.StudentId = student.StudentId;
            studentDto.GPA = student.GPA;
            studentDto.Id = student.Id;

            return studentDto;
        }
    }
}
