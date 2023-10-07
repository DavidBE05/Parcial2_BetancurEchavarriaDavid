using Microsoft.EntityFrameworkCore;
using Parcial2_BetancurEchavarriaDavid.DAL.Entities;
using System.Diagnostics.Metrics;

namespace Parcial2_BetancurEchavarriaDavid.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext>options):base(options)
        {
        }

        public DbSet<NaturalPerson> NaturalPeople { get; set; }
    }
}
