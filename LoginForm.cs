using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Мебель
{
    public partial class LoginForm : Form
    {
        private FurnitureContext _db = new FurnitureContext();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            _db.Employees.Load();
            _db.Users.Load();

            if (_db.Users.Count() == 0)
            {
                Employee newEmployee = new Employee { FIO = "Иванов Иван Иванович" };
                User newUser = null;

                if (_db.Employees.Count() == 0)
                {
                    _db.Employees.Add(newEmployee);
                    newUser = new User { Login = "admin", Password = "admin", Employee = newEmployee };
                }
                else
                {
                    newUser = new User { Login = "admin", Password = "admin", Employee = _db.Employees.First() };
                }

                _db.Users.Add(newUser);
                _db.SaveChanges();
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _db.Dispose();
        }

        private void loginBTN_Click(object sender, EventArgs e)
        {
            string password = passwordTB.Text.Trim();
            string login = loginTB.Text.Trim();
            User user = _db.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

            if (user != null)
            {
                loginTB.Clear();
                passwordTB.Clear();

                this.Hide();

                MainForm mainForm = new MainForm(_db, user);
                mainForm.ShowDialog();

                this.Show();
            }
            else
            {
                MessageBox.Show("Данный пользователь не зарегистрирован.", "Ошибка.", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
