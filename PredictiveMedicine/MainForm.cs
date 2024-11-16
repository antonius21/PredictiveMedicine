using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal class MainForm:Form
    {
        private DoctorFactory _doctorFactory = new DoctorFactory();
        private TreatmentStrategyFactory _treatmentStrategyFactory = new TreatmentStrategyFactory();
        private DataAnalyzerFactory _dataAnalyzerFactory = new DataAnalyzerFactory();
        private PatientDataFactory _patientDataFactory = new PatientDataFactory(new DB { ConnectionString = "YourConnectionStringHere" }); //Replace with your connection string


        public MainForm()
        {
            InitializeComponent();
            // Populate comboboxes
            cboSpecialization.Items.AddRange(new string[] { "Cardiologist", "Oncologist", "General Practitioner" }); // Add more specializations
            cboAnalysisType.Items.AddRange(new string[] { "MachineLearning", "Statistical" }); // Add more analysis types

            cboSpecialization.SelectedIndex = 0;  // Set a default selection
            cboAnalysisType.SelectedIndex = 0;

        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            try
            {
                string specialization = cboSpecialization.SelectedItem.ToString();
                string analysisType = cboAnalysisType.SelectedItem.ToString();


                ITreatmentStrategy treatmentStrategy = _treatmentStrategyFactory.CreateTreatmentStrategy(specialization);
                IDataAnalyzer dataAnalyzer = _dataAnalyzerFactory.CreateDataAnalyzer(analysisType);
                List<PatientData> patientData = _patientDataFactory.CreatePatientDataList();

                //Create a Doctor object.  You may need to refactor your DoctorFactory to accept analysis and treatment strategies directly
                //IDoctor doctor = _doctorFactory.CreateDoctor(specialization, 1, "Jane", "Doe", "jdoe", "password", "jane.doe@email.com", treatmentStrategy, dataAnalyzer); 

                //Perform Analysis
                List<PatientSimilarity> results = dataAnalyzer.AnalyzeList(patientData);

                // Display results (replace with your preferred method of displaying the results)
                txtResults.Text = "Analysis Results:\n";
                foreach (PatientSimilarity result in results)
                {
                    txtResults.Text += $"Patient {result.PatientId1} and Patient {result.PatientId2}: Similarity Score = {result.SimilarityScore:F2}\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Analysis Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Generated WinForms elements (You need to actually create these in the designer)
        private System.Windows.Forms.ComboBox cboSpecialization;
        private System.Windows.Forms.ComboBox cboAnalysisType;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.TextBox txtResults;
        //Add other needed elements as needed



        private void InitializeComponent()
        {
            cboSpecialization = new ComboBox();
            cboAnalysisType = new ComboBox();
            btnAnalyze = new Button();
            txtResults = new TextBox();
            SuspendLayout();
            // 
            // cboSpecialization
            // 
            cboSpecialization.FormattingEnabled = true;
            cboSpecialization.Location = new Point(14, 14);
            cboSpecialization.Margin = new Padding(4, 3, 4, 3);
            cboSpecialization.Name = "cboSpecialization";
            cboSpecialization.Size = new Size(140, 23);
            cboSpecialization.TabIndex = 0;
            // 
            // cboAnalysisType
            // 
            cboAnalysisType.FormattingEnabled = true;
            cboAnalysisType.Location = new Point(162, 14);
            cboAnalysisType.Margin = new Padding(4, 3, 4, 3);
            cboAnalysisType.Name = "cboAnalysisType";
            cboAnalysisType.Size = new Size(140, 23);
            cboAnalysisType.TabIndex = 1;
            // 
            // btnAnalyze
            // 
            btnAnalyze.Location = new Point(310, 12);
            btnAnalyze.Margin = new Padding(4, 3, 4, 3);
            btnAnalyze.Name = "btnAnalyze";
            btnAnalyze.Size = new Size(88, 27);
            btnAnalyze.TabIndex = 2;
            btnAnalyze.Text = "Analyze";
            btnAnalyze.UseVisualStyleBackColor = true;
            btnAnalyze.Click += btnAnalyze_Click;
            // 
            // txtResults
            // 
            txtResults.Location = new Point(14, 45);
            txtResults.Margin = new Padding(4, 3, 4, 3);
            txtResults.Multiline = true;
            txtResults.Name = "txtResults";
            txtResults.ReadOnly = true;
            txtResults.ScrollBars = ScrollBars.Vertical;
            txtResults.Size = new Size(383, 194);
            txtResults.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(787, 350);
            Controls.Add(txtResults);
            Controls.Add(btnAnalyze);
            Controls.Add(cboAnalysisType);
            Controls.Add(cboSpecialization);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "Patient Data Analyzer";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
