using System;
using System.Collections.Generic;

namespace SchoolSystem.Models
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? IdTeacher { get; set; }

        public virtual Teacher? IdTeacherNavigation { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
