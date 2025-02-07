using Microsoft.EntityFrameworkCore;
using Parcial2BD.DataAccess.Entities;
using Parcial2BD.DataAccess.Implementation;
using Parcial2BD.DataAccess.Interfaces;
using Parcial2BD.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2BD.Services.Implementation
{
    public class VacunaService : IVacunaService
    {
        private readonly IVacunaRepository _vacunaRepository;
        private readonly IPersonaRepository _personaRepository;
        private readonly IDosisRepository _dosisRepository;

        public VacunaService(IVacunaRepository vacunaRepository, IPersonaRepository personaRepository, IDosisRepository dosisRepository)
        {
            _vacunaRepository = vacunaRepository;
            _personaRepository = personaRepository;
            _dosisRepository = dosisRepository;
        }
       

        public async Task<List<Dosis>> TraerDosis(Persona persona)
        {
            return await _dosisRepository.TraerDosis(persona);
        }
        public async Task<List<Dosis>> TraerDosis(DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _dosisRepository.TraerDosis(fechaDesde, fechaHasta);
        }
        public async Task<List<Dosis>> TraerDosis(DateTime fechaDesde, DateTime fechaHasta, bool tieneComorbilidades)
        {
            return await _dosisRepository.TraerDosis(fechaDesde,fechaHasta,tieneComorbilidades);
        }
        public async Task<Persona> TraerPersona(long documento) 
        {
            return await _personaRepository.TraerPersona(documento);
        }
        public async Task<List<Vacuna>> TraerVacuna(int mesesDesde, int mesesHasta)
        {
            return await _vacunaRepository.TraerVacuna(mesesDesde, mesesHasta);
        }
     



    }
}
