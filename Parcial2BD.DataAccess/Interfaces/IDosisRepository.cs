using Parcial2BD.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2BD.DataAccess.Interfaces
{
    public interface IDosisRepository
    {
        Task<List<Dosis>> TraerDosis(Persona persona);
        Task<List<Dosis>> TraerDosis(DateTime fechaDesde, DateTime fechaHasta);
        Task<List<Dosis>> TraerDosis(DateTime fechaDesde, DateTime fechaHasta, bool tieneComorbilidades);
    }
}
