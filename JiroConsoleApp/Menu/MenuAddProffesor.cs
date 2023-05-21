using JiroConsoleApp.Interfaces.InterfaceProfessor;
using JiroConsoleApp.Services.ServiceProffesor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiroConsoleApp.Menu
{
    public static class MenuAddProffesor
    {
        public static void Professor()
        {
            try
            {
                Console.WriteLine("please enter the Id number for professor:");
                int Id = int.Parse(Console.ReadLine());
                Console.WriteLine("please enter Professor's Name:");
                string name = Console.ReadLine();
                Console.WriteLine("please enter the  Professor's Code :");
                string professorCode = Console.ReadLine();
                Console.WriteLine("please enter Professor's AcademicRank :");
                string AcademicRank = Console.ReadLine();
                Console.WriteLine("please enter The number of units taught :");
                int Number_units = int.Parse(Console.ReadLine());

                IAddProffesor addProffesor = new AddService();
                Professor professor = new Professor()
                {
                    IdProfessor = Id,
                    Name = name,
                    Code = professorCode,
                    AcademicRank = AcademicRank,
                    Number_units_taught_so_far = Number_units
                };

                string p = addProffesor.AddProfessor(professor);
                Console.WriteLine(p);
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
