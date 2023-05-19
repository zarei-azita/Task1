using JiroConsoleApp.Initialization;
using JiroConsoleApp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace JiroConsoleApp.Services
{
    public class OtherServices : IOther
    {
        public List<Lesson> GetAllLesson()
        {
            return Create.lessons;
        }

        public Lesson GetLesson(int id)
        {
            Lesson lesson = new Lesson();
            int index = Create.lessons.FindIndex(l => l.IdLesson == id);
            if (index >= 0)
            {
                lesson = Create.lessons.FirstOrDefault(l => l.IdLesson == id);
                return lesson;
            }
            
            return lesson;          
        }

        public Student GPAcalculation(int studentId)
        {
            Student studentModel = new Student();
            var student = Create.students.SingleOrDefault(s => s.Id == studentId);
            if (student == null)
                return studentModel;

            double? gpa = 0;
            int flag = 0;

            var studentLessons = Create.studentLessons.Where(sl => sl.IdStudent == studentId).ToList();
            foreach (var item in studentLessons)
            {
                var scor = Create.scores.FirstOrDefault(s => s.IdStudentLesson == item.IdStudentLesson);
                if (scor != null)
                {
                    var lesson = Create.lessons.FirstOrDefault(l => l.IdLesson == item.IdLesson);
                    double? scorunit = lesson.NumberUnit * scor.scoreLesson;
                    gpa = gpa + scorunit;
                    flag = flag + lesson.NumberUnit;
                }
            }
            if (gpa == 0)
                return studentModel;

            gpa = gpa / flag;

            int index = Create.students.FindIndex(s => s.Id == studentId);
            Create.students[index].GPA = gpa;

            studentModel.Id = studentId;
            studentModel.StudentId = student.StudentId;
            studentModel.EnteringYear = student.EnteringYear;
            studentModel.MeliCOde = student.MeliCOde;
            studentModel.GPA = gpa;

            return studentModel;
        }

        public List<string> menuHere()
        {
            List<string> lg = new List<string>
            {
                "\nMenu For Other Things:",
                "1- Get All Lesson","2- Get Lesson By Id",
                "3- GPA Calculation",
                "Please Select The Number:"
            };

            return lg;
        }
    }
}
