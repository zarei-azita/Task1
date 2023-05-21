using JiroConsoleApp.Initialization;
using JiroConsoleApp.Interfaces.InterfaceCourse;
using System;
using System.Linq;

namespace JiroConsoleApp.Services.ServiceCourse
{
    public class GetByIdProffesorService : IGetLessonByIdProffesor
    {
        public void GetLessonsByIdProffesor()
        {
            try
            {
                Console.WriteLine("please enter the Professor Id number:");
                int Idprof = int.Parse(Console.ReadLine());

                var proffesorLessons = Create.proffesorLessons.Where(pl => pl.IdProffor == Idprof).ToList();
                if (proffesorLessons.Count != 0)
                {
                    foreach (var item in proffesorLessons)
                    {
                        Lesson lesson = Create.lessons.FirstOrDefault(l => l.IdLesson == item.IdLesson);

                        Console.WriteLine("Lesson Id:" + Convert.ToString(lesson.IdLesson));
                        Console.WriteLine("Lesson Name: " + lesson.Name);
                        Console.WriteLine("Lesson Code: " + lesson.Code);
                        Console.WriteLine("Number of course unit: " + lesson.NumberUnit);
                        Console.WriteLine("Lesson Capacity: " + lesson.Capacity + "\n");
                    }
                }
                else
                {
                    Console.WriteLine("The Professor you are looking for has not offered a lesson \n");
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
