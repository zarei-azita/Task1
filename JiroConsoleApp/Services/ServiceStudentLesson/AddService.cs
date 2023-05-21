using JiroConsoleApp.Initialization;
using JiroConsoleApp.Interfaces.InterfaceStudentLesson;

namespace JiroConsoleApp.Services.ServiceStudentLesson
{
    public class AddService: IAddStudentLesson
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

    }
}
