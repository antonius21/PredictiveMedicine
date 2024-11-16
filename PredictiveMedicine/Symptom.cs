using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal class Symptom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SymptomId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } // Name of the symptom (e.g., "Cough", "Fever", "Headache")

        [StringLength(2000)]
        public string Description { get; set; } // Detailed description of the symptom

        // Consider adding these fields for more detailed symptom representation:
        public string BodySystem { get; set; } // Body system affected (e.g., "Respiratory", "Cardiovascular", "Nervous")
        public int? SeverityLevel { get; set; } // Severity level (e.g., 1-5, where 5 is the most severe) - Nullable to allow for unspecified severity
        public string[] AssociatedDiseases { get; set; } // Array of strings, indicating diseases often associated with this symptom.

        // Methods for modifying symptom details (include validation and error handling)
        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Symptom name cannot be empty or whitespace.");
            }
            Name = newName;
        }

        public void UpdateDescription(string newDescription)
        {
            Description = newDescription;
        }

        public void UpdateBodySystem(string newBodySystem)
        {
            if (string.IsNullOrWhiteSpace(newBodySystem))
            {
                throw new ArgumentException("Body system cannot be empty or whitespace.");
            }
            BodySystem = newBodySystem;

        }

        public void UpdateSeverityLevel(int? newSeverityLevel)
        {
            if (newSeverityLevel != null && (newSeverityLevel < 1 || newSeverityLevel > 5))
            {
                throw new ArgumentOutOfRangeException(nameof(newSeverityLevel), "Severity level must be between 1 and 5.");
            }
            SeverityLevel = newSeverityLevel;
        }


        public void AddAssociatedDisease(string disease)
        {
            if (string.IsNullOrWhiteSpace(disease))
            {
                throw new ArgumentException("Disease name cannot be empty or whitespace.");
            }

            if (AssociatedDiseases == null)
            {
                AssociatedDiseases = new string[0];
            }

            List<string> diseaseList = AssociatedDiseases.ToList();
            diseaseList.Add(disease);
            AssociatedDiseases = diseaseList.ToArray();
        }

        public void RemoveAssociatedDisease(string disease)
        {
            if (AssociatedDiseases == null) return;
            List<string> diseaseList = AssociatedDiseases.ToList();
            diseaseList.Remove(disease);
            AssociatedDiseases = diseaseList.ToArray();
        }

        // Add other update methods as needed.  For example, you could add a method to add/remove synonyms for the symptom name.
    }
}
