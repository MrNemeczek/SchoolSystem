using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SchoolSystem.Models
{
    public partial class Class
    {
        public Class()
        {
            Classes = new HashSet<Classes>();
            StudentClasses = new HashSet<StudentClass>();
        }

        public int Id { get; set; }
        [DisplayName("Nazwa klasy")]
        public string Name { get; set; } = null!;
        [DisplayName("Wychowawca")]
        public int? IdTeacher { get; set; }

        public virtual Teacher? IdTeacherNavigation { get; set; }
        public virtual ICollection<Classes> Classes { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}
