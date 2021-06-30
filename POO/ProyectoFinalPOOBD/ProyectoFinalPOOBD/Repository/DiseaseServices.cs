using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalPOOBD.Models;
using ProyectoFinalPOOBD.VaccineContext;

namespace ProyectoFinalPOOBD.Repository
{
    public static class DiseaseServices
    {
        // No hace uso de IRepository ya que solo se utiliza para insertar enfermedades
        public static void InsertDiseases(List<Disease> diseases, int idCitizen)
        {
            diseases.ForEach(disease => disease.IdCitizen = idCitizen);

            VaccinationContext context = new VaccinationContext();
            context.Diseases.AddRange(diseases);
            context.SaveChanges();
        }
    }
}
