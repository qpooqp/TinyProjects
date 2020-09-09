using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace EFCore.SmartTags
{
    public class FooDbContext : DbContext
    {
        //private static readonly LoggerFactory ConsoleLoggerFactory = new LoggerFactory(new[] { new ConsoleLoggerProvider(null) });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=FooDb.db;");
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Foo>().ToTable("Foos");
        }

        public DbSet<Foo> Foos { get; set; }
    }
}
