using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal class CardiologistTreatmentStrategy : ITreatmentStrategy
    {
        public void Treat(Patient patient, MedicalRecord medicalRecord)
        {
            // Simulate cardiologist treatment logic (WinForms integration)
            string treatmentPlan = $"Cardiologist treatment plan for {patient.FirstName} {patient.LastName}:\n" +
                                   $"  - Review medical history\n" +
                                   $"  - Perform ECG\n" +
                                   $"  - Prescribe medication (if necessary)\n" +
                                   $"  - Recommend lifestyle changes";

            MessageBox.Show(treatmentPlan, "Cardiologist Treatment Plan", MessageBoxButtons.OK, MessageBoxIcon.Information);

           
        }
    }
}
