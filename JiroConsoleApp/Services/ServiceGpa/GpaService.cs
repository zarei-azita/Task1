using JiroConsoleApp.Initialization;
using JiroConsoleApp.Interfaces.InterfaceGPA;
using System;
using System.Linq;

namespace JiroConsoleApp.Services.ServiceGpa
{
    public class GpaService : IGpa
    {
        public void GPAcalculation()
        {
            try
            {
                Console.WriteLine("please enter the Student Id:");
                int studentId = int.Parse(Console.ReadLine());

                var student = Create.students.SingleOrDefault(s => s.IdStudent == studentId);
                if (student == null)
                    Console.WriteLine("No student were found with this ID \n");

                double? gpa = 0;
                int flag = 0;

                var studentLessons = Create.studentLessons.Where(sl => sl.IdStudent == studentId).ToList();
                foreach (var item in studentLessons)
                {
                    var scor = Create.scores.FirstOrDefault(s => s.IdStudentLesson == item.IdStudentLesson);
                    if (scor != null)
                    {
                        var lesson = Create.lessons.FirstOrDefault(l => l.IdLesson == item.IdLesson);
                        double? scorunit = lesson.NumberUnit * scor.scoreLesson;
                        gpa = gpa + scorunit;
                        flag = flag + lesson.NumberUnit;
                    }
                }
                if (gpa == 0)
                    Console.WriteLine("No grades have been recorded for the student's courses yet \n");
                else
                {
                    gpa = gpa / flag;

                    int index = Create.students.FindIndex(s => s.IdStudent == studentId);
                    Create.students[index].GPA = gpa;

                    Console.WriteLine("Student ID :" + Convert.ToString(student.IdStudent));
                    Console.WriteLine("National Code: " + student.MeliCOde);
                    Console.WriteLine("Student Code: " + student.Code);
                    Console.WriteLine("Entering Year: " + student.EnteringYear);
                    Console.WriteLine("The grade point average of the student is is: " + gpa + "\n");
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
