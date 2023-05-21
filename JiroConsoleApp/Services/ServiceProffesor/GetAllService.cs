using JiroConsoleApp.Initialization;
using JiroConsoleApp.Interfaces.InterfaceProfessor;
using System;

namespace JiroConsoleApp.Services.ServiceProffesor
{
    public class GetAllService: IGetAllProffesor
    {
        public void GetAllProfessor()
        {
            var list = Create.professors;

            foreach (var item in list)
            {
                Console.WriteLine("Professor " + Convert.ToString(item.IdProfessor) + " is :");
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Professor Code: " + item.Code);
                Console.WriteLine("Academic Rank: " + item.AcademicRank);
                Console.WriteLine("Number of units taught: " + item.Number_units_taught_so_far + "\n");
            }
        }
    }
}
