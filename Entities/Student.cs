using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = ("کد ملی اجباری است"))]
        [MaxLength(10, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string MeliCOde { get; set; }

        [Display(Name = "شماره دانشجویی")]
        [Required(ErrorMessage = ("شماره دانشجویی اجباری است"))]
        [MaxLength(10, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string StudentId { get; set; }

        [Display(Name = "سال ورود به دانشگاه")]
        [Required(ErrorMessage = ("سال ورود اجباری است"))]
        [MaxLength(4, ErrorMessage = "مقدار {0} نباید بیشتر از {1} کاراکتر باشد")]
        public string EnteringYear { get; set; }

        [Display(Name = "معدل")]
        public double? GPA { get; set; }

        public virtual ICollection<StudentLesson> StudentLessons { get; set; }
    }
}
