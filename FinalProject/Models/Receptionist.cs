using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Receptionist : Employee
    {
        [Key]
        public int ReceptionistId { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public Receptionist()
        {
            Appointments = new List<Appointment>();
        }
    }
}
