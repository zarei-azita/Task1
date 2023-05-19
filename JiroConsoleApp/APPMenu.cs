using JiroConsoleApp.Initialization;
using JiroConsoleApp.Interfaces;
using JiroConsoleApp.Menu;
using JiroConsoleApp.Services;
using System;
using System.Collections.Generic;

namespace JiroConsoleApp
{
    public class APPMenu
    {
        public APPMenu()
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1- Student");
            Console.WriteLine("2- Profesor");
            Console.WriteLine("3- Lesson and Student");
            Console.WriteLine("4- Record grades for students");
            Console.WriteLine("5- Lessons and Gpa");
            Console.WriteLine("Please Select The Number:");
        }
       
        public void Menu()
        {       
            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    #region Student
                    StudentServices studentServices = new StudentServices();
                    var Sentences = studentServices.Stu();
                    int num;
                    foreach (var item in Sentences)
                    {
                        Console.WriteLine(item);
                    }
                    num = int.Parse(Console.ReadLine());

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    if (num == 1)
                    {
                        var addstu =  MenuStatic.Student();
                        Student student = new Student
                        {
                            Id = int.Parse(addstu[0]),
                            GPA = null,
                            MeliCOde = addstu[1],
                            StudentId = addstu[2],
                            EnteringYear = addstu[3],
                        };

                        string s = studentServices.AddStudent(student);
                        Console.WriteLine(s);
                    }
                    else if (num == 2)
                    {
                        var list = studentServices.GetAllStudent();
                        foreach (var item in list)
                        {
                            Console.WriteLine("student " + Convert.ToString(item.Id) + "is :");
                            Console.WriteLine("studentId: " + item.StudentId);
                            Console.WriteLine("enteringYear: " + item.EnteringYear);
                            Console.WriteLine("national code: " + item.MeliCOde);
                            Console.WriteLine("GPA: " + item.GPA+ "\n");
                        }
                    }
                    else if (num == 3)
                    {
                        Console.WriteLine("please enter the student Id number:");
                        num = int.Parse(Console.ReadLine());

                        var student = studentServices.GetStudent(num);
                        if (student.StudentId == null)
                        {
                            Console.WriteLine("No students were found with this ID \n");
                        }
                        else
                        {
                            Console.WriteLine("Your student number is " + Convert.ToString(student.Id));
                            Console.WriteLine("studentId: " + student.StudentId);
                            Console.WriteLine("enteringYear: " + student.EnteringYear);
                            Console.WriteLine("national code: " + student.MeliCOde);
                            Console.WriteLine("GPA: " + student.GPA + "\n");
                        }
                    }
                    else if(num == 4)
                    {
                        Console.WriteLine("please enter the student Id number:");
                        num = int.Parse(Console.ReadLine());

                        string sd = studentServices.RemoveStudent(num);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(sd);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.ForegroundColor = ConsoleColor.White;

                    #endregion

                    break;
                case 2:
                    #region Professor
                    ProfessorServices professorServices  = new ProfessorServices();
                    var SentencesPro = professorServices.Pro();
                    int numPro;
                    foreach (var item in SentencesPro)
                    {
                        Console.WriteLine(item);
                    }
                    numPro = int.Parse(Console.ReadLine());

                    Console.ForegroundColor = ConsoleColor.Green;
                    switch (numPro)
                    {
                        case 1:
                            var addpro = MenuStatic.Professor();
                            Professor professor = new Professor()
                            {
                                IdProfessor = int.Parse(addpro[0]),
                                Name = addpro[1],
                                Code = addpro[2],
                                AcademicRank = addpro[3],
                                Number_units_taught_so_far = int.Parse(addpro[4])
                            };

                            string p = professorServices.AddProfessor(professor);                           
                            Console.WriteLine(p);

                            break;
                        case 2:
                            var list = professorServices.GetAllProfessor();

                            foreach (var item in list)
                            {
                                Console.WriteLine("professor " + Convert.ToString(item.IdProfessor) + "is :");
                                Console.WriteLine("Name: " + item.Name);
                                Console.WriteLine("professor's Code: " + item.Code);
                                Console.WriteLine("AcademicRank: " + item.AcademicRank);
                                Console.WriteLine("number of units taught: " + item.Number_units_taught_so_far + "\n");
                            }

                            break;
                        case 3:
                            Console.WriteLine("please enter the Professor Id number:");
                            int Idpro = int.Parse(Console.ReadLine());

                            var professor1 = professorServices.GetProfessor(Idpro);

                            if (professor1.Code == null)
                            {
                                Console.WriteLine("No professors were found with this ID \n");
                            }
                            else
                            {
                                Console.WriteLine("Your professor number is " + Convert.ToString(professor1.IdProfessor));
                                Console.WriteLine("Name: " + professor1.Name);
                                Console.WriteLine("Professor's Code: " + professor1.Code);
                                Console.WriteLine("AcademicRank: " + professor1.AcademicRank);
                                Console.WriteLine("number of units taught: " + professor1.Number_units_taught_so_far + "\n");
                            }

                            break;
                        case 4:
                            var addLes = MenuStatic.Lesson();
                            Lesson lesson = new Lesson()
                            {
                                IdLesson = int.Parse(addLes[0]),
                                IdProfessor = int.Parse(addLes[1]),
                                CodeLesson = addLes[2],
                                NumberUnit = int.Parse(addLes[3]),
                                Capacity = int.Parse(addLes[4])             
                            };

                            string l = professorServices.AddLesson(lesson);
                            Console.WriteLine(l);

                            break;
                        case 5:
                            Console.WriteLine("please enter the Professor Id number:");
                            int Idprof = int.Parse(Console.ReadLine());

                            var lessons = professorServices.GetLessons(Idprof);

                            if (lessons.Count == 0)
                            {
                                Console.WriteLine("The Professor you are looking for has not offered a lesson \n");
                            }
                            else
                            {
                                foreach (var item in lessons)
                                {
                                    Console.WriteLine("Lesson's Id:" + Convert.ToString(item.IdLesson));
                                    Console.WriteLine("Lesson's Code: " + item.CodeLesson);
                                    Console.WriteLine("number of course unit: " + item.NumberUnit);
                                    Console.WriteLine("Lesson's Capacity: " + item.Capacity);
                                    Console.WriteLine("ID of the presenting professor is: " + item.IdProfessor + "\n");
                                }
                            }

                            break;
                        default:

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("number is wrong...");
                            Console.ForegroundColor = ConsoleColor.White;

                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.White;

                    #endregion

                    break;
                case 3:
                    #region StudentLesson
                    IStudent interfaceStu = new ServiceForStudent();
                    var menuSL = interfaceStu.menuHere();
                    int numSL;
                    foreach (var item in menuSL)
                    {
                        Console.WriteLine(item);
                    }
                    numSL = int.Parse(Console.ReadLine());

                    Console.ForegroundColor = ConsoleColor.Blue;
                    if (numSL == 1)
                    {
                        var addstuLes = MenuStatic.StudentLesson();
                        StudentLesson studentLes = new StudentLesson()
                        {
                            IdStudentLesson = int.Parse(addstuLes[0]),
                            IdStudent = int.Parse(addstuLes[1]),
                            IdLesson = int.Parse(addstuLes[2]),
                        };

                        string sl = interfaceStu.AddStudentLesson(studentLes);     
                        Console.WriteLine(sl);
                     
                    }
                    else if(numSL == 2)
                    {
                        Console.WriteLine("please enter the StudentId number:");
                        int Idstu = int.Parse(Console.ReadLine());

                        var scores = interfaceStu.GetScoreLesson(Idstu);
                       
                        if (scores.Count == 0)
                        {
                            Console.WriteLine("No grades have been recorded for this student!!");
                        }
                        else
                        {
                            foreach (var item in scores)
                            {
                                Console.WriteLine("StudentId is:" + Convert.ToString(item.IdStudent));
                                Console.WriteLine("LessonId is: " + item.IdLesson);
                                Console.WriteLine("scoreLesson is: " + item.scoreLesson + "\n");
                            }
                        }                        
                    }
                    else if(numSL == 3)
                    {
                        Console.WriteLine("please enter the StudentId number:");
                        int Idstu = int.Parse(Console.ReadLine());

                        var lesson_studentOutput = interfaceStu.GetStudentLessons(Idstu);
                        foreach (var item in lesson_studentOutput)
                        {
                            Console.WriteLine("Student number " + Convert.ToString(item.StudentCode) + " :");
                            Console.WriteLine("GPA is: " + item.GPA);
                            Console.WriteLine("LessonId: " + item.IdLesson);
                            Console.WriteLine("LessonCode is: " + item.CodeLesson);
                            Console.WriteLine("Unit of this Lesson: " + item.NumberUnit);
                            Console.WriteLine("ScoreLesson is: " + item.scoreLesson + "\n");
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;

                    #endregion

                    break;
                case 4:
                    #region Score
                    IProfessor interfacePro = new ServiceForProfessor();
                    var menuPro = interfacePro.menuHere();
                    int numP;
                    foreach (var item in menuPro)
                    {
                        Console.WriteLine(item);
                    }
                    numP = int.Parse(Console.ReadLine());

                    var changescore = MenuStatic.Score();
                    Score score = new Score()
                    {
                        IdStudent = int.Parse(changescore[0]),
                        IdLesson = int.Parse(changescore[1]),
                        scoreLesson = double.Parse(changescore[2]),
                    };
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    if (numP == 1)
                    {
                        string s = interfacePro.AddScore(score);
                        Console.WriteLine(s);
                    }
                    else if(numP == 2)
                    {               
                        string s = interfacePro.UpdateScore(score);
                        Console.WriteLine(s);
                    }
                    Console.ForegroundColor = ConsoleColor.White;

                    #endregion

                    break;
                case 5:
                    #region GPA
                    IOther interfaceOther = new OtherServices();
                    var menuG = interfaceOther.menuHere();
                    int numG;
                    foreach (var item in menuG)
                    {
                        Console.WriteLine(item);
                    }
                    numG = int.Parse(Console.ReadLine());

                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    if(numG == 1)
                    {
                        var lessons = interfaceOther.GetAllLesson();
                        foreach (var item in lessons)
                        {
                            Console.WriteLine("Lesson Id " + Convert.ToString(item.IdLesson) + " is:");
                            Console.WriteLine("Lesson Code: " + item.CodeLesson);
                            Console.WriteLine("The number of  unit: " + item.NumberUnit);
                            Console.WriteLine("Lesson Capacity: " + item.Capacity + "\n");
                        }
                    }
                    else if(numG == 2)
                    {
                        Console.WriteLine("please enter the Lesson Id:");
                        int IdLesson = int.Parse(Console.ReadLine());

                        var course = interfaceOther.GetLesson(IdLesson);
                        if (course.CodeLesson == null)
                        {
                            Console.WriteLine("No lessons were found with this ID \n");
                        }
                        else
                        {
                            Console.WriteLine("Professor ID of the provider is:" + Convert.ToString(course.IdProfessor));
                            Console.WriteLine("Leeson Id: " + course.IdLesson);
                            Console.WriteLine("Lesson Code: " + course.CodeLesson);
                            Console.WriteLine("The number of  unit: " + course.NumberUnit);
                            Console.WriteLine("Lesson Capacity: " + course.Capacity + "\n");
                        }
                    }
                    else if(numG == 3)
                    {
                        Console.WriteLine("please enter the Student Id:");
                        int studentId = int.Parse(Console.ReadLine());

                        var student = interfaceOther.GPAcalculation(studentId);
                        if (student.StudentId == null)
                        {
                            Console.WriteLine("No student were found with this ID \n");
                        }
                        else
                        {
                            Console.WriteLine("Student ID :" + Convert.ToString(student.Id));
                            Console.WriteLine("National Code: " + student.MeliCOde);
                            Console.WriteLine("Student Code: " + student.StudentId);
                            Console.WriteLine("Entering Year: " + student.EnteringYear);
                            Console.WriteLine("The grade point average of the student is is: " + student.GPA + "\n");
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;

                    #endregion

                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("number is wrong...");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

        }
    }
}
