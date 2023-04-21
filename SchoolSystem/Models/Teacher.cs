using System;
using System.Collections.Generic;

namespace SchoolSystem.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();
            Grades = new HashSet<Grade>();
            Notices = new HashSet<Notice>();
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public DateTime Birthdate { get; set; }
        public DateTime AdmissionDate { get; set; }
        /// <summary>
        /// 1 - active
        /// 0 - not active
        /// </summary>
        public sbyte Active { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Notice> Notices { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
