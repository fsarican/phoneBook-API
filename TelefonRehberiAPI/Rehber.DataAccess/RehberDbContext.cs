using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Rehber.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rehber.DataAccess
{
    public class RehberDbContext : DbContext
    {
        public virtual DbSet<Kisiler> Kisilers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
             .UseMySql("server=localhost;user=furkan;password=furkan76;database=RehberDb")
             .UseLoggerFactory(LoggerFactory.Create(b => b
                 .AddFilter(level => level >= LogLevel.Information)))
             .EnableSensitiveDataLogging()
             .EnableDetailedErrors();
        }
    }
}
