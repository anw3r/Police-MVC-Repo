namespace FinalProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Denuncia = new HashSet<Denuncia>();
        }

        [Key]
        [StringLength(20)]
        [Required]
        //[Remote("IsAlreadySigned","Home", AdditionalFields = "username", ErrorMessage = "Username Corretto")]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [StringLength(20)]
        [DisplayName("Ruolo")]
        public string Role { get; set; }

        [StringLength(20)]
        public string Nome { get; set; }

        [StringLength(20)]
        public string Cognome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Denuncia> Denuncia { get; set; }
    }
}
