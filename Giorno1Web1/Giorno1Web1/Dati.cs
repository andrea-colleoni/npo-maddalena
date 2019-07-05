namespace Giorno1Web1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Dati : DbContext
    {
        public Dati()
            : base("name=Dati1")
        {
            Database.SetInitializer<Dati>(null);
        }

        public virtual DbSet<Fatture> Fatture { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fatture>()
                .Property(e => e.nome)
                .IsUnicode(false);
        }
    }
}
