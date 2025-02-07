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
    public class VacunaConfiguration : IEntityTypeConfiguration<Vacuna>
    {
        public void Configure(EntityTypeBuilder<Vacuna> entity)
        {

            entity.HasKey(e => e.IdVacuna)
                    .HasName("PK__Vacuna__09AF7EB7CB4E7240");

            entity.Property(e => e.IdVacuna)
                        .ValueGeneratedNever()
                        .HasColumnName("idVacuna");

            entity.Property(e => e.Codigo).HasColumnName("codigo");

            entity.Property(e => e.FechaElaboracion)
                        .HasColumnType("datetime")
                        .HasColumnName("fechaElaboracion");

            entity.Property(e => e.Nombre)
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnName("nombre");
        }
    }
}
