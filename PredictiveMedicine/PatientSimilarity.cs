using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal class PatientSimilarity
    {
        public int PatientId1 { get; set; }
        public int PatientId2 { get; set; }
        public double SimilarityScore { get; set; }
    }
}
