using JiroConsoleApp.Interfaces.InterfaceCourse;
using JiroConsoleApp.Services.ServiceCourse;
using System;

namespace JiroConsoleApp.Menu
{
    public static class MenuAddLesson
    {
        public static void Lesson()
        {
            try
            {
                Console.WriteLine("please enter the Id number for Lesson:");
                int Id = int.Parse(Console.ReadLine());
                Console.WriteLine("please enter the Id for Professor:");
                int IdPro = int.Parse(Console.ReadLine());
                Console.WriteLine("please enter the  Lesson's Name:");
                string LessonName = Console.ReadLine();
                Console.WriteLine("please enter the  Lesson's Code:");
                string LessonCode = Console.ReadLine();
                Console.WriteLine("Please enter the number of course unit:");
                int Unit = int.Parse(Console.ReadLine());
                Console.WriteLine("please enter Lesson's Capacity:");
                int Capacity = int.Parse(Console.ReadLine());

                IAddLesson addLesson = new AddService();

                Lesson lesson = new Lesson()
                {
                    IdLesson = Id,
                    Name = LessonName,
                    Code = LessonCode,
                    NumberUnit = Unit,
                    Capacity = Capacity
                };
                ProffesorLesson proffesorLesson = new ProffesorLesson()
                {
                    IdLesson = Id,
                    IdProffor = IdPro,
                };

                string l = addLesson.AddLesson(lesson, IdPro);
                Console.WriteLine(l);
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
