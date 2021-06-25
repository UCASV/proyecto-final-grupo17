﻿using ProyectoFinalPOOBD.VaccineContext;
using ProyectoFinalPOOBD.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalPOOBD.Models;

namespace ProyectoFinalPOOBD.FunctionsMeanwhile
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

        public static List<SideEffectVM> Funcion1V2()
        {
            var sideEffectsVm = new List<SideEffectVM>();
            var context = new VaccinationContext();
            var list = (context.SideEffects.Include(e => e.SideEffectXappointments)
                .GroupBy(s => new {s.Effect})).ToList();

            SideEffectVM helper = new SideEffectVM();
            list.ForEach(s =>
            {
                helper.Effect = s.Key.Effect;
                helper.Amount = s.Select(s => s.SideEffectXappointments).Count();
                sideEffectsVm.Add(helper);
            });
            return sideEffectsVm;
        }
        
    }
        
}
