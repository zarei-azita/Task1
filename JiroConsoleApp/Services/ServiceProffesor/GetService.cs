using JiroConsoleApp.Initialization;
using JiroConsoleApp.Interfaces.InterfaceProfessor;
using System;
using System.Linq;

namespace JiroConsoleApp.Services.ServiceProffesor
{
    public class GetService: IGetProffesor
    {
        public void GetProfessor()
        {
            try
            {
                Console.WriteLine("please enter the Professor Id number:");
                int Idpro = int.Parse(Console.ReadLine());

                Professor professor = new Professor();
                int index = Create.professors.FindIndex(p => p.IdProfessor == Idpro);
                if (index >= 0)
                {
                    professor = Create.professors.FirstOrDefault(p => p.IdProfessor == Idpro);
                    Console.WriteLine("Your professor number is " + Convert.ToString(professor.IdProfessor));
                    Console.WriteLine("Name: " + professor.Name);
                    Console.WriteLine("Professor Code: " + professor.Code);
                    Console.WriteLine("AcademicRank: " + professor.AcademicRank);
                    Console.WriteLine("number of units taught: " + professor.Number_units_taught_so_far + "\n");

                }
                else
                {
                    Console.WriteLine("No professors were found with this ID \n");
                }

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
