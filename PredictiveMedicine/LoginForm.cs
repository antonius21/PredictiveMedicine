using System;
using System.Windows.Forms;

namespace PredictiveMedicine
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            CreateComponent();
        }

        private void CreateComponent()
        {
            this.labelUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(12, 9);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(40, 15);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Логін:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(12, 27);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 23);
            this.txtUsername.TabIndex = 1;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(12, 56);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(51, 15);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Пароль:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(12, 74);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(200, 23);
            this.txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(12, 103);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(90, 30);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Увійти";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(122, 103);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 145);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.labelUsername);
            this.Name = "LoginForm";
            this.Text = "Авторизація";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Замініть на вашу логіку авторизації, яка повертає об'єкт User або null
            User user = AuthenticateUser(username, password);

            if (user != null)
            {
                MessageBox.Show($"Авторизація успішна! Вітаємо, {user.FirstName} {user.LastName}!", "Успішна авторизація");
                OpenUserDashboard(user);
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильне ім'я користувача або пароль.", "Помилка авторизації");
            }
        }

        // Метод для автентифікації користувача (замініть на вашу логіку)
        private User AuthenticateUser(string username, string password)
        {

            if (username == "admin" && password == "password")
            {
                return new Patient(1, "Іван", "Петров", "ivan.petrov", "password", "ivan@example.com");
            }
            else if (username == "patient1" && password == "password")
            {
                return new Doctor(2, "Марія", "Іванова", "mary.ivanova", "password", "mary@example.com", UserRole.Doctor, new OncologistTreatmentStrategy(), new MachineLearningAnalyzer());
            }
            else if (username == "ivan.petrov" && password == "password")
            {
                return new Administrator(3, "Іван", "Петров", "ivan.petrov", "password", "ivan@example.com");
            }
            // ... інші умови ...
            else
            {
                return null;
            }
        }

        private void OpenUserDashboard(User user)
        {
            switch (user.Role)
            {
                case UserRole.Patient:
                    new PatientDashboard().Show();
                    break;
                case UserRole.Doctor:
                    new DoctorDashboard().Show();
                    break;
                case UserRole.Administrator:
                    new UserManagementView().Show();
                    this.Hide();
                    break;
                // Додайте інші кейси для інших ролей
                default:
                    MessageBox.Show("Невідома роль користувача.");
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
