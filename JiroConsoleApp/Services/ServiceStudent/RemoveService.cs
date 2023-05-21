using JiroConsoleApp.Initialization;
using JiroConsoleApp.Interfaces.InterfaceStudent;
using System.Linq;

namespace JiroConsoleApp.Services.ServiceStudent
{
    public class RemoveService: IRemoveStudent
    {
        public string RemoveStudent(int studentId)
        {
            Student student = Create.students.FirstOrDefault(s => s.IdStudent == studentId);
            if (student != null)
            {
                bool studentLesson = Create.studentLessons.Any(sl => sl.IdStudent == studentId);
                if (studentLesson == false)
                {
                    Create.students.Remove(student);
                    return "The student was successfully removed";
                }
                else
                {
                    var studentLesson1 = Create.studentLessons.Where(sl => sl.IdStudent == studentId).ToList();
                    bool confirmation = false;
                    int number = 0;
                    foreach (var item in studentLesson1)
                    {
                        Score score = Create.scores.FirstOrDefault(s => s.IdStudentLesson == item.IdStudentLesson);
                        if (score != null)
                        {
                            number++;
                        }
                    }
                    if (number == studentLesson1.Count)
                    {
                        Create.students.Remove(student);
                        return "The student was successfully removed";
                    }
                    else
                    {
                        return "The student cannot be removed until the end of the semester and registration of grades";
                    }
                }
            }
            else
            {
                return "The student ID is wrong";
            }

        }
    }
}
