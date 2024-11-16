using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal class OncologistTreatmentStrategy : ITreatmentStrategy
    {
        public void Treat(Patient patient, MedicalRecord medicalRecord)
        {
            // Simulate oncologist treatment logic (WinForms integration)
            string treatmentPlan = $"Oncologist treatment plan for {patient.FirstName} {patient.LastName}:\n" +
                                   $"  - Review medical history and imaging\n" +
                                   $"  - Discuss treatment options (chemotherapy, radiation, surgery)\n" +
                                   $"  - Schedule follow-up appointments";

            MessageBox.Show(treatmentPlan, "Oncologist Treatment Plan", MessageBoxButtons.OK, MessageBoxIcon.Information);

           
        }
    }
}
