using JiroConsoleApp.Interfaces.InterfaceCourse;
using JiroConsoleApp.Menu;
using JiroConsoleApp.Services.ServiceCourse;
using System;

namespace JiroConsoleApp.Method
{
    public class MethodLesson
    {
        public static void LessonM()
        {
            Console.WriteLine("\nLesson Menu:");
            Console.WriteLine("1- add Lesson");
            Console.WriteLine("2- get all Lesson");
            Console.WriteLine("3- get Lesson by Id");
            Console.WriteLine("4- get Lesson by proffesorId");
            Console.WriteLine("5- Back");
            Console.WriteLine("Please Select The Number:");
            int num = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Blue;
            switch (num)
            {
                case 1:
                    MenuAddLesson.Lesson();

                    break;
                case 2:
                    IGetAllLesson getAllLesson = new GetAllService();
                    getAllLesson.GetAllLesson();

                    break;
                case 3:
                    IGetLessonById lessonById = new GetService();
                    lessonById.GetLesson();

                    break;
                case 4:
                    IGetLessonByIdProffesor lessonByIdProffesor = new GetByIdProffesorService();
                    lessonByIdProffesor.GetLessonsByIdProffesor();

                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.White;
                    APPMenu aPPMenu = new APPMenu();
                    aPPMenu.Menu();

                    break;

            }
            Console.ForegroundColor = ConsoleColor.White;
            LessonM();
        }
    }
}
