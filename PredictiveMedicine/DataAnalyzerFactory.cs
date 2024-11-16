using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal class DataAnalyzerFactory
    {
        public IDataAnalyzer CreateDataAnalyzer(string analysisType)
        {
            switch (analysisType.ToLower())
            {
                case "machinelearning":
                    return new MachineLearningAnalyzer();
                case "statistical":
                    return new StatisticalAnalyzer();
                // Add more analysis types here...
                default:
                    throw new ArgumentException($"Unknown analysis type: {analysisType}");
            }
        }
    }
}
