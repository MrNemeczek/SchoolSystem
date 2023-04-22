using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models
{
    public partial class Grade
    {
        public int Id { get; set; }
        [DisplayName("Ocena")]
        public float Grade1 { get; set; }
        public int IdStudent { get; set; }
        public int IdTeacher { get; set; }
        public int IdSubject { get; set; }
        /// <summary>
        /// data wprowadzenia oceny
        /// </summary>
        [DisplayName("Data wystawienia")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public virtual Student IdStudentNavigation { get; set; } = null!;
        public virtual Subject IdSubjectNavigation { get; set; } = null!;
        public virtual Teacher IdTeacherNavigation { get; set; } = null!;
    }
}
