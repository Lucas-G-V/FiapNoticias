using Fiap.Noticias.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.Infra.Data.Context
{
    public class NoticiaDbContext : DbContext
    {
        public NoticiaDbContext(DbContextOptions<NoticiaDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
        public DbSet<Noticia> Noticias { get; set; }
        private DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(255)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NoticiaDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
