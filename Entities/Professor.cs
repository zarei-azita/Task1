

namespace Entities
{
    public class Professor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string AcademicRank { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
