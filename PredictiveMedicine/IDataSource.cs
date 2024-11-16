using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal interface IDataSource
    {
        List<PatientData> GetPatientData(string criteria = null);
    }
}
