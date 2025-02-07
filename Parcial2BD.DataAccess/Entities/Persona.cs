using System;
using System.Collections.Generic;

namespace Parcial2BD.DataAccess.Entities
{
    public partial class Persona
    {
        public Persona()
        {
            Dosis = new HashSet<Dosis>();
        }

        public int IdPersona { get; set; }
        public long? Documento { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public bool? TieneComorbilidad { get; set; }

        public virtual ICollection<Dosis> Dosis { get; set; }
    }
}
