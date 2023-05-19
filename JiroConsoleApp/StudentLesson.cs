
namespace JiroConsoleApp
{
    public class StudentLesson /*: Student*/
    {
        //public StudentLesson(int id, string CodeMeli, string studentCode, string EnteringYear, double moadel) 
        //    :base( id, CodeMeli, studentCode, EnteringYear, moadel)
        //{

        //}
        public int IdStudentLesson { get; set; }
        public int IdStudent { get; set; }
        public int IdLesson { get; set; }

    }
}
