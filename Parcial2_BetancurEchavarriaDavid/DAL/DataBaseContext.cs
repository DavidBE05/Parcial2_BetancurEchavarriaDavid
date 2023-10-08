using Microsoft.EntityFrameworkCore;
using Parcial2_BetancurEchavarriaDavid.DAL.Entities;
using System.Diagnostics.Metrics;

namespace Parcial2_BetancurEchavarriaDavid.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<NaturalPerson>().HasIndex(c => c.FullName).IsUnique();
            modelBuilder.Entity<NaturalPerson>().HasIndex(c => c.Email).IsUnique();
        }

        public DbSet<NaturalPerson> NaturalPeople { get; set; }
    }
}
