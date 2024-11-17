using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PredictiveMedicine
{
    internal class Disease
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incrementing ID
        public int DiseaseId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string ICDCode { get; set; } // International Classification of Diseases code

        [StringLength(2000)] // Allow for detailed description
        public string Description { get; set; }


        public List<Symptom> Symptoms { get; set; } = new List<Symptom>(); // Navigation property for many-to-many relationship with Symptoms
        public List<Treatment> Treatments { get; set; } = new List<Treatment>(); // Navigation property for many-to-many relationship with Treatments

        //Optional fields
        public string[] RiskFactors { get; set; } //string array to store multiple risk factors
        public string[] Complications { get; set; } //string array to store multiple complications
        public string[] PreventionMethods { get; set; } //string array to store multiple prevention methods

        //Methods to change data (Example methods, implement appropriate validation and error handling)

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Disease name cannot be empty or whitespace.");
            }
            Name = newName;
        }

        public void UpdateDescription(string newDescription)
        {
            Description = newDescription;
        }

        public void AddSymptom(Symptom symptom)
        {
            if (symptom == null)
            {
                throw new ArgumentNullException(nameof(symptom));
            }
            Symptoms.Add(symptom);
        }

        public void RemoveSymptom(Symptom symptom)
        {
            Symptoms.Remove(symptom);
        }

        public void AddTreatment(Treatment treatment)
        {
            if (treatment == null)
            {
                throw new ArgumentNullException(nameof(treatment));
            }
            Treatments.Add(treatment);
        }

        public void RemoveTreatment(Treatment treatment)
        {
            Treatments.Remove(treatment);
        }

        public void UpdateICDCode(string newICDCode)
        {
            ICDCode = newICDCode;
        }
    }
}
