using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
            Notices = new HashSet<Notice>();
            StudentClasses = new HashSet<StudentClass>();
        }

        public int Id { get; set; }
        public DateTime AdmissionDate { get; set; }
        /// <summary>
        /// 1 - active
        /// 0 - not active
        /// </summary>
        public sbyte Active { get; set; }
        public int IdPerson { get; set; }

        public virtual Person IdPersonNavigation { get; set; } = null!;
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Notice> Notices { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}
