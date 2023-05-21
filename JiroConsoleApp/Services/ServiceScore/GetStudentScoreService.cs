using JiroConsoleApp.Initialization;
using JiroConsoleApp.Interfaces.InterfaceScore;
using System;
using System.Linq;

namespace JiroConsoleApp.Services.ServiceScore
{
    public class GetStudentScoreService : IGetStudentsScore
    {
        public void GetScoreByStudentId()
        {
            try
            {
                Console.WriteLine("please enter the StudentId number:");
                int studentID = int.Parse(Console.ReadLine());

                var listSL = Create.studentLessons.FindAll(s => s.IdStudent == studentID);
                bool flag = false;
                foreach (var item in listSL)
                {
                    Score score = Create.scores.FirstOrDefault(s => s.IdStudentLesson == item.IdStudentLesson);
                    if (score != null)
                    {
                        Console.WriteLine("StudentId is:" + Convert.ToString(score.IdStudent));
                        Console.WriteLine("LessonId is: " + score.IdLesson);
                        Console.WriteLine("scoreLesson is: " + score.scoreLesson + "\n");
                        flag = true;
                    }
                }
                if (flag == false)
                    Console.WriteLine("No grades have been recorded for this student!!");
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
