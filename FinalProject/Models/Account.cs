using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Account
    {
        [Key]
        //[ForeignKey("Employee")]
        public int AccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public Login Login { get; set; }

      //  public int EmployeeId { get; set; }
        //public Employee Employee { get; set; }
    }
}
