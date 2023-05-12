using Data.Model;
using Entities;

namespace Data.Interfaces
{
    public interface IOther
    {
        public List<Lesson> GetAllLesson();
        public LessonDto GetLesson(int id);

        public StudentDto GPAcalculation(int studentId);
    }
}
