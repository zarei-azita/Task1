using JiroConsoleApp.Initialization;
using JiroConsoleApp.Interfaces.InterfaceStudent;
using System;

namespace JiroConsoleApp.Services.ServiceStudent
{
    public class GetAllService: IGetALLStudent
    {
        public void GetAllStudent()
        {
            var list  = Create.students;
            foreach (var item in list)
            {
                Console.WriteLine("Student " + Convert.ToString(item.IdStudent) + " is :");
                Console.WriteLine("Student Name: " + item.Name);
                Console.WriteLine("Student Code: " + item.Code);
                Console.WriteLine("Entering Year: " + item.EnteringYear);
                Console.WriteLine("National Code: " + item.MeliCOde);
                Console.WriteLine("GPA: " + item.GPA + "\n");
            }
        }
    }
}
