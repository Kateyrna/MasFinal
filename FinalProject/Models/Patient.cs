using FinalProject.Models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    class Patient : Person
    {
        [Key]
        public int PatientId { get; set; }
        public string MedicareNo { get; set; }
        public BloodType BloodType { get; set; }
        public PatientType PatientType { get; set; }
        public string PensionerId { get; set; }
        public string Allergies { get; set; }
        public decimal Discount { get; set; }
        public DisabilityCategory DisabilityCategory { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public Patient()
        {
            Appointments = new List<Appointment>();
        }
    }
}
