using Microsoft.EntityFrameworkCore;
using Parcial2BD.DataAccess.Context;
using Parcial2BD.DataAccess.Entities;
using Parcial2BD.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2BD.DataAccess.Implementation
{
    public class DosisRepository:IDosisRepository
    {
        private readonly DdCuidarContext _context;

        public DosisRepository(DdCuidarContext context)
        {
            _context = context;
        }
        public async Task<List<Dosis>> TraerDosis(Persona persona)
        {
            return await _context.Dosis
                .Include(d => d.IdVacunaNavigation) 
                .Include(d => d.IdPersonaNavigation) 
                .Where(d => d.IdPersona == persona.IdPersona) 
                .ToListAsync();
        }


        public async Task<List<Dosis>> TraerDosis(DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _context.Dosis
                .Include(d => d.IdVacunaNavigation) 
                .Include(d => d.IdPersonaNavigation) 
                .Where(d => d.Fecha >= fechaDesde && d.Fecha <= fechaHasta) 
                .ToListAsync();
        }

        public async Task<List<Dosis>> TraerDosis(DateTime fechaDesde, DateTime fechaHasta, bool tieneComorbilidades)
        {
            return await _context.Dosis
                .Include(d => d.IdVacunaNavigation) 
                .Include(d => d.IdPersonaNavigation) 
                .Where(d => d.Fecha >= fechaDesde && d.Fecha <= fechaHasta &&
                            d.IdPersonaNavigation.TieneComorbilidad == tieneComorbilidades) 
                .ToListAsync();
        }

    }
}
