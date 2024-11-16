using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal interface ITreatmentStrategy
    {
        void Treat(Patient patient, MedicalRecord medicalRecord);
    }
}
