using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parcial2BD.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2BD.DataAccess.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> entity)
        {
            entity.HasKey(e => e.IdPersona)
                    .HasName("PK__Persona__A478814132A092C5");

            entity.Property(e => e.IdPersona)
                .ValueGeneratedNever()
                .HasColumnName("idPersona");

            entity.Property(e => e.Documento).HasColumnName("documento");

            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaNacimiento");

            entity.Property(e => e.TieneComorbilidad).HasColumnName("tieneComorbilidad");
        }
    }
}
