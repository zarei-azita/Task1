

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Lesson
    {
        public int Id { get; set; }

        [Display(Name = "کد درس ")]
        [Required(ErrorMessage = ("کد درس اجباری است"))]
        [MaxLength(4, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string Code { get; set; }

        [Display(Name = "تعداد واحد درس")]
        [Required(ErrorMessage = ("واحد درس اجباری است"))]
        [MaxLength(1, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public int Unit { get; set; }

        [Display(Name = "ظرفیت درس")]
        [Required(ErrorMessage = ("ظرفیت درس اجباری است"))]
        [MaxLength(3, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public int Capacity { get; set; }

        [ForeignKey("Professor")]
        public int ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }

        public virtual ICollection<StudentLesson> StudentLessons { get; set; }
    }
}
