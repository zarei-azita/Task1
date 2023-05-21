using JiroConsoleApp.Initialization;
using JiroConsoleApp.Interfaces.InterfaceScore;
using System.Linq;

namespace JiroConsoleApp.Services.ServiceScore
{
    public class AddService : IAddScore
    {
        private static int IdScore = 1;

        public string AddScore(Score scoreLesson)
        {
            bool student = Create.students.Any(s => s.IdStudent == scoreLesson.IdStudent);
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
                IdStudent = scoreLesson.IdStudent,
                IdLesson = scoreLesson.IdLesson,
                IdStudentLesson = studentLesson.IdStudentLesson,
                IdScore = IdScore,
                scoreLesson = scoreLesson.scoreLesson
            };
            Create.scores.Add(score);

            IdScore = IdScore + 1;

            return "A grade was recorded for the student";
        }
    }
}
