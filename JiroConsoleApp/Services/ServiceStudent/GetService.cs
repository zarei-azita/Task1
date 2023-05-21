using JiroConsoleApp.Initialization;
using JiroConsoleApp.Interfaces.InterfaceStudent;
using System;
using System.Linq;

namespace JiroConsoleApp.Services.ServiceStudent
{
    public class GetService: IGetStudent
    {
        public void GetStudent()
        {
            try
            {
                Console.WriteLine("please enter the student Id number:");
                int id = int.Parse(Console.ReadLine());

                Student student = new Student();
                int index = Create.students.FindIndex(s => s.IdStudent == id);
                if (index >= 0)
                {
                    student = Create.students.FirstOrDefault(s => s.IdStudent == id);
                    Console.WriteLine("Your student number is " + Convert.ToString(student.IdStudent));
                    Console.WriteLine("Student Name: " + student.Code);
                    Console.WriteLine("Student Code: " + student.Code);
                    Console.WriteLine("Entering Year: " + student.EnteringYear);
                    Console.WriteLine("National Code: " + student.MeliCOde);
                    Console.WriteLine("GPA: " + student.GPA + "\n");
                }
                else
                {
                    Console.WriteLine("No students were found with this ID \n");
                }

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
