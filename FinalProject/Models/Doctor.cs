using FinalProject.Models.enums;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    internal class Doctor : Employee
    {
        [Key]
        public int DoctorId { get; set; }
        public string Title { get; set; }
        public DoctorSpecialty DoctorSpecialty { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public Doctor()
        {
            Appointments = new List<Appointment>();
        }
    }
}
