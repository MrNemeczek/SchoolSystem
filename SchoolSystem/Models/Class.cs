using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SchoolSystem.Models
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        [DisplayName("Nazwa klasy")]
        public string Name { get; set; } = null!;
        [DisplayName("Wychowawca")]
        public int? IdTeacher { get; set; }

        public virtual Teacher? IdTeacherNavigation { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
