using System;
using System.Collections.Generic;

namespace JiroConsoleApp.Menu
{
    public static class MenuStatic
    {
        public static List<string> Student()
        {
            Console.WriteLine("please enter the Id number for student:");
            int Id = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter Student's national code:");
            string meli = Console.ReadLine();
            Console.WriteLine("please enter the studentCode :");
            string studentCode = Console.ReadLine();
            Console.WriteLine("please enter the EnteringYear :");
            string EnteringYear = Console.ReadLine();

            List<string> s = new List<string>()
            {
                Id.ToString(),
                meli,
                studentCode,
                EnteringYear
            };
            return s;
        }

        public static List<string> Professor()
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

            List<string> p = new List<string>()
            {
                Id.ToString(),
                name,
                professorCode,
                AcademicRank,
                Number_units.ToString()
            };
            return p;
        }

        public static List<string> Lesson()
        {
            Console.WriteLine("please enter the Id number for Lesson:");
            int Id = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter the Id for Professor:");
            int IdPro = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter the  Lesson's Code:");
            string LessonCode = Console.ReadLine();
            Console.WriteLine("Please enter the number of course unit:");
            int Unit = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter Lesson's Capacity:");
            int Capacity = int.Parse(Console.ReadLine());

            List<string> l = new List<string>()
            {
                Id.ToString(),
                IdPro.ToString(),
                LessonCode,
                Unit.ToString(),
                Capacity.ToString()
            };
            return l;
        }

        public static List<string> StudentLesson()
        {
            Console.WriteLine("please enter the Id number for StudentLesson:");
            int Id = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter the Id for Student:");
            int IdStu = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter the Id for Lesson:");
            int IdLess = int.Parse(Console.ReadLine());

            List<string> sl = new List<string>()
            {
                Id.ToString(),
                IdStu.ToString(),
                IdLess.ToString()
            };
            return sl;
        }
        public static List<string> Score()
        {
            Console.WriteLine("please enter the Id for Student:");
            int IdStu = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter the Id for Lesson:");
            int IdLess = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter the Lesson Grade:");
            string scoreLesson = Console.ReadLine();

            List<string> s = new List<string>()
            {
                IdStu.ToString(),
                IdLess.ToString(),
                scoreLesson
            };
            return s;
        }

    }
}
