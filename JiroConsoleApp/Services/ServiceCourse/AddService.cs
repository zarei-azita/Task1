using JiroConsoleApp.Initialization;
using JiroConsoleApp.Interfaces.InterfaceCourse;
using System.Linq;

namespace JiroConsoleApp.Services.ServiceCourse
{
    public class AddService: IAddLesson
    {
        public string AddLesson(Lesson lesson, int IdProffesor)
        {
            int index = Create.lessons.FindIndex(l => l.IdLesson == lesson.IdLesson);
            bool pro = Create.professors.Any(l => l.IdProfessor == IdProffesor);
            if (index >= 0 || pro == false)
            {
                return "The course or professor ID is wrong";
            }
            else
            {
                Create.lessons.Add(lesson);
                ProffesorLesson proffesorLesson = new ProffesorLesson()
                {
                    IdLesson = lesson.IdLesson,
                    IdProffor = IdProffesor
                };
                Create.proffesorLessons.Add(proffesorLesson);
                return "The lesson has been successfully added to the list";
            }
           
        }
    }
}
