using JiroConsoleApp.Initialization;
using JiroConsoleApp.Interfaces.InterfaceCourse;
using System;
using System.Linq;

namespace JiroConsoleApp.Services.ServiceCourse
{
    public class GetService : IGetLessonById
    {
        public void GetLesson()
        {
            try
            {
                Console.WriteLine("please enter the Lesson Id:");
                int IdLesson = int.Parse(Console.ReadLine());

                int index = Create.lessons.FindIndex(l => l.IdLesson == IdLesson);
                if (index >= 0)
                {
                    Lesson lesson = Create.lessons.FirstOrDefault(l => l.IdLesson == IdLesson);

                    Console.WriteLine("Leeson Id: " + lesson.IdLesson);
                    Console.WriteLine("Lesson Name: " + lesson.Name);
                    Console.WriteLine("Lesson Code: " + lesson.Code);
                    Console.WriteLine("The number of  unit: " + lesson.NumberUnit);
                    Console.WriteLine("Lesson Capacity: " + lesson.Capacity + "\n");
                }
                else
                {
                    Console.WriteLine("No lessons were found with this ID \n");
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
