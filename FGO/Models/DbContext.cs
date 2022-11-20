using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using FGO.Models;

namespace FGO.Models
{
    public class FGODBContext:DbContext
    {
        protected readonly IConfiguration Configuration;
        public FGODBContext(DbContextOptions<FGODBContext> options, IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("FGO");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Servants> Servants { get; set; } = null!;
        public DbSet<NoblePhantasm> NoblePhantasms { get; set; } = null!;
    }
}
