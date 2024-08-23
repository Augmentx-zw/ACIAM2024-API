using Microsoft.EntityFrameworkCore;
using Ark.Gateway.Domain.Models;

namespace Ark.Gateway.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Abstract> Abstracts { get; set; }
        public DbSet<Committee> Committees { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Article> Articles { get; set; }

    }
}
