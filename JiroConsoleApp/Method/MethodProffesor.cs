using JiroConsoleApp.Interfaces.InterfaceProfessor;
using JiroConsoleApp.Menu;
using JiroConsoleApp.Services.ServiceProffesor;
using System;

namespace JiroConsoleApp.Method
{
    public class MethodProffesor
    {
        public static void ProffesorM()
        {
            Console.WriteLine("\nProffesor Menu:");
            Console.WriteLine("1- add proffesor");
            Console.WriteLine("2- get all proffesor");
            Console.WriteLine("3- get proffesor by Id");
            Console.WriteLine("4- Back");
            Console.WriteLine("Please Select The Number:");
            int num = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            switch (num)
            {
                case 1:
                    MenuAddProffesor.Professor();

                    break;
                case 2:
                    IGetAllProffesor getAllProffesor = new GetAllService();
                    getAllProffesor.GetAllProfessor();

                    break;
                case 3:
                    IGetProffesor getProffesor = new GetService();
                    getProffesor.GetProfessor();

                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.White;
                    APPMenu aPPMenu = new APPMenu();
                    aPPMenu.Menu();

                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
            ProffesorM();
        }
    }
}
