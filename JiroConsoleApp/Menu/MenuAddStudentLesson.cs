using JiroConsoleApp.Interfaces.InterfaceStudentLesson;
using JiroConsoleApp.Services.ServiceStudentLesson;
using System;

namespace JiroConsoleApp.Menu
{
    public static class MenuAddStudentLesson
    {
        public static void StudentLesson()
        {
            try
            {
                Console.WriteLine("please enter the Id number for StudentLesson:");
                int Id = int.Parse(Console.ReadLine());
                Console.WriteLine("please enter the Id for Student:");
                int IdStu = int.Parse(Console.ReadLine());
                Console.WriteLine("please enter the Id for Lesson:");
                int IdLess = int.Parse(Console.ReadLine());

                IAddStudentLesson studentLesson = new AddService();

                StudentLesson studentLes = new StudentLesson()
                {
                    IdStudentLesson = Id,
                    IdStudent = IdStu,
                    IdLesson = IdLess,
                };

                string sl = studentLesson.AddStudentLesson(studentLes);
                Console.WriteLine(sl);
            }
            catch (FormatException)
            {
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Error : Please Enter Only Integers");
                Console.ResetColor();
            }  
        }
    }
}
