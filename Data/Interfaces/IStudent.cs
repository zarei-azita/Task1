using Data.Model;
using Entities;

namespace Data.Interfaces
{
    public interface IStudent
    {
        public string AddStudent(StudentDto student);
        public List<Student> GetAllStudent();
    }
}
