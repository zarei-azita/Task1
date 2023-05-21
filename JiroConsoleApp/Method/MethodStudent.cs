using JiroConsoleApp.Interfaces.InterfaceScore;
using JiroConsoleApp.Interfaces.InterfaceStudent;
using JiroConsoleApp.Menu;
using JiroConsoleApp.Services.ServiceScore;
using JiroConsoleApp.Services.ServiceStudent;
using System;


namespace JiroConsoleApp.Method
{
    public static class MethodStudent
    {
        public static void StudentM()
        {
            Console.WriteLine("\nStudent Menu:");
            Console.WriteLine("1- add student");
            Console.WriteLine("2- get all student");
            Console.WriteLine("3- get student by Id");
            Console.WriteLine("4- remove Student by Id");
            Console.WriteLine("5- see your scores");
            Console.WriteLine("6- Back");
            Console.WriteLine("Please Select The Number:");
            int num = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Magenta;
            switch (num)
            {
                case 1:
                    MenuAddStudent.StudentAdd();

                    break;
                case 2:
                    IGetALLStudent getALLStudent = new GetAllService();
                    getALLStudent.GetAllStudent();

                    break;
                case 3:
                    IGetStudent getStudent = new GetService();
                    getStudent.GetStudent();

                    break;
                case 4:
                    IRemoveStudent removeStudent = new RemoveService();
                    try
                    {
                        Console.WriteLine("please enter the student Id number:");
                        int idNumber = int.Parse(Console.ReadLine());
                        string sd = removeStudent.RemoveStudent(idNumber);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(sd);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (FormatException)
                    {
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error : Please Enter Only Integers");
                        Console.ResetColor();
                    }

                    break;
                case 5:
                    IGetStudentsScore getStudentsScore = new GetStudentScoreService();
                    getStudentsScore.GetScoreByStudentId();

                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.White;
                    APPMenu aPPMenu = new APPMenu();
                    aPPMenu.Menu();

                    break;
              
            }
            Console.ForegroundColor = ConsoleColor.White;
            StudentM();
        }
    }
}
