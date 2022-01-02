using FinalProject.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime BookingDate { get; set; }
        public int SlotNumber { get; set; }
        public AppointmentStatus Status { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int ReceptionstId { get; set; }
        public Receptionist Receptionist { get; set; }

        public int VisitId { get; set; }
        public Visit Visit { get; set; }

        public static readonly Dictionary<int, string> Slots;

        static Appointment()
        {
            Slots = new Dictionary<int, string>
            {
                { 1, "09:00" }
            };
        }
    }
}
