using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Panaderia_DonDonas_NET_Core.Entities;
using System.Reflection.Metadata;

namespace Panaderia_DonDonas_NET_Core
{
    public class ApplicationDbContext : IdentityDbContext

    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Donut> Donut { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
