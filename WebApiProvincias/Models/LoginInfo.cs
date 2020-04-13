using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProvincias.Models
{
    public class LoginInfo
    {

        public string username { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(10)]
        public string password { get; set; }
      
    }
}
