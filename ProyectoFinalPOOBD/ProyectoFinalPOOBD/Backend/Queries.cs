using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalPOOBD.VaccineContext;
using ProyectoFinalPOOBD.ViewModel;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinalPOOBD.Backend
{
    public static class Queries
    {
         // Documento para datos de estadisticas
        //Lista de efectos secundarios y cantidad de apariciones
        // Debido a la incompatibilidad del sistema con los graficos se deja aca el query que obtenia esos datos
        public static List<SideEffectVM> SideEffectStats()
        {
            var sideEffectsVm = new List<SideEffectVM>();
            using (var context = new VaccinationContext())
            {
                var effects = (from f in context.SideEffects
                               join sf in context.SideEffectXappointments
                                   on f.Id equals sf.IdSideEffect
                               select new { f.Effect, sf.IdAppointment }
                               into x
                               group x by new { x.Effect }
                               into g
                               select new
                               {
                                   Effect = g.Key.Effect,
                                   Amount = g.Select(x => x.IdAppointment).Count()
                               }).ToList();

                effects.ForEach(s =>
                {
                    SideEffectVM effect = new();
                    effect.Effect = s.Effect;
                    effect.Amount = s.Amount;

                    sideEffectsVm.Add(effect);
                });
            }
            return sideEffectsVm;
        }

        
        // Se obtiene la cantidad de personas vacunadas una sola vez
        public static int OneVaccination()
        {
            using(var context = new VaccinationContext())
            {
                var vaccinations = (from C in context.Citizens.Include(c => c.Appointments)
                    join A in context.Appointments
                        on C.Id equals A.IdCitizen
                    where C.Appointments.Where(a => a.IdVaccination != null).Count() == 1
                    select new { C.Name, A.IdCitizen }
                    into X
                    group X by new { X.Name, X.IdCitizen }
                    into G
                    select new
                    {
                        Name = G.Key.IdCitizen,
                    }).ToList().Count;
                return vaccinations;

            }          
        }

        // Se obtiene la cantidad de personas vacunadas dos veces
        public static int TwoVaccination()
        {
            using (var context = new VaccinationContext())
            {
                var vaccinations = (from C in context.Citizens.Include(c => c.Appointments)
                    join A in context.Appointments
                        on C.Id equals A.IdCitizen
                    where C.Appointments.Where(a => a.IdVaccination != null).Count() == 2
                    select new { C.Name, A.IdCitizen }
                    into X
                    group X by new { X.Name, X.IdCitizen }
                    into G
                    select new
                    {
                        Name = G.Key.IdCitizen,
                    }).ToList().Count;
                return vaccinations;
            }
        }

        // Lista de enteros con las cantidades de eficiencia de vacunacion
        public static List<int> EfficiencyVaccination()
        {
            // Debido a el tiempo decidimos ejecutar esta consulta con un stored procedure:

            var context = new VaccinationContext();

            // Creamos los parametros output del stored procedure
            var firstParameter = new SqlParameter()
            {
                ParameterName = "FirstRange",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };
            var secondParameter = new SqlParameter()
            {
                ParameterName = "SecondRange",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };
            var thirdParameter = new SqlParameter()
            {
                ParameterName = "ThirdRange",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };
            var lastParameter = new SqlParameter()
            {
                ParameterName = "LastRange",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            // Escribimos el query a ejecutar
            string query =
                "EXEC [dbo].[GetVaccineStatistics] @FirstRange OUTPUT, @SecondRange OUTPUT, @ThirdRange OUTPUT, @LastRange OUTPUT";

            // Ejecutamos el codigo SQL
            var queyrySqlRaw = context.Database.ExecuteSqlRaw(query, firstParameter, secondParameter, thirdParameter, lastParameter);

            // En una lista de enteros agregamos los valores de eficiencia y retornamos
            var efficiencyVaccination = new List<int>()
            {
                ((int) firstParameter.Value),
                ((int) secondParameter.Value),
                ((int) thirdParameter.Value),
                ((int) lastParameter.Value)
            };

            return efficiencyVaccination;
        }
    }
        
}
