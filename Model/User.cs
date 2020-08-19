using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class User
    {
        [Required]
        [EmailAddress]
      public string Email { get; set; }
      public string Password { get; set; }
    
    }
}
