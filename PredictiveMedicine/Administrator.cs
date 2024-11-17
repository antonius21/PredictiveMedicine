using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    internal class Administrator : User
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IUserRepository _userRepository; // Інтерфейс для взаємодії з БД

        public Administrator(int id, string firstName, string lastName, string username, string password, string email)
            : base(id, firstName, lastName, username, password, email, UserRole.Administrator)
        {
          //  _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }


        public User CreateUser(string firstName, string lastName, string username, string password, string email, UserRole role)
        {
            try
            {
                // ... (Валідація даних) ...
                string hashedPassword = HashPassword(password);

                User newUser;
                switch (role)
                {
                    case UserRole.Patient:
                        newUser = new Patient(0, firstName, lastName, username, hashedPassword, email);
                        break;
                    case UserRole.Doctor:
                        newUser = new Doctor(0, firstName, lastName, username, hashedPassword, email,UserRole.Doctor, new OncologistTreatmentStrategy(),new MachineLearningAnalyzer());
                        break;
                    case UserRole.Administrator:
                        newUser = new Administrator(0, firstName, lastName, username, hashedPassword, email);
                        break;
                    // Додати інші ролі тут...
                    default:
                        throw new ArgumentException("Невідома роль користувача");
                }

                _userRepository.CreateUser(newUser);
                logger.Info($"Адміністратор {Username} створив нового користувача: {username}");
                return newUser;
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Помилка під час створення користувача: {username}");
                throw;
            }
        }


        public void DeleteUser(int userId)
        {
            try
            {
                if (_userRepository.GetUserById(userId) == null)
                    throw new ArgumentException("Користувач з таким ID не знайдено");

                _userRepository.DeleteUser(userId);
                logger.Info($"Адміністратор {Username} видалив користувача з ID: {userId}");
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Помилка під час видалення користувача з ID: {userId}");
                throw;
            }
        }

        public void UpdateUser(User updatedUser)
        {
            try
            {
                if (_userRepository.GetUserById(updatedUser.Id) == null)
                    throw new ArgumentException("Користувач з таким ID не знайдено");

                // Валідація даних (перевірити зміни, що вносяться)
                // Хешування пароля якщо він був змінений

                _userRepository.UpdateUser(updatedUser);
                logger.Info($"Адміністратор {Username} оновив інформацію про користувача: {updatedUser.Username}");

            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Помилка під час оновлення користувача: {updatedUser.Username}");
                throw;
            }
        }


        public List<User> GetAllUsers()
        {
            try
            {
                List<User> users = _userRepository.GetAllUsers();
                logger.Info($"Адміністратор {Username} отримав список усіх користувачів.");
                return users;
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Помилка під час отримання списку користувачів");
                throw;
            }
        }

        // Метод для хешування паролю (замінити на більш безпечний)
        private string HashPassword(string password)
        {
            // Тут має бути реалізований безпечний метод хешування пароля
            // Наприклад, використання bcrypt або Argon2
            // Цей метод є лише заглушкою!
            return password; // Замініть на реальну реалізацію хешування!
        }


        //Інші методи адміністратора, наприклад,  керування ролями, правами доступу тощо.
    }
}
