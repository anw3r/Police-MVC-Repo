using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FinalProject
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<Cittadino> Cittadino { get; set; }
        public virtual DbSet<Denuncia> Denuncia { get; set; }
        public virtual DbSet<Oggetto> Oggetto { get; set; }
        public virtual DbSet<sysdiagrams> Sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cittadino>()
                .HasMany(e => e.Denuncia)
                .WithOptional(e => e.Denunciante)
                .HasForeignKey(e => e.idDenunc);

            modelBuilder.Entity<Cittadino>()
                .HasMany(e => e.Denuncia1)
                .WithOptional(e => e.Trovante)
                .HasForeignKey(e => e.idTrova);

            modelBuilder.Entity<Oggetto>()
                .HasMany(e => e.Denuncia)
                .WithRequired(e => e.Oggetto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Denuncia)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.Agente);
        }
    }
}
