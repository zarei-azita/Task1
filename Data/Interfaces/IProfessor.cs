using Data.Model;
using Entities;

namespace Data.Interfaces
{
    public interface IProfessor
    {
        public string AddProfessor(ProfessorDto professor);
        public List<Professor> GetAllProfessor();
        public ProfessorDto GetProfessor(int id);

        public string AddLesson(LessonDto lesson);
        public List<Lesson> GetLessons(int IDprofessor);

        public string AddScore(ScoreLessonDto scoreLesson);
        public string UpdateScore(ScoreLessonDto scoreLesson);
    }
}
