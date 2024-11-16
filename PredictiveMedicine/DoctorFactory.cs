using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal class DoctorFactory
    {
        public IDoctor CreateDoctor(string specialization, int id, string firstName, string lastName, string username, string password, string email, ITreatmentStrategy treatmentStrategy, IDataAnalyzer dataAnalyzer)
        {
            switch (specialization.ToLower())
            {
                case "cardiologist":
                    return new Cardiologist(id, firstName, lastName, username, password, email, treatmentStrategy, dataAnalyzer);
                case "oncologist":
                    return new Oncologist(id, firstName, lastName, username, password, email, treatmentStrategy, dataAnalyzer);
                case "general practitioner":
                    return new GeneralPractitioner(id, firstName, lastName, username, password, email, treatmentStrategy, dataAnalyzer);
                // Add more specializations here...
                default:
                    throw new ArgumentException($"Unknown specialization: {specialization}");
            }
        }
    }
}
