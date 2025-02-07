using System;
using System.Collections.Generic;

namespace Parcial2BD.DataAccess.Entities
{
    public partial class Vacuna
    {
        public Vacuna()
        {
            Dosis = new HashSet<Dosis>();
        }

        public int IdVacuna { get; set; }
        public int? Codigo { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaElaboracion { get; set; }

        public virtual ICollection<Dosis> Dosis { get; set; }

        public int CalcularMesesDesdeElaboracion(DateTime hoy)
        {
            // Si la vacuna no tiene fecha de elaboración, retornamos 0
            if (FechaElaboracion == DateTime.MinValue)
            {
                return 0;
            }

            // Calculamos los meses desde la fecha de elaboración
            int mesesDesdeElaboracion = ((hoy.Year - FechaElaboracion.Year) * 12) + hoy.Month - FechaElaboracion.Month;

            // Ajustamos si el día actual es menor al día de la fecha de elaboración
            if (hoy.Day < FechaElaboracion.Day)
            {
                mesesDesdeElaboracion--;
            }

            return mesesDesdeElaboracion;
        }
    }
}
