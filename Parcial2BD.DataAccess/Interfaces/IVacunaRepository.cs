using Parcial2BD.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2BD.DataAccess.Interfaces
{
    public interface IVacunaRepository
    {
        Task<List<Vacuna>> TraerVacuna(int mesesDesde, int mesesHasta);
    }
}
