using JiroConsoleApp.Interfaces.InterfaceStudent;
using JiroConsoleApp.Services.ServiceStudent;
using System;

namespace JiroConsoleApp.Menu
{
    public static class MenuAddStudent
    {
        public static void StudentAdd()
        {
            try
            {
                Console.WriteLine("please enter the Id number for student:");
                int Id = int.Parse(Console.ReadLine());
                Console.WriteLine("please enter Student's national code:");
                string meli = Console.ReadLine();
                Console.WriteLine("please enter the Student Name :");
                string studentName = Console.ReadLine();
                Console.WriteLine("please enter the Student Code :");
                string studentCode = Console.ReadLine();
                Console.WriteLine("please enter the EnteringYear :");
                string EnteringYear = Console.ReadLine();

                IAddStudent studentAdd = new AddService();
                Student student = new Student
                {
                    IdStudent = Id,
                    GPA = null,
                    MeliCOde = meli,
                    Name = studentName,
                    Code = studentCode,
                    EnteringYear = EnteringYear,
                };

                string s = studentAdd.AddStudent(student);
                Console.WriteLine(s);
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
