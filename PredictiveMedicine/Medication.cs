using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal class Medication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicationId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } // Generic name of the medication

        [StringLength(255)]
        public string BrandName { get; set; } // Brand name (if applicable)

        [StringLength(255)]
        public string ActiveIngredient { get; set; } // Active ingredient(s)

        [StringLength(2000)]
        public string Description { get; set; } // Detailed description of the medication, including indications, contraindications, etc.

        [StringLength(255)]
        public string DosageForms { get; set; } // e.g., "Tablet", "Capsule", "Syrup", "Injection"

        //Consider adding more specific dosage information:
        public string DosageInstructions { get; set; }

        public List<string> Contraindications { get; set; } = new List<string>(); // List of contraindications
        public List<string> SideEffects { get; set; } = new List<string>();       // List of potential side effects


        // Methods to modify medication details (include validation and error handling)
        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Medication name cannot be empty or whitespace.");
            }
            Name = newName;
        }

        public void UpdateBrandName(string newBrandName)
        {
            BrandName = newBrandName;
        }

        public void UpdateActiveIngredient(string newActiveIngredient)
        {
            if (string.IsNullOrWhiteSpace(newActiveIngredient))
            {
                throw new ArgumentException("Active ingredient cannot be empty or whitespace.");
            }
            ActiveIngredient = newActiveIngredient;
        }

        public void UpdateDescription(string newDescription)
        {
            Description = newDescription;
        }

        public void UpdateDosageForms(string newDosageForms)
        {
            DosageForms = newDosageForms;
        }


        public void AddContraindication(string contraindication)
        {
            if (string.IsNullOrWhiteSpace(contraindication))
            {
                throw new ArgumentException("Contraindication cannot be empty or whitespace.");
            }
            Contraindications.Add(contraindication);
        }


        public void RemoveContraindication(string contraindication)
        {
            Contraindications.Remove(contraindication);
        }


        public void AddSideEffect(string sideEffect)
        {
            if (string.IsNullOrWhiteSpace(sideEffect))
            {
                throw new ArgumentException("Side effect cannot be empty or whitespace.");
            }
            SideEffects.Add(sideEffect);
        }

        public void RemoveSideEffect(string sideEffect)
        {
            SideEffects.Remove(sideEffect);
        }


        // Add methods to update other fields (DosageInstructions etc.) as needed, with appropriate validation.
    }
}
