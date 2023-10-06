using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlbergoCifa.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Cognome obbligatorio")]
        public string Cognome { get; set; }
        [Required(ErrorMessage = "Nome obbligatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Codice Fiscale obbligatorio")]
        public string CF { get; set; }
        [Required(ErrorMessage = "Provincia obbligatoria")]
        public string Provincia { get; set; }
        [Required(ErrorMessage = "Città obbligatoria")]
        public string Citta { get; set; }
        [Required(ErrorMessage = "Email obbligatoria")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefono obbligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Cellulare obbligatorio")]
        public string Cellulare { get; set; }

    }
}