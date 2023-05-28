using FinalProject.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Appointment
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

        public int ReceptionistId { get; set; }
        public Receptionist Receptionist { get; set; }

        public int VisitId { get; set; }
        public Visit Visit { get; set; }

        public static readonly Dictionary<int, string> Slots;

        static Appointment()
        {
            Slots = new Dictionary<int, string>
            {
                { 1, "9:00am to 9:30am" },
                { 2, "9:30am to 10:00am" },
                { 3, "10:00am to 10:30am" },
                { 4, "10:30am to 11:00am" },
                { 5, "11:00am to 11:30am" },
                { 6, "11:30am to 12:00pm" },
                { 7, "12:00pm to 12:30pm" },
                { 8, "12:30pm to 1:00pm" },
                { 9, "1:00pm to 1:30pm" },
                { 10, "1:30pm to 2:00pm" },
                { 11, "2:00pm to 2:30pm" },
                { 12, "2:30pm to 3:00pm" },
                { 13, "3:00pm to 3:30pm" },
                { 14, "3:30pm to 4:00pm" }
            };
        }
    }
}
