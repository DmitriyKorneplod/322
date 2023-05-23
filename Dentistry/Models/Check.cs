using System;
using System.Collections.Generic;

namespace Dentistry.Models
{
    public partial class Check
    {
        public Check()
        {
            ServicesFromChecks = new HashSet<ServicesFromCheck>();
        }

        public int Id { get; set; }
        public int IdRecord { get; set; }
        public DateTime? Date { get; set; }
        public string Price { get; set; } = null!;

        public virtual Record IdRecordNavigation { get; set; } = null!;
        public virtual ICollection<ServicesFromCheck> ServicesFromChecks { get; set; }
    }
}
