namespace FinalProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Oggetto")]
    public partial class Oggetto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Oggetto()
        {
            Denuncia = new HashSet<Denuncia>();
        }

        [Key]
        public int idOggetto { get; set; }

        [Column("Oggetto")]
        [DisplayName("Tipo Oggetto")]
        public string Oggetto1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Denuncia> Denuncia { get; set; }
    }
}
