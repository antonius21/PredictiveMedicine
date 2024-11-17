using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PredictiveMedicine
{
    public partial class UserManagementView : Form
    {
        private List<User> users = new List<User>(); // приклад, в реальній програмі - завантаження з бази даних
        public UserManagementView()
        {
            InitializeComponent();
            CreateComponent();

            // Заповнення прикладом даних (замінити на завантаження з бази даних)
            users.Add(new Patient(1, "Іван", "Петров", "ivan.petrov", "password", "ivan@example.com"));
            users.Add(new Doctor(2, "Марія", "Іванова", "mary.ivanova", "password", "mary@example.com", UserRole.Doctor,new OncologistTreatmentStrategy(),new MachineLearningAnalyzer()));

            // Розташування елементів керування
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Width = (int)(this.Width * 0.2);
            dataGridViewUsers.Dock = DockStyle.Fill;
            // Розтягування кнопок на всю висоту panelLeft
            btnAddUser.Dock = DockStyle.Top;
            btnAddUser.Height = panelLeft.Height / 4; // Розділити висоту на кількість кнопок
            btnEditUser.Dock = DockStyle.Top;
            btnEditUser.Height = panelLeft.Height / 4;
            btnDeleteUser.Dock = DockStyle.Top;
            btnDeleteUser.Height = panelLeft.Height / 4;
            btnRefresh.Dock = DockStyle.Top;
            btnRefresh.Height = panelLeft.Height / 4;


            //Заповнення DataGridView
            DisplayUsers();
        }

        private void CreateComponent()
        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.btnRefresh);
            this.panelLeft.Controls.Add(this.btnDeleteUser);
            this.panelLeft.Controls.Add(this.btnEditUser);
            this.panelLeft.Controls.Add(this.btnAddUser);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(150, 450);
            this.panelLeft.TabIndex = 0;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddUser.Location = new System.Drawing.Point(0, 0);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(150, 112);
            this.btnAddUser.TabIndex = 0;
            this.btnAddUser.Text = "Додати користувача";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditUser.Location = new System.Drawing.Point(0, 112);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(150, 112);
            this.btnEditUser.TabIndex = 1;
            this.btnEditUser.Text = "Редагувати користувача";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDeleteUser.Location = new System.Drawing.Point(0, 224);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(150, 112);
            this.btnDeleteUser.TabIndex = 2;
            this.btnDeleteUser.Text = "Видалити користувача";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRefresh.Location = new System.Drawing.Point(0, 336);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 112);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Оновити список";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.dataGridViewUsers);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(150, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(650, 450);
            this.panelRight.TabIndex = 1;
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUsers.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.RowTemplate.Height = 25;
            this.dataGridViewUsers.Size = new System.Drawing.Size(650, 450);
            this.dataGridViewUsers.TabIndex = 0;
            this.dataGridViewUsers.CellDoubleClick += DataGridViewUsers_CellDoubleClick;
            // 
            // UserManagementView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Name = "UserManagementView";
            this.Text = "Керування користувачами";
            this.Resize += new System.EventHandler(this.UserManagementView_Resize);
            this.panelLeft.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.ResumeLayout(false);

        }

        private Panel panelLeft;
        private Button btnAddUser;
        private Button btnEditUser;
        private Button btnDeleteUser;
        private Button btnRefresh;
        private Panel panelRight;
        private DataGridView dataGridViewUsers;

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            using (var addUserForm = new AddUserForm())
            {
                if (addUserForm.ShowDialog() == DialogResult.OK)
                {
                    // Додаємо нового користувача до списку
                    users.Add(addUserForm.NewUser);
                    DisplayUsers();
                }
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            // Тут має бути реалізація редагування обраного користувача
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            // Тут має бути реалізація видалення обраного користувача
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayUsers();
        }
        private void DataGridViewUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int userId = Convert.ToInt32(dataGridViewUsers.Rows[e.RowIndex].Cells["Id"].Value);
                User selectedUser = users.FirstOrDefault(u => u.Id == userId);

                if (selectedUser != null)
                {
                    using (var userDetailView = new UserDetailView(selectedUser))
                    {
                        if (userDetailView.ShowDialog() == DialogResult.OK)
                        {
                            // Оновлюємо дані після редагування
                            DisplayUsers();
                        }
                    }
                }
            }
        }

        private void DisplayUsers()
        {
            dataGridViewUsers.Rows.Clear();
            dataGridViewUsers.Columns.Clear();

            // Додаємо стовпці (всі крім Role - ReadOnly)
            dataGridViewUsers.Columns.Add("Id", "ID");
            dataGridViewUsers.Columns.Add("FirstName", "Ім'я");
            dataGridViewUsers.Columns.Add("LastName", "Прізвище");
            dataGridViewUsers.Columns.Add("Username", "Логін");
            dataGridViewUsers.Columns.Add("Email", "Email");
            dataGridViewUsers.Columns.Add("Role", "Роль");

            // Встановлюємо ReadOnly для всіх стовпців крім "Role"
            foreach (DataGridViewColumn col in dataGridViewUsers.Columns)
            {
                if (col.Name != "Role")
                {
                    col.ReadOnly = true;
                }
            }

            foreach (var user in users)
            {
                dataGridViewUsers.Rows.Add(user.Id, user.FirstName, user.LastName, user.Username, user.Email, user.Role.ToString());
            }
        }
        private void UserManagementView_Resize(object sender, EventArgs e)
        {
            panelLeft.Width = (int)(this.Width * 0.2);
            btnAddUser.Height = panelLeft.Height / 4;
            btnEditUser.Height = panelLeft.Height / 4;
            btnDeleteUser.Height = panelLeft.Height / 4;
            btnRefresh.Height = panelLeft.Height / 4;

        }
    }
}
