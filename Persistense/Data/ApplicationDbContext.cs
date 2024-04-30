using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistense.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistense.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new FemaleCharacterConfiguration());
            modelBuilder.ApplyConfiguration(new MaleCharacterConfiguration());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<MaleCharacter> MaleCharacters { get; set; }
        public DbSet<FemaleCharacter> FemaleCharacters { get; set; }
    }
}
