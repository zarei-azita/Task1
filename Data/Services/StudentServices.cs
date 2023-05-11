using Data.Interfaces;
using Data.Model;
using Entities;
using Entities.DB;

namespace Data.Services
{
    public class StudentServices:IStudent
    {
        private MyDBContext _context;
        public StudentServices(MyDBContext context)
        {
            _context = context;
        }

        public string AddStudent(StudentDto student)
        {
            var stu = _context.Students.SingleOrDefault(s => s.Id == student.Id);
            if(stu != null)
            {
                return "دانشجو با این شناسه از قبل وجود دارد";
            }

            Student Newstudent = new Student()
            {
                Id = student.Id,
                EnteringYear = student.EnteringYear,
                MeliCOde = student.MeliCOde,
                StudentId = student.StudentId,
                GPA = student.GPA
            };

            _context.Students.Add(Newstudent);
            _context.SaveChanges();
            return "دانشجو " + student.Id + " به لیست اضافه شد";
        }

        public List<Student> GetAllStudent()
        {
            return _context.Students.OrderBy(s=> s.Id).ToList();
        }
    }
}
