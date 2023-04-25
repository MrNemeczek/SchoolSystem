using System;
using System.Collections.Generic;

namespace SchoolSystem.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? IdPerson { get; set; }

        public virtual Person? IdPersonNavigation { get; set; }
    }
}
