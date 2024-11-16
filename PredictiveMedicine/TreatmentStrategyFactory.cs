using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal class TreatmentStrategyFactory
    {
        public ITreatmentStrategy CreateTreatmentStrategy(string specialization)
        {
            switch (specialization.ToLower())
            {
                case "cardiologist":
                    return new CardiologistTreatmentStrategy();
                case "oncologist":
                    return new OncologistTreatmentStrategy();
              //case "general practitioner":
                  //return new GeneralPractitionerTreatmentStrategy();
                // Add more specializations here...
                default:
                    throw new ArgumentException($"Unknown specialization: {specialization}");
            }
        }
    }
}
