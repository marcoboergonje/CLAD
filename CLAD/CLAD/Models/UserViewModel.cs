using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CLAD.Models
{
    public class UserViewModel
    {
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public virtual string SecurityStamp { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
