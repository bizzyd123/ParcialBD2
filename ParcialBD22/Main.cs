using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Parcial2BD;
using Parcial2BD.DataAccess.Context;
using Parcial2BD.DataAccess.Implementation;
using Parcial2BD.DataAccess.Interfaces;
using Parcial2BD.Services.Implementation;
using Parcial2BD.Services.Interfaces;

class Program
{
    static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        // Obtener el IServiceProvider
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            IVacunaService sistema = services.GetRequiredService<IVacunaService>();
            
            //TEST 1
            Console.WriteLine("TEST 1");
            try
            {
                var persona = await sistema.TraerPersona(33333333);
                if (persona != null)
                {
                    Console.WriteLine($"Persona encontrada:");
                    Console.WriteLine($"ID: {persona.IdPersona}");
                    Console.WriteLine($"Documento: {persona.Documento}");
                    Console.WriteLine($"Fecha de nacimiento: {persona.FechaNacimiento}");
                    Console.WriteLine($"Comorbilidad: {persona.TieneComorbilidad}");

                }
                else
                {
                    Console.WriteLine("No se encontró el permiso con el ID especificado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

            }
            //test 2
            Console.WriteLine("TEST 2");
            try
            {
                var vacunas = await sistema.TraerVacuna(1, 2);

                if (vacunas != null && vacunas.Count > 0)
                {
                    Console.WriteLine("Vacunas encontradas:");

                    foreach (var vacuna in vacunas)
                    {
                        Console.WriteLine($"ID: {vacuna.IdVacuna}, Nombre: {vacuna.Nombre}, Fecha de Elaboración: {vacuna.FechaElaboracion.ToShortDateString()}");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron vacunas fabricadas entre 1 y 2 meses.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            //TEST 3
            Console.WriteLine("TEST 3");
            try
            {
                var persona = await sistema.TraerPersona(33333333);
                var dosisAplicadas = await sistema.TraerDosis(persona);
                if (dosisAplicadas != null && dosisAplicadas.Count > 0)
                {
                    Console.WriteLine($"dosis aplicadas en persona con documento{persona.Documento} :");

                    foreach (var dosis in dosisAplicadas)
                    {
                        Console.WriteLine($"- ID Dosis: {dosis.IdDosis}, Nombre: {dosis.IdVacunaNavigation.Nombre}");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron dosis aplicadas para esta persona.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

            }

            Console.WriteLine("TEST 4");
            try
            {
                var dosisAplicadas = await sistema.TraerDosis(new DateTime(2020,06,01), new DateTime(2020, 06, 15));
                if (dosisAplicadas != null )
                {
                    foreach (var dosis in dosisAplicadas)
                    {
                        Console.WriteLine($"- ID Dosis: {dosis.IdDosis}, Nombre: {dosis.IdVacunaNavigation.Nombre}");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron dosis aplicadas para esta persona.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

            }
            //TEST 5

            Console.WriteLine("TEST 5");
            try
            {
               
                var dosisAplicadas = await sistema.TraerDosis(new DateTime(2020, 06, 01), new DateTime(2020, 06, 15),true);
                if (dosisAplicadas != null)
                {
                    foreach (var dosis in dosisAplicadas)
                    {
                        Console.WriteLine($"- ID Dosis: {dosis.IdDosis}, Nombre: {dosis.IdVacunaNavigation.Nombre}, comorbolidad: {dosis.IdPersonaNavigation.TieneComorbilidad}");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron dosis aplicadas para esta persona.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

            }



        }
        static IHostBuilder CreateHostBuilder(string[] args) =>

              Host.CreateDefaultBuilder(args)
                  .ConfigureAppConfiguration((hostContext, configurationBuilder) =>
                  {
                      configurationBuilder.SetConfigurationFiles();
                  })
                  .ConfigureServices((HostingServices, services) =>
                  {
                      //transient crea una nueva instancia para cada ejecucion
                      services.AddTransient<IDosisRepository, DosisRepository>();
                      services.AddTransient<IPersonaRepository, PersonaRepository>();
                      services.AddTransient<IVacunaRepository, VacunaRepository>();
                      //scoped crea una sola instancia para cadaejecucion en el mismo contexto
                      services.AddScoped<IVacunaService, VacunaService>();

                      /// services.Configure<ConsoleLifetimeOptions>(options => options.SuppressStatusMessages = true);

                      services.AddDbContext<DdCuidarContext>(options =>
                       options.UseSqlServer(HostingServices.Configuration.GetConnectionString("DefaultConnection")));


                  });
    }
}