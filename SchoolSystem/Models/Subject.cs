using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SchoolSystem.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        [DisplayName("Nazwa przedmiotu")]
        public string Name { get; set; } = null!;
        public int? IdTeacher { get; set; }
        [DisplayName("Waga przedmiotu")]
        public sbyte Weight { get; set; }

        public virtual Teacher? IdTeacherNavigation { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
