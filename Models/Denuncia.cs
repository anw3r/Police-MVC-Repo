namespace FinalProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Denuncia")]
    public partial class Denuncia
    {
        [Key]
        public int idDenuncia { get; set; }

        [Required]
        public string Tipo { get; set; }

        [DisplayName("Data Denuncia")]
        public DateTime DataDenuncia { get; set; }

        [DisplayName("Tipo oggetto")]
        public int IdOggetto { get; set; }

        public string Descrizione { get; set; }

        [DisplayName("Data Accadimento")]
        public DateTime? DataAcca { get; set; }

        [DisplayName("Denunciante")]
        public int? idDenunc { get; set; }

        [DisplayName("Foto Oggetto")]
        public string FotoOggetto { get; set; }

        [StringLength(20)]
        [DisplayName("Nominativo Agente")]
        public string Agente { get; set; }

        [DisplayName("Data Ritrovo")]
        public DateTime? DataRitrovo { get; set; }

        [DisplayName("Trovante")]
        public int? idTrova { get; set; }

        [DisplayName("E' Stato Trovato?")]
        public bool IsTrovato { get; set; }

        public virtual Cittadino Denunciante { get; set; }

        public virtual Cittadino Trovante { get; set; }

        public virtual User User { get; set; }

        public virtual Oggetto Oggetto { get; set; }
    }
}
