using JiroConsoleApp.Initialization;
using JiroConsoleApp.Interfaces.InterfaceStudentLesson;
using System;
using System.Linq;

namespace JiroConsoleApp.Services.ServiceStudentLesson
{
    public class GetByStudentIdService : IGetStudentLesson
    {
        public void GetStudentLessons()
        {
            try
            {
                Console.WriteLine("please enter the StudentId number:");
                int studentID = int.Parse(Console.ReadLine());

                var listSL = Create.studentLessons.Where(sl => sl.IdStudent == studentID).ToList();
                Student student = Create.students.FirstOrDefault(s => s.IdStudent == studentID);

                if (student != null)
                {
                    foreach (var item in listSL)
                    {
                        var scor = Create.scores.FirstOrDefault(s => s.IdStudentLesson == item.IdStudentLesson);
                        var lesson = Create.lessons.FirstOrDefault(l => l.IdLesson == item.IdLesson);
                        if (scor != null)
                        {
                            Console.WriteLine("Student Code " + Convert.ToString(student.Code) + " :");
                            Console.WriteLine("GPA is: " + student.GPA);
                            Console.WriteLine("LessonId: " + lesson.IdLesson);
                            Console.WriteLine("LessonCode is: " + lesson.Code);
                            Console.WriteLine("Unit of this Lesson: " + lesson.NumberUnit);
                            Console.WriteLine("ScoreLesson is: " + scor.scoreLesson + "\n");
                        }
                        else
                        {
                            Console.WriteLine("Student Code " + Convert.ToString(student.Code) + " :");
                            Console.WriteLine("GPA is: " + student.GPA);
                            Console.WriteLine("LessonId: " + lesson.IdLesson);
                            Console.WriteLine("LessonCode is: " + lesson.Code);
                            Console.WriteLine("Unit of this Lesson: " + lesson.NumberUnit);
                            Console.WriteLine("ScoreLesson is: " + null + "\n");
                        }
                    }
                }
                else
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error : The student you are looking for does not exist");
                    Console.ResetColor();
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
