using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SchoolSystem.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Classes = new HashSet<Classes>();
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        [DisplayName("Nazwa przedmiotu")]
        public string Name { get; set; } = null!;

        public virtual ICollection<Classes> Classes { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
