using JiroConsoleApp.Initialization;
using System.Collections.Generic;
using System.Linq;

namespace JiroConsoleApp.Services
{
    public class StudentServices
    {
        public List<string> Stu()
        {
            List<string> s = new List<string>
            {
                "\nMenu for Student:",
                "1- add student","2- get all student",
                "3- get student by Id","4- Remove Student by Id",
                "Please Select The Number:"
            };

            return s;
        }
        public string AddStudent(Student student)
        {
            int index = Create.students.FindIndex(s => s.Id == student.Id);
            if (index >= 0)
            {
                return "A student with this ID has already been added";
            }
            else
            {
                Create.students.Add(student);
                return "The student has been successfully added to the list";
            }      
        }

        public List<Student> GetAllStudent()
        {
            return Create.students;
        }

        public Student GetStudent(int id)
        {
            Student student = new Student();
            int index = Create.students.FindIndex(s => s.Id == id);
            if (index >= 0)
            {
                student = Create.students.FirstOrDefault(s => s.Id == id);
                return student;
            }
            else
            {
                return student;
            }
        }

        public string RemoveStudent(int studentId)
        {
            Student student = Create.students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                bool studentLesson = Create.studentLessons.Any(sl=>sl.IdStudent == studentId);
                if(studentLesson == false)
                {
                    Create.students.Remove(student);
                    return "The student was successfully removed";
                }
                else
                {
                    var studentLesson1 = Create.studentLessons.Where(sl => sl.IdStudent == studentId).ToList();
                    bool confirmation = false;
                    foreach (var item in studentLesson1)
                    {
                        Score score = Create.scores.FirstOrDefault(s => s.IdStudentLesson == item.IdStudentLesson);
                        if(score != null)
                        {
                            if(score.scoreLesson == null)//نمره ثبت نشده است
                            {
                                confirmation = true;
                            }                
                        }
                    }
                    if(confirmation == false)
                    {
                        Create.students.Remove(student);
                        return "The student was successfully removed";
                    }
                    else
                    {
                        return "The student cannot be removed until the end of the semester and registration of grades";
                    }
                }       
            }
            else
            {
                return "The student ID is wrong";
            }

        }
    }

}
