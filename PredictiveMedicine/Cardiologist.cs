using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal class Cardiologist:Doctor
    {
        public Cardiologist(int id, string firstName, string lastName, string username, string password, string email,
                       ITreatmentStrategy treatmentStrategy, IDataAnalyzer dataAnalyzer)
       : base(id, firstName, lastName, username, password, email, UserRole.Doctor, treatmentStrategy, dataAnalyzer)
        {
            Specialization = "Cardiologist";
        }
    }
}
