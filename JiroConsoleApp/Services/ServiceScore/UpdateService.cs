using JiroConsoleApp.Initialization;
using JiroConsoleApp.Interfaces.InterfaceScore;
using System.Linq;

namespace JiroConsoleApp.Services.ServiceScore
{
    public class UpdateService : IUpdateScore
    {
        public string UpdateScore(Score scoreLesson)
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
