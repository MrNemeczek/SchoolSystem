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
        }

        public int Id { get; set; }
        [DisplayName("Imię")]
        public string Name { get; set; } = null!;
        [DisplayName("Nazwisko")]
        public string Lastname { get; set; } = null!;
        [DisplayName("Data urodzenia")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
        [DisplayName("Data przyjęcia")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime AdmissionDate { get; set; }
        public int? IdClass { get; set; }
        /// <summary>
        /// 1 - active
        /// 0 - not active
        /// </summary>
        public sbyte Active { get; set; }

        public virtual Class? IdClassNavigation { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Notice> Notices { get; set; }
    }
}
