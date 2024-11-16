using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal class Treatment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TreatmentId { get; set; }

        [Required]
        [StringLength(255)]
        public string TreatmentName { get; set; }

        [Required]
        public int DiseaseId { get; set; } // Foreign key to Disease

        [StringLength(255)]
        public string TreatmentType { get; set; } //e.g., "Medication", "Surgery", "Therapy", "Lifestyle Changes"


        [StringLength(2000)]
        public string Description { get; set; } // Detailed description of the treatment


        public DateTime? StartDate { get; set; } //Nullable DateTime, allows for treatments that don't have a defined start date.
        public DateTime? EndDate { get; set; }   //Nullable DateTime


        [StringLength(255)]
        public string PrescribingPhysician { get; set; }


        //Navigation properties
        public Disease Disease { get; set; }
        public List<Medication> Medications { get; set; } = new List<Medication>(); //Many-to-many with Medication

        // Methods to modify treatment details (include validation and error handling)
        public void UpdateTreatmentName(string newTreatmentName)
        {
            if (string.IsNullOrWhiteSpace(newTreatmentName))
            {
                throw new ArgumentException("Treatment name cannot be empty or whitespace.");
            }
            TreatmentName = newTreatmentName;
        }

        public void UpdateDescription(string newDescription)
        {
            Description = newDescription;
        }

        public void UpdateStartDate(DateTime newStartDate)
        {
            StartDate = newStartDate;
        }

        public void UpdateEndDate(DateTime? newEndDate)
        {
            EndDate = newEndDate;
        }

        public void UpdatePrescribingPhysician(string newPhysician)
        {
            if (string.IsNullOrWhiteSpace(newPhysician))
            {
                throw new ArgumentException("Physician name cannot be null or empty.");
            }
            PrescribingPhysician = newPhysician;
        }

        public void AddMedication(Medication medication)
        {
            if (medication == null)
            {
                throw new ArgumentNullException(nameof(medication));
            }
            Medications.Add(medication);
        }

        public void RemoveMedication(Medication medication)
        {
            Medications.Remove(medication);
        }
    }
}
