using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal class StatisticalAnalyzer:IDataAnalyzer
    {
        public List<PatientSimilarity> AnalyzeList(List<PatientData> patientData)
        {
            // Perform statistical analysis (correlation) to calculate similarity scores
            Console.WriteLine("Performing statistical analysis...");

            //This simplified algorithm calculates the Pearson correlation coefficient between the number of diagnoses and treatments.

            return patientData.SelectMany((patient1, index1) =>
                patientData.Skip(index1 + 1).Select((patient2, index2) =>
                {
                    //Calculate correlation coefficient

                    double[] data1 = { patient1.Diagnoses.Count, patient1.Treatments.Count };
                    double[] data2 = { patient2.Diagnoses.Count, patient2.Treatments.Count };

                    double correlation = PearsonCorrelation(data1, data2);

                    return new PatientSimilarity
                    {
                        PatientId1 = patient1.PatientId,
                        PatientId2 = patient2.PatientId,
                        SimilarityScore = correlation
                    };
                })).ToList();
        }

        //Helper function to calculate Pearson correlation coefficient
        private double PearsonCorrelation(double[] data1, double[] data2)
        {
            if (data1.Length != data2.Length || data1.Length < 2)
            {
                return 0; // Handle cases with unequal lengths or insufficient data
            }

            double sumX = data1.Sum();
            double sumY = data2.Sum();
            double sumXY = data1.Zip(data2, (x, y) => x * y).Sum();
            double sumX2 = data1.Sum(x => x * x);
            double sumY2 = data2.Sum(y => y * y);
            int n = data1.Length;

            double numerator = n * sumXY - sumX * sumY;
            double denominator = Math.Sqrt((n * sumX2 - sumX * sumX) * (n * sumY2 - sumY * sumY));


            //Handle division by zero
            if (denominator == 0)
            {
                return 0;
            }

            return numerator / denominator;
        }
    }
}
