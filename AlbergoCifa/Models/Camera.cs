using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlbergoCifa.Models
{
    public class Camera
    {
        public int Id { get; set; }
        public string Descrizione { get; set; }       
        public bool Singola { get; set; }
        public bool Occupata { get; set; }
        public double Prezzo { get; set; }

        public double CalcolaTariffa(DateTime dataFine, DateTime dataInizio)
        {
            return ((dataFine - dataInizio).Days + 1) * Prezzo;
        }
    }
}