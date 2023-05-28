using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public abstract class Employee : Person
    {
        [Key]
        public int EmployeeId { get; set; }
        public decimal Salary { get; set; }
        public DateTime Hiredate { get; set; }
        public string EmployeeTest { get; set; }

        public Account Account { get; set; }
    }
}
