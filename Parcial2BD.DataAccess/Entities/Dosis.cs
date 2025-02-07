using System;
using System.Collections.Generic;

namespace Parcial2BD.DataAccess.Entities
{
    public partial class Dosis
    {
        public int IdDosis { get; set; }
        public string Vacunatorio { get; set; }
        public DateTime Fecha { get; set; }
        public int IdVacuna { get; set; }
        public int IdPersona { get; set; }
        public TimeSpan Hora { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Vacuna IdVacunaNavigation { get; set; }
    }
}
