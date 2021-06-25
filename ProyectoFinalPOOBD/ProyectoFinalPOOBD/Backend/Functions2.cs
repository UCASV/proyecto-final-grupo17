using System.Collections.Generic;
using System.Linq;
using ProyectoFinalPOOBD.VaccineContext;
using ProyectoFinalPOOBD.ViewModel;

namespace ProyectoFinalPOOBD.Backend
{
    public static class Functions2
    {
         // Documento para datos de estadisticas
        //Lista de efectos
        public static List<SideEffectVM> Consulta1()
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

        public static int OneVaccination()
        {
            var appointmentVM = new List<AppointmentVM>();
            using(var context = new VaccinationContext())
            {
                var vaccinations = (from A in context.Appointments
                                    join C in context.Citizens
                                        on A.IdCitizen equals C.Id
                                    select new { C.Name, A.IdCitizen }
                                    into X
                                    group X by new { X.Name }
                                    into G
                                    where G.Select(X => X.IdCitizen).Count() == 2
                                    select new
                                    {
                                        Name = G.Key.Name,
                                        vaccinations = G.Select(X => X.IdCitizen).Count()
                                    }).ToList().Count();

                

                return vaccinations;

            }
            
        }
    }
        
}
