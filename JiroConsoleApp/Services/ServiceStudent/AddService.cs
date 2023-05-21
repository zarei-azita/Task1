using JiroConsoleApp.Initialization;
using JiroConsoleApp.Interfaces.InterfaceStudent;

namespace JiroConsoleApp.Services.ServiceStudent
{
    public class AddService:IAddStudent
    {
        public string AddStudent(Student student)
        {
            int index = Create.students.FindIndex(s => s.IdStudent == student.IdStudent);
            if (index >= 0)
            {
                return "A student with this ID has already been added";
            }
            else
            {
                Create.students.Add(student);
                return "The student has been successfully added to the list";
            }
        }
    }
}
