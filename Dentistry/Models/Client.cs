using System;
using System.Collections.Generic;

namespace Dentistry.Models
{
    public partial class Client
    {
        public Client()
        {
            Records = new HashSet<Record>();
        }

        public int Id { get; set; }
        public string Fio { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Record> Records { get; set; }
    }
}
