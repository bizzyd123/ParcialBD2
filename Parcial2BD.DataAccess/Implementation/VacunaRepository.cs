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
    public class VacunaRepository:IVacunaRepository
    {
        private readonly DdCuidarContext _context;

        public VacunaRepository(DdCuidarContext context)
        {
            _context = context;
        }
        public async Task<List<Vacuna>> TraerVacuna(int mesesDesde, int mesesHasta)
        {
            DateTime hoy = DateTime.Now;
            var vacunas = await _context.Vacuna
                .Include(v => v.Dosis) 
                .ToListAsync(); 
            return vacunas
                .Where(v => v.CalcularMesesDesdeElaboracion(hoy) >= mesesHasta &&
                            v.CalcularMesesDesdeElaboracion(hoy) <= mesesDesde)
                .ToList();
        }







    }
}
