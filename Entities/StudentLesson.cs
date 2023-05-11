using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    public class StudentLesson
    {
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("Lesson")]
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        public virtual Score Score { get; set; }
    }
}
