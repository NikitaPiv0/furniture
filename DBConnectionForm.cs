using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Мебель
{
    public partial class DBConnectionForm : Form
    {
        public DBConnectionForm()
        {
            InitializeComponent();
        }

        private void DBConnectionForm_Load(object sender, EventArgs e)
        {
            try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("FurnitureContext");
                SQLHelper helper = new SQLHelper(connectionString);
                if (helper.IsConnection)
                {
                    this.Hide();

                    LoginForm loginForm = new LoginForm();
                    loginForm.ShowDialog();

                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("Отсутствует подключение к серверу. Обновите подключение", "Отсутствует подключение.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            serverNameCB.Items.Add(".");
            serverNameCB.Items.Add("(local)");
            serverNameCB.Items.Add(@".\SQLEXPRESS");
            serverNameCB.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            serverNameCB.SelectedIndex = 3;
        }

        private void testConnectionBTN_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source = {0}; Initial Catalog = Furniture_DB; Integrated Security = True;MultipleActiveResultSets=True;App=EntityFramework", serverNameCB.Text);
            try
            {
                SQLHelper helper = new SQLHelper(connectionString);
                if (helper.IsConnection)
                    MessageBox.Show("Подключение выполнено.", "Успешно.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveConnectionBTN_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source = {0}; Initial Catalog = Furniture_DB; Integrated Security = True;MultipleActiveResultSets=True;App=EntityFramework", serverNameCB.Text);
            try
            {
                SQLHelper helper = new SQLHelper(connectionString);
                if (helper.IsConnection)
                {
                    AppSetting setting = new AppSetting();
                    setting.SaveConnectionString("FurnitureContext", connectionString);
                    MessageBox.Show("Ваша строка подключения успешно сохранена. Перезагрузите приложение.", "Сохранено.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
