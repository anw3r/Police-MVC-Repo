using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Cuscinetto
    {
        
        public string Tipo { get; set; }
        public string NomeOggetto { get; set; }
        public DateTime DataDenuncia { get; set; }
        public string Descrizione { get; set; }
        public DateTime? DataAcca { get; set; }
        public string Denuncatore { get; set; }

        public string Foto { get; set; }
        public string Agente { get; set; }
        public DateTime? DataRitrovo { get; set; }
        public string idTrova { get; set; }
        public bool IsTrovato { get; set; }
    }
}