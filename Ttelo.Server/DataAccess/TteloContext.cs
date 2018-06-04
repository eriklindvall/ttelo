using Microsoft.EntityFrameworkCore;
using Ttelo.Shared.Model;

namespace Ttelo.Server.DataAccess
{
    public class TteloContext : DbContext
    {
        public TteloContext(DbContextOptions<TteloContext> options) : base(options)
        {
        }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<Match> Matches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lindv\source\repos\Ttelo\ttelo.mdf;Integrated Security=True;Connect Timeout=30");
            //}
        }
    }
}
