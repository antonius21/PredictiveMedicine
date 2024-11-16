using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal interface IMedicalRecordRepository
    {
        List<MedicalRecord> GetMedicalRecordsByPatientId(int patientId);
        void AddMedicalRecord(MedicalRecord record);
    }
}
