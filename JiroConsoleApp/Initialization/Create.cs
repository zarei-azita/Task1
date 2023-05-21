
using System.Collections.Generic;

namespace JiroConsoleApp.Initialization
{
    public static class Create
    {
        public static List<Student> students = new List<Student>()
        {
            new Student()
            {
                IdStudent = 1,
                Name = "azita",
                EnteringYear = "1392",
                Code = "9217021107",
                MeliCOde = "3720480452",
                GPA = null
            },
            new Student(){
                IdStudent = 2,
                 Name = "rebaz",
                EnteringYear = "1397",
                Code = "9717022190",
                MeliCOde = "3730219901",
                GPA = null
            }
        };
        public static List<Professor> professors = new List<Professor>()
        {
            new Professor()
            {
                IdProfessor = 1,
                Name = "Dr morady",
                AcademicRank = "phd",
                Code = "2020",
                Number_units_taught_so_far = 50
            },
            new Professor()
            {
                IdProfessor = 2,
                Name = "Dr solimany",
                AcademicRank = "Doctorate",
                Code = "2121",
                Number_units_taught_so_far = 30
            }
        };


        public static List<Lesson> lessons = new List<Lesson>()
        {
            new Lesson()
            {
                IdLesson =1,
                Name = "computer",
                Code = "2021",
                NumberUnit = 3,
                Capacity = 40,
            },
            new Lesson()
            {
                IdLesson = 2,
                Name = "C#",
                Code = "2011",
                NumberUnit = 3,
                Capacity = 20,
            },
            new Lesson()
            {
                IdLesson = 3,
                Name = "Asp.net 5",
                Code = "2111",
                NumberUnit = 3,
                Capacity = 30,
            }
        };
        public static List<StudentLesson> studentLessons = new List<StudentLesson>()
        {
             new StudentLesson()
            {
                IdStudentLesson = 1,
                IdLesson = 1,
                IdStudent = 1
            },
            new StudentLesson()
            {
                IdStudentLesson = 2,
                IdLesson = 1,
                IdStudent = 2
            },
            new StudentLesson()
            {
                IdStudentLesson = 3,
                IdLesson = 2,
                IdStudent = 1
            },
            new StudentLesson()
            {
                IdStudentLesson = 4,
                IdLesson = 3,
                IdStudent = 2
            }
        };
        public static List<ProffesorLesson> proffesorLessons = new List<ProffesorLesson>()
        {
             new ProffesorLesson()
            {
                IdLesson = 1,
                IdProffor = 1
            },
            new ProffesorLesson()
            {
                IdLesson = 2,
                IdProffor = 2
            },
            new ProffesorLesson()
            {
                IdLesson = 3,
                IdProffor = 2
            }
        };
        public static List<Score> scores = new List<Score>();
        
    }


}

