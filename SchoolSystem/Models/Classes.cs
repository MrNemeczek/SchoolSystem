using System;
using System.Collections.Generic;

namespace SchoolSystem.Models
{
    /// <summary>
    /// zajęcia szkolne
    /// </summary>
    public partial class Classes
    {
        public Classes()
        {
            InverseIdTeacherNavigation = new HashSet<Classes>();
        }

        public int Id { get; set; }
        public int IdSubject { get; set; }
        public int IdTeacher { get; set; }
        public int IdClass { get; set; }

        public virtual Class IdClassNavigation { get; set; } = null!;
        public virtual Subject IdSubjectNavigation { get; set; } = null!;
        public virtual Classes IdTeacherNavigation { get; set; } = null!;
        public virtual ICollection<Classes> InverseIdTeacherNavigation { get; set; }
    }
}
