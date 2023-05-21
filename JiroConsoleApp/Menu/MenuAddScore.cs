using JiroConsoleApp.Interfaces.InterfaceScore;
using JiroConsoleApp.Services.ServiceScore;
using System;

namespace JiroConsoleApp.Menu
{
    public class MenuAddScore
    {
        public static void Score()
        {
            try
            {
                Console.WriteLine("please enter the Id for Student:");
                int IdStu = int.Parse(Console.ReadLine());
                Console.WriteLine("please enter the Id for Lesson:");
                int IdLess = int.Parse(Console.ReadLine());
                Console.WriteLine("please enter the Lesson Grade:");
                string scoreLesson = Console.ReadLine();

                IAddScore addScore = new AddService();

                Score score = new Score()
                {
                    IdStudent = IdStu,
                    IdLesson = IdLess,
                    scoreLesson = double.Parse(scoreLesson),
                };

                string s = addScore.AddScore(score);
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
