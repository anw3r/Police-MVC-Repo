namespace FinalProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cittadino")]
    public partial class Cittadino
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cittadino()
        {
            Denuncia = new HashSet<Denuncia>();
            Denuncia1 = new HashSet<Denuncia>();
        }

        [Key]
        public int idCittadino { get; set; }

        public string Nome { get; set; }

        public string Cognome { get; set; }

        public string Residenza { get; set; }

        public string Indirizzo { get; set; }

        [DisplayName("Numero di Telefono")]
        public string Numero { get; set; }

        [DisplayName("Tipo Documento")]
        public string TipoDocumento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Denuncia> Denuncia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Denuncia> Denuncia1 { get; set; }
    }
}
