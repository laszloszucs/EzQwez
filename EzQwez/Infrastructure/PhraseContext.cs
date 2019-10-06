using System;
using System.Reflection;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class PhraseContext : DbContext
    {
        public DbSet<Phrase> Phrases { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}/data.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phrase>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.English).IsRequired();
                entity.Property(e => e.Hungarian).IsRequired();
                entity.HasIndex(e => e.English).IsUnique();
                entity.HasIndex(e => e.Hungarian).IsUnique();
            });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
