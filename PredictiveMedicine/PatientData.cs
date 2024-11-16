using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal class PatientData
    {
        public int PatientId { get; set; }
        public List<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();
        public List<Treatment> Treatments { get; set; } = new List<Treatment>();
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}
