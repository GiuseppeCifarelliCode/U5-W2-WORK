using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlbergoCifa.Models
{
    public class Prenotazione
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Data Prenotazione obbligatoria")]
        public DateTime DataPrenotazione { get; set; }
        [Required(ErrorMessage = "Anno obbligatorio")]
        public string Anno { get; set; }
        [Required(ErrorMessage = "Data Inizio obbligatoria")]
        public DateTime DataInizio { get; set; }
        [Required(ErrorMessage = "Data Fine obbligatoria")]
        public DateTime DataFine { get; set; }
        [Required(ErrorMessage = "Caparra obbligatoria")]
        public double Caparra { get; set; }
        public double Tariffa { get; set; }
        public bool MezzaPensione { get; set; }
        public bool PrimaColazione { get; set; }
        public bool Conclusa { get; set; }
        public int IdCliente { get; set; }
        public int IdCamera { get; set; }

    }
}