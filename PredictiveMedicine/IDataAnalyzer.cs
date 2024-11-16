using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal interface IDataAnalyzer
    {
        List<PatientSimilarity> AnalyzeList(List<PatientData> patientData);
    }
}
