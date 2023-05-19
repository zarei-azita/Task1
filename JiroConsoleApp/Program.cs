using JiroConsoleApp.Initialization;
using System;

namespace JiroConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            APPMenu m = new APPMenu();
            m.Menu();
            while (true)
            {
                Console.WriteLine("If you want to go back to the beginning, enter number 1");
                int a = int.Parse(Console.ReadLine());
                if (a == 1)
                {
                    APPMenu men = new APPMenu();
                    men.Menu();
                }
                else
                {
                    return;
                }
                Console.ReadKey();
            }        
          
        }
    }
}
