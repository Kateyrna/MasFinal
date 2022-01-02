using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    class Account
    {
        [Key]
        public int AccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public Login Login { get; set; }
        public Employee Employee { get; set; }
    }
}
