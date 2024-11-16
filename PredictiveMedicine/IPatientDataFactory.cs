using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal interface IPatientDataFactory
    {
        List<PatientData> CreatePatientDataList( /* parameters to specify data source or criteria */);
    }
}
