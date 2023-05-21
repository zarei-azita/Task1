using JiroConsoleApp.Menu;
using System;

namespace JiroConsoleApp.Method
{
    public class MethodScore
    {
        public static void SoreM()
        {
            Console.WriteLine("\nScore Menu:");
            Console.WriteLine("1- Add Score");
            Console.WriteLine("2- Update Score");
            Console.WriteLine("3- Back");
            Console.WriteLine("Please Select The Number:");
            int num = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Cyan;
            switch (num)
            {
                case 1:
                    MenuAddScore.Score();

                    break;
                case 2:
                    MenuUpdateScore.Score();

                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.White;
                    APPMenu aPPMenu = new APPMenu();
                    aPPMenu.Menu();

                    break;

            }
            Console.ResetColor();
            SoreM();
        }
    }
}
