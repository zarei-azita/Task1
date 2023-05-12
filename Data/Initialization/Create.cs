using Entities;
using Entities.DB;

namespace Data.Initialization
{
    public class Create
    {
        public Create(MyDBContext context)
        {
            CreateStudent(context);
            CreateProfesor(context);
            CreateLesson(context);
            CreateStudentLesson(context);
        }

        public static void CreateStudent(MyDBContext context)
        {
            Student student1 = new Student()
            {
                Id = 1,
                EnteringYear = "1397",
                MeliCOde = "3720480456",
                StudentId = "9717022111"
            };
            Student student2 = new Student()
            {
                Id = 2,
                EnteringYear = "1392",
                MeliCOde = "3720450430",
                StudentId = "9217022117"
            };

            context.Students.Add(student1);
            context.Students.Add(student2);
            context.SaveChanges();
        }

        public static void CreateProfesor(MyDBContext context)
        {
            Professor Pro1 = new Professor()
            {
                Id = 1,
                Code = "101010",
                AcademicRank = "دکتری",
                Name = "دکتر پرهام مرادی",
                Number_units_taught_so_far = 300
            };
            Professor Pro2 = new Professor()
            {
                Id = 2,
                Code = "202020",
                AcademicRank = "دکتری",
                Name = "دکتر صادق سلیمانی",
                Number_units_taught_so_far = 200
            };

            context.Professors.Add(Pro1);
            context.Professors.Add(Pro2);
            context.SaveChanges();
        }

        public static void CreateLesson(MyDBContext context)
        {
            Lesson less1 = new Lesson()
            {
                Id = 1,
                Code = "2021",
                Unit = 3,
                Capacity = 40,
                ProfessorId = 1
            };
            Lesson less2 = new Lesson()
            {
                Id = 2,
                Code = "2011",
                Unit = 3,
                Capacity = 20,
                ProfessorId = 1
            };
            Lesson less3 = new Lesson()
            {
                Id = 3,
                Code = "2111",
                Unit = 3,
                Capacity = 30,
                ProfessorId = 2
            };
            context.Lessons.Add(less1);
            context.Lessons.Add(less2);
            context.Lessons.Add(less3);
            context.SaveChanges();
        }

        public static void CreateStudentLesson(MyDBContext context)
        {
            StudentLesson studentLesson1 = new StudentLesson()
            {
                Id = 1,
                LessonId = 1,
                StudentId = 1
            };
            StudentLesson studentLesson2 = new StudentLesson()
            {
                Id = 2,
                LessonId = 1,
                StudentId = 2
            };
            StudentLesson studentLesson3 = new StudentLesson()
            {
                Id = 3,
                LessonId = 2,
                StudentId = 1
            };
            StudentLesson studentLesson4 = new StudentLesson()
            {
                Id = 4,
                LessonId = 3,
                StudentId = 2
            };

            context.StudentLessons.Add(studentLesson1);
            context.StudentLessons.Add(studentLesson2);
            context.StudentLessons.Add(studentLesson3);
            context.StudentLessons.Add(studentLesson4);
            context.SaveChanges();
        }
    }
}
