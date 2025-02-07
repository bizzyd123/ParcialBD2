using Parcial2BD.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2BD.DataAccess.Interfaces
{
    public interface IPersonaRepository
    {
        Task<Persona> TraerPersona(long documento);
    }
}
