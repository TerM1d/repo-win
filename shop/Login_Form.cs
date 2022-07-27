using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace first_form
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            
           // this.PasswdField.AutoSize = false;
            //this.PasswdField.Size = new Size(this.PasswdField.Size.Width, 64);
            LoginField.Text = "Введите ФИО";
            LoginField.ForeColor = Color.Gray;
            PasswdField.Text = "*******";
            PasswdField.ForeColor = Color.Gray;
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.DarkRed;

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string LoginUser = LoginField.Text;
            string passUser = PasswdField.Text;

            DB_shop db = new DB_shop();
            db.openConnection();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `personal` WHERE `fio` = @uL AND `passwd` = @uP", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = LoginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            db.closeConnection();
            db.openConnection();

            //MySqlCommand cmd = new MySqlCommand("select status from users where login = @L;", db.getConnection());
            //cmd.Parameters.Add("@L", MySqlDbType.VarChar).Value = LoginUser;

            //object val = cmd.ExecuteScalar();
            if (table.Rows.Count > 0)
            {
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
                MessageBox.Show("No");
            db.closeConnection();
        }

        Point lastpoint;
        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }

        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);

        }

        private void registerlabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void LoginField_Enter(object sender, EventArgs e)
        {
            if (LoginField.Text == "Введите ФИО")
            {
                LoginField.Text = "";
                LoginField.ForeColor = Color.Black;
            }
        }

        private void LoginField_Leave(object sender, EventArgs e)
        {
            if (LoginField.Text == "")
            {
                LoginField.Text = "Введите ФИО";
                LoginField.ForeColor = Color.Gray;
            }
        }
        private void PasswdField_Enter(object sender, EventArgs e)
        {
            if (PasswdField.Text == "*******")
            {
                PasswdField.Text = "";
                PasswdField.ForeColor = Color.Black;
            }
        }

        private void PasswdField_Leave(object sender, EventArgs e)
        {
            if (PasswdField.Text == "")
            {
                PasswdField.Text = "*******";
                PasswdField.ForeColor = Color.Gray;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void back_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            firstform firstform = new firstform();
            firstform.Show();
        }
    }
}
