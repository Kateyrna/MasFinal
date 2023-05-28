using System.Collections.Generic;

namespace FinalProject.Models
{
    public class Visit
    {
        public int VisitId { get; set; }
        public string Reason { get; set; }
        public string Diagnosis { get; set; }
        public string Notes { get; set; }

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }

        public Visit()
        {
            Prescriptions = new List<Prescription>();
        }
    }
}
