using EzQwez.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EzQwez.Infrastructure.EntityFrameworkDataAccess
{
    public sealed class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=EzQwez;Username=postgres;Password=o9gtBXIPvH8e8jMz7BTaowD8BskHqipjp3YcfkWzSSrc9AC5V7hYo26GMiTpSd0");

        public DbSet<Phrase> Phrases { get; set; }
    }
}
