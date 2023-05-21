using JiroConsoleApp.Initialization;
using JiroConsoleApp.Interfaces.InterfaceCourse;
using System;

namespace JiroConsoleApp.Services.ServiceCourse
{
    public class GetAllService : IGetAllLesson
    {
        public void GetAllLesson()
        {
            var list = Create.lessons;
            foreach (var item in list)
            {
                Console.WriteLine("Lesson Id " + Convert.ToString(item.IdLesson) + " is:");
                Console.WriteLine("Lesson Name: " + item.Name);
                Console.WriteLine("Lesson Code: " + item.Code);
                Console.WriteLine("The number of  unit: " + item.NumberUnit);
                Console.WriteLine("Lesson Capacity: " + item.Capacity + "\n");
            }
        }
    }
}
