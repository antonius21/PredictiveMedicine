using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal class Diagnosis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiagnosisId { get; set; }

        [Required]
        public int PatientId { get; set; } // Foreign key to Patient

        [Required]
        public int DiseaseId { get; set; } // Foreign key to Disease

        [Required]
        public DateTime DiagnosisDate { get; set; }

        [StringLength(255)]
        public string DiagnosingPhysician { get; set; } // Name of the diagnosing physician


        [StringLength(2000)]
        public string Notes { get; set; } // Additional notes or observations about the diagnosis


        //Navigation properties (optional, depending on your database design)
        public Patient Patient { get; set; } // Navigation property to the Patient object
        public Disease Disease { get; set; } // Navigation property to the Disease object



        // Methods to modify diagnosis details (include validation and error handling)

        public void UpdateDiagnosingPhysician(string newPhysicianName)
        {
            if (string.IsNullOrWhiteSpace(newPhysicianName))
            {
                throw new ArgumentException("Physician name cannot be empty or whitespace.");
            }
            DiagnosingPhysician = newPhysicianName;
        }

        public void UpdateNotes(string newNotes)
        {
            Notes = newNotes;
        }
    }
}
