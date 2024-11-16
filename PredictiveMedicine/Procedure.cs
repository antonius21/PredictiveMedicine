using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal class Procedure
    { [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProcedureId { get; set; }

        [Required]
        [StringLength(255)]
        public string ProcedureName { get; set; }

        [StringLength(255)]
        public string ProcedureType { get; set; } // e.g., "Surgery", "Diagnostic", "Therapeutic"

        [StringLength(2000)]
        public string Description { get; set; } // Detailed description of the procedure


        public DateTime ProcedureDate { get; set; }
        [StringLength(255)]
        public string PerformingPhysician { get; set; }

        [StringLength(2000)]
        public string Notes { get; set; } // Additional notes or observations about the procedure


        //Possible additional fields:
        public int? DurationMinutes { get; set; } //Duration of procedure in minutes (nullable to handle procedures without a defined duration)
        public string[] Complications { get; set; } //Array of strings to store potential complications.


        // Methods to modify procedure details (include validation and error handling)
        public void UpdateProcedureName(string newProcedureName)
        {
            if (string.IsNullOrWhiteSpace(newProcedureName))
            {
                throw new ArgumentException("Procedure name cannot be empty or whitespace.");
            }
            ProcedureName = newProcedureName;
        }

        public void UpdateProcedureType(string newProcedureType)
        {
            if (string.IsNullOrWhiteSpace(newProcedureType))
            {
                throw new ArgumentException("Procedure type cannot be empty or whitespace.");
            }
            ProcedureType = newProcedureType;
        }

        public void UpdateDescription(string newDescription)
        {
            Description = newDescription;
        }

        public void UpdateProcedureDate(DateTime newProcedureDate)
        {
            ProcedureDate = newProcedureDate;
        }


        public void UpdatePerformingPhysician(string newPhysicianName)
        {
            if (string.IsNullOrWhiteSpace(newPhysicianName))
            {
                throw new ArgumentException("Physician name cannot be empty or whitespace.");
            }
            PerformingPhysician = newPhysicianName;
        }

        public void UpdateNotes(string newNotes)
        {
            Notes = newNotes;
        }

        public void UpdateDurationMinutes(int? newDurationMinutes)
        {
            DurationMinutes = newDurationMinutes;
        }

        public void AddComplication(string complication)
        {
            if (string.IsNullOrWhiteSpace(complication))
            {
                throw new ArgumentException("Complication cannot be empty or whitespace.");
            }

            if (Complications == null)
            {
                Complications = new string[0];
            }

            List<string> complicationsList = Complications.ToList();
            complicationsList.Add(complication);
            Complications = complicationsList.ToArray();
        }

        public void RemoveComplication(string complication)
        {
            if (Complications == null) return;
            List<string> complicationsList = Complications.ToList();
            complicationsList.Remove(complication);
            Complications = complicationsList.ToArray();
        }

        // Add other update methods as needed (e.g., for adding/removing associated diagnoses, medications, etc.)
    }
}
