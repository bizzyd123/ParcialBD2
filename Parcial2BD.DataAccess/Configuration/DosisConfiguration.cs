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
    public class DosisConfiguration:IEntityTypeConfiguration<Dosis>
    {
        public void Configure(EntityTypeBuilder<Dosis> entity)
        {
            entity.HasKey(e => e.IdDosis)
                    .HasName("PK__Dosis__D6E531D3FEFA54BA");

            entity.Property(e => e.IdDosis).HasColumnName("idDosis");

            entity.Property(e => e.Fecha)
                        .HasColumnType("date")
                        .HasColumnName("fecha");

            entity.Property(e => e.Hora).HasColumnName("hora");

            entity.Property(e => e.IdPersona).HasColumnName("idPersona");

            entity.Property(e => e.IdVacuna).HasColumnName("idVacuna");

            entity.Property(e => e.Vacunatorio)
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnName("vacunatorio");

            entity.HasOne(d => d.IdPersonaNavigation)
                        .WithMany(p => p.Dosis)
                        .HasForeignKey(d => d.IdPersona)
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Dosis__idPersona__59FA5E80");

            entity.HasOne(d => d.IdVacunaNavigation)
                        .WithMany(p => p.Dosis)
                        .HasForeignKey(d => d.IdVacuna)
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Dosis__idVacuna__59063A47");
        }
        
    }
}
