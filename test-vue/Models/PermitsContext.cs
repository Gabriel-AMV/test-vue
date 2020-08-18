using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_vue.Models
{
    public class PermitsContext : DbContext
    {
        public DbSet<TipoPermiso> TiposPermisos { get; set; }
        public DbSet<Permiso> Permisos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permiso>()
                        .HasOne(p => p.TipoPermiso)
                        .WithMany(tp => tp.Permisos)
                        .HasForeignKey(p => p.TipoPermisoId);

            // Validations for Permiso table
            modelBuilder.Entity<Permiso>().Property(p => p.NombreEmpleado).IsRequired();
            modelBuilder.Entity<Permiso>().Property(p => p.ApellidosEmpleado).IsRequired();
            modelBuilder.Entity<Permiso>().Property(p => p.Fecha).IsRequired();
            modelBuilder.Entity<Permiso>().Property(p => p.TipoPermisoId).IsRequired();


            // Validations for TipoPermiso table

            modelBuilder.Entity<TipoPermiso>().Property(p => p.Descripcion).IsRequired();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          optionsBuilder.UseSqlServer(@"Server=DESKTOP-GMTTGAO;Database=PermitsDB;Trusted_Connection=True;");
        }

    }
}
