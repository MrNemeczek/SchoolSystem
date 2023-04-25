using System;
using System.Collections.Generic;

namespace SchoolSystem.Models
{
    /// <summary>
    /// tabela ktora zawiera studentow przypisanych do klasy i date od kiedy byli w tej klasie do kiedy i czy jest to aktywne
    /// </summary>
    public partial class StudentClass
    {
        public int Id { get; set; }
        public int IdStudent { get; set; }
        public int IdClass { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Class IdClassNavigation { get; set; } = null!;
        public virtual Student IdStudentNavigation { get; set; } = null!;
    }
}
