using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlbergoCifa.Models
{
    public class Servizio
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Descrizione obbligatoria")]
        public string Descrizione { get; set; }
        [Required(ErrorMessage = "Prezzo obbligatorio")]
        public double Prezzo { get; set; }

    }
}