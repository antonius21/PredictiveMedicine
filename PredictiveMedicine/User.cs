using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveMedicine
{
    public abstract class User : INotifyPropertyChanged
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _username;
        private string _password; 
        private string _email;
        private UserRole _role;
        private DateTime _dateCreated;
        private DateTime? _lastLogin;
        private bool _isActive;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [Key]
        public int Id { get => _id; protected set { _id = value; OnPropertyChanged(nameof(Id)); } } // Захищений сеттер


        [Required]
        [StringLength(50)]
        public string FirstName { get => _firstName; protected set { _firstName = value; OnPropertyChanged(nameof(FirstName)); } }

        [Required]
        [StringLength(50)]
        public string LastName { get => _lastName; protected set { _lastName = value; OnPropertyChanged(nameof(LastName)); } }

        [Required]
        [StringLength(50)]
        public string Username { get => _username; protected set { _username = value; OnPropertyChanged(nameof(Username)); } }

        [Required]
        [StringLength(255)]
        public string Password { get => _password; protected set { _password = value; OnPropertyChanged(nameof(Password)); } }

        [Required]
        [EmailAddress]
        public string Email { get => _email; protected set { _email = value; OnPropertyChanged(nameof(Email)); } }

        public UserRole Role { get => _role; protected set { _role = value; OnPropertyChanged(nameof(Role)); } }

        public DateTime DateCreated { get => _dateCreated; protected set { _dateCreated = value; OnPropertyChanged(nameof(DateCreated)); } }

        public DateTime? LastLogin { get => _lastLogin; protected set { _lastLogin = value; OnPropertyChanged(nameof(LastLogin)); } }

        public bool IsActive { get => _isActive; protected set { _isActive = value; OnPropertyChanged(nameof(IsActive)); } }


        protected User(int id, string firstName, string lastName, string username, string password, string email, UserRole role)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password; // Хешування пароля має відбуватися тут
            Email = email;
            Role = role;
            DateCreated = DateTime.Now;
            IsActive = true;
        }

        public void SetRole(UserRole newRole)
        {
            _role = newRole;
            OnPropertyChanged(nameof(Role));
        }

        public void ChangePassword(string newPassword)
        {
            try
            {
                string oldPassword = Password; 
                Password = newPassword; 
                logger.Info($"Користувач {Username} змінив пароль. Старий пароль: {oldPassword}, Новий пароль: [Замасковано]"); // Логування зміни пароля
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Помилка під час зміни пароля для користувача {Username}");
            }
        }

        public void ChangeEmail(string newEmail)
        {
            try
            {
                string oldEmail = Email; // Зберегти старий Email для логу
                Email = newEmail;
                logger.Info($"Користувач {Username} змінив Email. Старий Email: {oldEmail}, Новий Email: {newEmail}");
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Помилка під час зміни Email для користувача {Username}");
            }
        }

    }
    public enum UserRole
    {
        Patient,
        Doctor,
        Nurse,
        LabTechnician,
        Administrator,
        Researcher
    }
}
