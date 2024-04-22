using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace VolleyVerse.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Abbonati> Abbonati { get; set; }
        public virtual DbSet<Calendario> Calendario { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Coach> Coach { get; set; }
        public virtual DbSet<Contatti> Contatti { get; set; }
        public virtual DbSet<Giocatori> Giocatori { get; set; }
        public virtual DbSet<Notizie> Notizie { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<Squadra> Squadra { get; set; }
        public virtual DbSet<Utenti> Utenti { get; set; }
        public virtual DbSet<Vendite> Vendite { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calendario>()
                .Property(e => e.location)
                .IsUnicode(false);

            modelBuilder.Entity<Coach>()
                .HasMany(e => e.Squadra)
                .WithRequired(e => e.Coach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Giocatori>()
                .Property(e => e.Altezza)
                .HasPrecision(3, 2);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Utenti)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shop>()
                .Property(e => e.item_price)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Shop>()
                .HasMany(e => e.Cart)
                .WithRequired(e => e.Shop)
                .HasForeignKey(e => e.shop_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Squadra>()
                .HasMany(e => e.Calendario)
                .WithOptional(e => e.Squadra)
                .HasForeignKey(e => e.away_team_id);

            modelBuilder.Entity<Squadra>()
                .HasMany(e => e.Calendario1)
                .WithRequired(e => e.Squadra1)
                .HasForeignKey(e => e.team_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Squadra>()
                .HasMany(e => e.Calendario2)
                .WithRequired(e => e.Squadra2)
                .HasForeignKey(e => e.team_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Squadra>()
                .HasMany(e => e.Giocatori)
                .WithRequired(e => e.Squadra)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Utenti>()
                .HasMany(e => e.Abbonati)
                .WithRequired(e => e.Utenti)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Utenti>()
                .HasMany(e => e.Cart)
                .WithRequired(e => e.Utenti)
                .WillCascadeOnDelete(false);
        }
    }
}
