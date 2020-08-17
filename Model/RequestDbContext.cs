using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class RequestDbContext :IdentityDbContext
    {
        public RequestDbContext()
        {

        }

        public RequestDbContext(DbContextOptions<RequestDbContext> options) : base(options) { 
           
        }
        public DbSet<Size> sizes { get; set; }
        public DbSet<Colors> colors { get; set; }
        public DbSet<Requests> requests { get; set; }
        public DbSet<DesignTopology> designTopology { get; set; }
        public DbSet<RequestedModelSpecifications> requestedModelSpedcifications { get; set; }
        public DbSet<clients> client { get; set; }
        public DbSet<Surface> surface { get; set; }
        public DbSet<DesignersInvolved> designersInvolved { get; set; }
        public DbSet<Designers> designers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-MJUQNB0\\SQLEXPRESS;Initial Catalog=RequestsDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
