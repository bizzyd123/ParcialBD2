using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Parcial2BD.DataAccess.Configuration;
using Parcial2BD.DataAccess.Entities;

namespace Parcial2BD.DataAccess.Context
{
    public partial class DdCuidarContext : DbContext
    {
        public DdCuidarContext()
        {
        }

        public DdCuidarContext(DbContextOptions<DdCuidarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dosis> Dosis { get; set; } = null!;
        public virtual DbSet<Persona> Persona { get; set; } = null!;
        public virtual DbSet<Vacuna> Vacuna { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new DosisConfiguration());
            modelBuilder.ApplyConfiguration(new PersonaConfiguration());
            modelBuilder.ApplyConfiguration(new VacunaConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
