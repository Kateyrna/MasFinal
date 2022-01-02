using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    class Receptionist : Employee
    {
        [Key]
        public int ReceptionstId { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public Receptionist()
        {
            Appointments = new List<Appointment>();
        }
    }
}
