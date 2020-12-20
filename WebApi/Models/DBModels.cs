using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApi.Models
{
    public partial class DBModels : DbContext
    {
        public DBModels()
            : base("name=DBModels")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Cinemas> Cinemas { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        //public virtual DbSet<Cinema> Cinema { get; set; }
        //public virtual DbSet<City> City { get; set; }
        //public virtual DbSet<Country> Country { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinemas>()
                .HasMany(e => e.Cities)
                .WithMany(e => e.Cinemas)
                .Map(m => m.ToTable("CityCinemas").MapLeftKey("Cinema_id_cinema").MapRightKey("City_id_city"));

            modelBuilder.Entity<Countries>()
                .HasMany(e => e.Cities)
                .WithOptional(e => e.Countries)
                .HasForeignKey(e => e.Country_id_country);
        }
    }
}
