using System;
using System.Collections.Generic;

namespace Dentistry.Models
{
    public partial class Record
    {
        public Record()
        {
            Checks = new HashSet<Check>();
        }

        public int Id { get; set; }
        public int IdDoctor { get; set; }
        public string? RecordingTime { get; set; }
        public DateTime Date { get; set; }
        public int IdClient { get; set; }
        public string? Complaint { get; set; }
        public int IdAdministrator { get; set; }

        public virtual Administrato IdAdministratorNavigation { get; set; } = null!;
        public virtual Client IdClientNavigation { get; set; } = null!;
        public virtual Doctor IdDoctorNavigation { get; set; } = null!;
        public virtual ICollection<Check> Checks { get; set; }
    }
}
