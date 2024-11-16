using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PredictiveMedicine
{
    internal class MachineLearningAnalyzer : IDataAnalyzer
    {
        public MachineLearningAnalyzer() { }

        public List<PatientSimilarity> AnalyzeList(List<PatientData> patientData)
        {
            return patientData.SelectMany((patient1, index1) =>
                patientData.Skip(index1 + 1).Select((patient2, index2) =>
                {
                    //Calculate a simple similarity score based on the number of shared diagnoses and treatments
                    int sharedDiagnoses = patient1.Diagnoses.Intersect(patient2.Diagnoses).Count();
                    int sharedTreatments = patient1.Treatments.Intersect(patient2.Treatments).Count();
                    double similarityScore = (double)(sharedDiagnoses + sharedTreatments) / (patient1.Diagnoses.Count + patient1.Treatments.Count + patient2.Diagnoses.Count + patient2.Treatments.Count);

                    //Handle division by zero:
                    similarityScore = double.IsNaN(similarityScore) ? 0 : similarityScore;


                    return new PatientSimilarity
                    {
                        PatientId1 = patient1.PatientId,
                        PatientId2 = patient2.PatientId,
                        SimilarityScore = similarityScore
                    };
                })).ToList();
        }
    }
}
