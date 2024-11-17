using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal class Doctor : User, IDoctor
    {
        private readonly ITreatmentStrategy _treatmentStrategy;
        private readonly IDataAnalyzer _dataAnalyzer;

        public Doctor(int id, string firstName, string lastName, string username, string password, string email, UserRole role,
                      ITreatmentStrategy treatmentStrategy, IDataAnalyzer dataAnalyzer) : base(id, firstName, lastName, username, password, email, role)
        {
            _treatmentStrategy = treatmentStrategy ?? throw new ArgumentNullException(nameof(treatmentStrategy));
            _dataAnalyzer = dataAnalyzer ?? throw new ArgumentNullException(nameof(dataAnalyzer));
        }

        public string Specialization { get; set; } // Add Specialization property


        public void TreatPatient(Patient patient, MedicalRecord medicalRecord)
        {
            _treatmentStrategy.Treat(patient, medicalRecord);
        }

        public List<MedicalRecord> GetMedicalRecords(int patientId)
        {
            //Implementation to fetch medical records, typically interacting with a database.
            //This would likely use a repository pattern for data access
            throw new NotImplementedException();
        }

        public void AddMedicalRecord(MedicalRecord medicalRecord)
        {
            //Implementation to add medical record, typically interacting with a database.
            //This would likely use a repository pattern for data access.
            throw new NotImplementedException();
        }
    }
}
