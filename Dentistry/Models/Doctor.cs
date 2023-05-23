using System;
using System.Collections.Generic;

namespace Dentistry.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Records = new HashSet<Record>();
        }

        public int Id { get; set; }
        public string Fio { get; set; } = null!;
        public string? Education { get; set; }
        public string? JobTitle { get; set; }

        public virtual ICollection<Record> Records { get; set; }
    }
}
