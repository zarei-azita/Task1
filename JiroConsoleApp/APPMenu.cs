﻿using JiroConsoleApp.Interfaces.InterfaceGPA;
using JiroConsoleApp.Method;
using JiroConsoleApp.Services.ServiceGpa;
using System;

namespace JiroConsoleApp
{
    public class APPMenu
    {
        public APPMenu()
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1- Student");
            Console.WriteLine("2- Profesor");
            Console.WriteLine("3- Lesson");
            Console.WriteLine("4- Student and Lesson");
            Console.WriteLine("5- Score");
            Console.WriteLine("6- Calculate GPA");
            Console.WriteLine("7- Exit");
            Console.WriteLine("Please Select The Number:");
        }   
        public void Menu()
        {       
            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:                   
                    MethodStudent.StudentM();

                    break;
                case 2:
                    MethodProffesor.ProffesorM();

                    break;
                case 3:
                    MethodLesson.LessonM();

                    break;
                case 4:
                    MethodStudentLesson.StudentLessonM();

                    break;
                case 5:
                    MethodScore.SoreM();

                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    IGpa gpa = new GpaService();
                    gpa.GPAcalculation();
                    Console.ResetColor();

                    break;
                case 7:
                    Environment.Exit(0);
                    break;
            }
            Console.ResetColor();
            APPMenu aPPMenu = new APPMenu();
            aPPMenu.Menu();
        }
    }
}
