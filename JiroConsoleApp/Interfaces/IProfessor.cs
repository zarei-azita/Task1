using JiroConsoleApp.Initialization;
using System.Collections.Generic;
using System.Linq;

namespace JiroConsoleApp.Interfaces
{
    public interface IProfessor
    {
        List<string> menuHere();
        string AddScore(Score scoreLesson);
        string UpdateScore(Score scoreLesson);
    }

    public class ServiceForProfessor : IProfessor
    {
        private static int IdScore = 1;

        public string AddScore(Score scoreLesson)
        {
            bool student = Create.students.Any(s => s.Id == scoreLesson.IdStudent);
            if (student == false)
                return "There are no students with this ID";
            bool lesson = Create.lessons.Any(l => l.IdLesson == scoreLesson.IdLesson);
            if (lesson == false)
                return "No Lesson have been registered with this ID";

            var studentLesson = Create.studentLessons.SingleOrDefault(sl => sl.IdLesson == scoreLesson.IdLesson && sl.IdStudent == scoreLesson.IdStudent);
            if (studentLesson == null)
                return "This Lesson is not registered for the student";

            bool scor1 = Create.scores.Any(s => s.IdStudentLesson == scoreLesson.IdStudentLesson);
            if (scor1 == true)
                return "The student's grade for this lesson has already been recorded";

            Score score = new Score()
            {
                IdStudentLesson = studentLesson.IdStudentLesson,
                IdScore = IdScore,
                scoreLesson = scoreLesson.scoreLesson
            };
            Create.scores.Add(score);

            IdScore = IdScore + 1;

            return "A grade was recorded for the student";
        }

        public List<string> menuHere()
        {
            List<string> sl = new List<string>
            {
                "\nMenu for Score:",
                "1- Add Score","2- Update Score",
                "Please Select The Number:"
            };

            return sl;
        }

        public string UpdateScore(Score scoreLesson)
        {
            bool student = Create.students.Any(s => s.Id == scoreLesson.IdStudent);
            if (student == false)
                return "There are no students with this ID";
            bool lesson = Create.lessons.Any(l => l.IdLesson == scoreLesson.IdLesson);
            if (lesson == false)
                return "No Lesson have been registered with this ID";

            var studentLesson = Create.studentLessons.SingleOrDefault(sl => sl.IdLesson == scoreLesson.IdLesson && sl.IdStudent == scoreLesson.IdStudent);
            if (studentLesson == null)
                return "This Lesson is not registered for the student";

            int index = Create.scores.FindIndex(s => s.IdStudentLesson == studentLesson.IdStudentLesson);
            if (index >= 0)
            {
                Create.scores[index].scoreLesson = scoreLesson.scoreLesson;
                return "The student's grade was successfully changed";
            }              
            else
            {
                return "The grade of this lesson has not been recorded. Please use the Add Score menu";
            }
        }
    }
}
