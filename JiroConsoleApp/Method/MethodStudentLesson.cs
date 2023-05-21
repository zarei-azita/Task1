using JiroConsoleApp.Interfaces.InterfaceStudentLesson;
using JiroConsoleApp.Menu;
using JiroConsoleApp.Services.ServiceStudentLesson;
using System;

namespace JiroConsoleApp.Method
{
    public class MethodStudentLesson
    {
        public static void StudentLessonM()
        {
            Console.WriteLine("\nStudentLesson Menu:");
            Console.WriteLine("1- By the student, taking lessons");
            Console.WriteLine("2- Get Student Lessons by studentId");
            Console.WriteLine("3- Back");
            Console.WriteLine("Please Select The Number:");
            int num = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            switch (num)
            {
                case 1:
                    MenuAddStudentLesson.StudentLesson();

                    break;
                case 2:
                    IGetStudentLesson getStudentLesson = new GetByStudentIdService();
                    getStudentLesson.GetStudentLessons();

                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.White;
                    APPMenu aPPMenu = new APPMenu();
                    aPPMenu.Menu();

                    break;

            }
            Console.ResetColor();
            StudentLessonM();
        }
    }
}
