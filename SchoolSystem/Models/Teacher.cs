using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();
            Grades = new HashSet<Grade>();
            Notices = new HashSet<Notice>();
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
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Notice> Notices { get; set; }
    }
}
