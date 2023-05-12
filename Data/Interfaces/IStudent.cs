using Data.Model;
using Entities;

namespace Data.Interfaces
{
    public interface IStudent
    {
        public string AddStudent(StudentDto student);
        public List<Student> GetAllStudent();
        public StudentDto GetStudent(int id);

        public string AddStudentLesson(StudentLessonDto studentLesson);
        public List<ScorLessonForStudentDto> GetScoreLesson(int studentID);
        public List<LessonStudentDto> GetLessonsForStudent(int studentID);
    }
}
