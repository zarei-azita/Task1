using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Score
    {
        public int Id { get; set; }

        [ForeignKey("StudentLesson")]
        public int StudentLessonId { get; set; }
        public virtual StudentLesson StudentLesson { get; set; }

        [Display(Name = "نمره درس")]
        [Required(ErrorMessage = ("نمره درس اجباری است"))]
        public double ScoreLesson { get; set; }
    }
}
