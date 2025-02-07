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
    public class PersonaRepository : IPersonaRepository
    {
        private readonly DdCuidarContext _context;

        public PersonaRepository(DdCuidarContext context)
        {
            _context = context;
        }
       
        public async Task<Persona> TraerPersona(long documento)
        {
            try
            {
                var persona = await _context.Persona
                                             .FirstOrDefaultAsync(x => x.Documento == documento);
                return persona;
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Error al traer la persona: {ex.Message}");

                
                return null;
            }
        }


    }
}
