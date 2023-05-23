using System;
using System.Collections.Generic;

namespace Dentistry.Models
{
    public partial class Administrato
    {
        public Administrato()
        {
            Records = new HashSet<Record>();
        }

        public int Id { get; set; }
        public string Fio { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Login { get; set; } = null!;

        public virtual ICollection<Record> Records { get; set; }
    }
}
