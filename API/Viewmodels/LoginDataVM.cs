using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Viewmodels
{
    public class LoginDataVM
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Roles { get; set; }
    }
}
