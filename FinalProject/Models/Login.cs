using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        public string Password { get; set; }
        public Account Account { get; set; }
    }
}
