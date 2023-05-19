using System.Collections.Generic;

namespace JiroConsoleApp.Interfaces
{
    public interface IOther
    {
        List<Lesson> GetAllLesson();
        Lesson GetLesson(int id);
        Student GPAcalculation(int studentId);
        List<string> menuHere();
    }
}
