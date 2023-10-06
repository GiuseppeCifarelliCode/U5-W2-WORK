using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlbergoCifa.Models
{
    public class RichiestaServizio
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Data obbligatoria")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Quantità obbligatorio")]
        public int Quantita { get; set; }
        public int IdPrenotazione { get; set; }
        public int IdServizio { get; set; }

        public static double CalcolaCostoTotale(List<RichiestaServizio> list)
        {
            double tot = 0;
            foreach(RichiestaServizio r in list)
            {
                double prezzoServizio = DB.getPrezzoServizioByIdServizio(r.IdServizio);
                tot += prezzoServizio * r.Quantita;
            }
            return tot;
        }

    }
}