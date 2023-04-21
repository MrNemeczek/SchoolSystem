using System;
using System.Collections.Generic;

namespace SchoolSystem.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? IdTeacher { get; set; }
        public sbyte Weight { get; set; }

        public virtual Teacher? IdTeacherNavigation { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
