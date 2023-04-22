using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SchoolSystem.Models
{
    public partial class Notice
    {
        public int Id { get; set; }
        [DisplayName("Opis")]
        public string? Description { get; set; }
        public int IdTeacher { get; set; }
        public int IdStudent { get; set; }
        /// <summary>
        /// 1 - positive
        /// 0 - negative
        /// </summary>
        public sbyte Grade { get; set; }
        [DisplayName("Punkty")]
        public int Points { get; set; }

        public virtual Student IdStudentNavigation { get; set; } = null!;
        public virtual Teacher IdTeacherNavigation { get; set; } = null!;
    }
}
