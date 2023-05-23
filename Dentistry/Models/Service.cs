using System;
using System.Collections.Generic;

namespace Dentistry.Models
{
    public partial class Service
    {
        public Service()
        {
            ServicesFromChecks = new HashSet<ServicesFromCheck>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string Price { get; set; } = null!;

        public virtual ICollection<ServicesFromCheck> ServicesFromChecks { get; set; }
    }
}
