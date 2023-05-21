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
            Console.ReadKey();
        }
    }
}
