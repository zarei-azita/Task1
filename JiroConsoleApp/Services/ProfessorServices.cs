using JiroConsoleApp.Initialization;
using System.Collections.Generic;
using System.Linq;

namespace JiroConsoleApp.Services
{
    public class ProfessorServices 
    {
        public List<string> Pro()
        {
            List<string> p = new List<string>
            {
                "\nMenu for Professor:",
                "1- add Professor","2- get all Professor",
                "3- get Professor by Id","4- add Lesson",
                "5- get all lesson by ProfesorId",
                "Please Select The Number:"
            };

            return p;
        }

        public string AddLesson(Lesson lesson)
        {
            int index = Create.lessons.FindIndex(l => l.IdLesson == lesson.IdLesson);
            bool pro = Create.professors.Any(l => l.IdProfessor == lesson.IdProfessor);
            if (index >= 0 || pro == false)
            {
                return "The course or professor ID is wrong";
            }
            else
            {
                Create.lessons.Add(lesson);
                return "The lesson has been successfully added to the list";
            }
        }

        public string AddProfessor(Professor professor)
        {
            int index = Create.professors.FindIndex(p => p.IdProfessor == professor.IdProfessor);
            if (index >= 0)
            {
                return "A professor with this ID has already been added";
            }
            else
            {
                Create.professors.Add(professor);
                return "The professor has been successfully added to the list";
            }
        }

        public List<Professor> GetAllProfessor()
        {
            return Create.professors;
        }

        public List<Lesson> GetLessons(int IDprofessor)
        {
            List<Lesson> lessons = Create.lessons.Where(l => l.IdProfessor == IDprofessor).ToList();
            return lessons;
        }

        public Professor GetProfessor(int id)
        {
            Professor professor = new Professor();
            int index = Create.professors.FindIndex(p => p.IdProfessor == id);
            if (index >= 0)
            {
                professor = Create.professors.FirstOrDefault(p => p.IdProfessor == id);
                return professor;
            }
            else
            {
                return professor;
            }
        }
    }

}
