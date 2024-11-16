using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal interface IDoctor
    {
       public  string Specialization { get; }
       public void TreatPatient(Patient patient, MedicalRecord medicalRecord);
       public List<MedicalRecord> GetMedicalRecords(int patientId);
       public  void AddMedicalRecord(MedicalRecord medicalRecord);
    }
}
