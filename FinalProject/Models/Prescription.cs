using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }
        public string Medication { get; set; }
        public string Strength { get; set; }
        public string Amount { get; set; }
        public string Frequency { get; set; }
        public string Reason { get; set; }
        public string DispenseAmount { get; set; }
        public string Refill { get; set; }
        public DateTime IssuedDate { get; set; }

        public int VisitId { get; set; }
        public Visit Visit { get; set; }
    }
}
