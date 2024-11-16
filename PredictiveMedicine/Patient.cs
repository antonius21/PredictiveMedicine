using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal class Patient:User
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public Patient(int id, string firstName, string lastName, string username, string password, string email, IMedicalRecordRepository medicalRecordRepository)
            : base(id, firstName, lastName, username, password, email, UserRole.Patient)
        {
            _medicalRecordRepository = medicalRecordRepository ?? throw new ArgumentNullException(nameof(medicalRecordRepository));
        }

        public List<MedicalRecord> GetMedicalRecords()
        {
            try
            {
                List<MedicalRecord> records = _medicalRecordRepository.GetMedicalRecordsByPatientId(Id);
                logger.Info($"Пацієнт {Username} переглянув свої медичні записи.");
                return records;
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Помилка під час отримання медичних записів для пацієнта {Username}");
                throw;
            }
        }

        public void AddPatientNote(string note)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(note))
                    throw new ArgumentException("Запис не може бути пустим.");

                MedicalRecord newRecord = new MedicalRecord
                {
                    PatientId = Id,
                    Date = DateTime.Now,
                    Description = note,
                    IsPatientNote = true // Нове поле для позначення запису від пацієнта
                };
                _medicalRecordRepository.AddMedicalRecord(newRecord);
                logger.Info($"Пацієнт {Username} додав новий запис.");
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Помилка під час додавання запису для пацієнта {Username}");
                throw;
            }
        }


        // Можливе додавання методу для оновлення власних записів,
        // але з обмеженнями на зміну даних, внесених лікарем.
        // Наприклад, пацієнт може додати деталі до існуючого запису,
        // але не може його повністю видалити чи змінити.

        // ... інші методи ...

    }

}
