using JiroConsoleApp.Initialization;
using JiroConsoleApp.Model;
using System.Collections.Generic;
using System.Linq;

namespace JiroConsoleApp.Interfaces
{
    public interface IStudent
    {
        List<string> menuHere();
        string AddStudentLesson(StudentLesson studentLesson);
        List<Score> GetScoreLesson(int studentID);
        List<LessonStudentOutPut> GetStudentLessons(int studentID);
    }

    public class ServiceForStudent : IStudent
    {
        public string AddStudentLesson(StudentLesson studentLesson)
        {
            int index = Create.studentLessons.FindIndex(s => s.IdStudentLesson == studentLesson.IdStudentLesson);
            if (index >= 0)
            {
                return "This StudentLessonID has already been added";
            }
            else
            {
                Create.studentLessons.Add(studentLesson);
                return "The student has been successfully added to the list";
            }
        }

        public List<Score> GetScoreLesson(int studentID)
        {
            List<Score> scores = new List<Score>();
            var listSL = Create.studentLessons.FindAll(s => s.IdStudentLesson == studentID);
            foreach (var item in listSL)
            {
                Score score = Create.scores.FirstOrDefault(s => s.IdStudentLesson == item.IdStudentLesson);
                if(score != null)
                {
                    scores.Add(score);
                }
            }
            return scores;
        }

        public List<LessonStudentOutPut> GetStudentLessons(int studentID)
        {
            List<LessonStudentOutPut> lessonStudentOuts = new List<LessonStudentOutPut>();
            var listSL = Create.studentLessons.Where(sl => sl.IdStudent == studentID).ToList();
            Student student = Create.students.FirstOrDefault(s => s.Id == studentID);

            foreach (var item in listSL)
            {
                var scor = Create.scores.FirstOrDefault(s => s.IdStudentLesson == item.IdStudentLesson);
                var lesson = Create.lessons.FirstOrDefault(l => l.IdLesson == item.IdLesson);
                if(scor != null)
                {
                    LessonStudentOutPut lessonStudentOutPut = new LessonStudentOutPut()
                    {
                        IdLesson = lesson.IdLesson,
                        CodeLesson = lesson.CodeLesson,
                        NumberUnit = lesson.NumberUnit,
                        scoreLesson = scor.scoreLesson,
                        StudentCode = student.StudentId,
                        GPA = student.GPA
                    };
                    lessonStudentOuts.Add(lessonStudentOutPut);
                }
                else
                {
                    LessonStudentOutPut lessonStudentOutPut = new LessonStudentOutPut()
                    {
                        IdLesson = lesson.IdLesson,
                        CodeLesson = lesson.CodeLesson,
                        NumberUnit = lesson.NumberUnit,
                        scoreLesson = null,
                        StudentCode = student.StudentId,
                        GPA = student.GPA
                    };
                    lessonStudentOuts.Add(lessonStudentOutPut);
                }
            }

            return lessonStudentOuts;
        }

        public List<string> menuHere()
        {
            List<string> sl = new List<string>
            {
                "\nMenu for StudentLessons:",
                "1- By the student, taking lessons","2- see grades of lessons",
                "3- Get Student Lessons by studentId",
                "Please Select The Number:"
            };

            return sl;
        }

    }

}
