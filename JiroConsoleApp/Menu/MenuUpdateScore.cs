using JiroConsoleApp.Interfaces.InterfaceScore;
using JiroConsoleApp.Services.ServiceScore;
using System;

namespace JiroConsoleApp.Menu
{
    public class MenuUpdateScore
    {
        public static void Score()
        {
            try
            {
                Console.WriteLine("please enter the Id for Student:");
                int IdStu = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the Lesson Id for which you want to change the grade:");
                int IdLess = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the new grade:");
                string scoreLesson = Console.ReadLine();

                IUpdateScore updateScore = new UpdateService();

                Score score = new Score()
                {
                    IdStudent = IdStu,
                    IdLesson = IdLess,
                    scoreLesson = double.Parse(scoreLesson),
                };

                string s = updateScore.UpdateScore(score);
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
