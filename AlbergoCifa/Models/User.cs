using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlbergoCifa.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Username obbligatorio")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password obbligatoria")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}