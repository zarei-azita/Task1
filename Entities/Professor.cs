

using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Professor
    {
        public int Id { get; set; }

        [Display(Name = "نام مدرس")]
        [Required(ErrorMessage = ("نام مدرس اجباری است"))]
        [MaxLength(20, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string Name { get; set; }

        [Display(Name = "کد پرسنلی")]
        [Required(ErrorMessage = ("کد پرسنلی اجباری است"))]
        [MaxLength(10, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string Code { get; set; }

        [Display(Name = "مرتبه علمی")]
        [Required(ErrorMessage = ("مرتبه علمی اجباری است"))]
        [MaxLength(30, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string AcademicRank { get; set; }

        [Display(Name = "تعداد واحد تدریس شده تا کنون")]
        [Required(ErrorMessage = ("تعداد واحد تدریس شده تا کنون اجباری است"))]
        public int Number_units_taught_so_far { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
