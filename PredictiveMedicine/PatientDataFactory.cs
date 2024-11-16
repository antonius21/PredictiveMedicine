using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal class PatientDataFactory:IPatientDataFactory
    {
        private readonly DB _db;

        public PatientDataFactory(DB db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public List<PatientData> CreatePatientDataList()
        {
            List<PatientData> patientDataList = new List<PatientData>();
            DataTable dt = _db.GetPatientData();


            foreach (DataRow row in dt.Rows)
            {
                PatientData patientData = new PatientData
                {
                    PatientId = Convert.ToInt32(row["PatientId"]),
                    DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                    Gender = row["Gender"].ToString()

                    //Add other mappings.  You'll need to map the columns from your database table to the PatientData class properties.
                };

                //Add diagnosis and treatment mapping here

                patientDataList.Add(patientData);
            }

            return patientDataList;
        }
    }
}
