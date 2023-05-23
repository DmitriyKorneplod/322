using System;
using System.Collections.Generic;

namespace Dentistry.Models
{
    public partial class ServicesFromCheck
    {
        public int Id { get; set; }
        public int IdService { get; set; }
        public string Price { get; set; } = null!;
        public int IdCheck { get; set; }

        public virtual Check IdCheckNavigation { get; set; } = null!;
        public virtual Service IdServiceNavigation { get; set; } = null!;
    }
}
