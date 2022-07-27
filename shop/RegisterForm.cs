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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            starterpack();
        }
        private void starterpack()
        {
            StartPosition = FormStartPosition.CenterScreen;
            //this.PasswdField.AutoSize = false;
            //this.PasswdField.Size = new Size(this.PasswdField.Size.Width, 28);
            userNameField.Text = "Введите ФИО";
            userNameField.ForeColor = Color.Gray;
            PasswdField.Text = "*******";
            PasswdField.ForeColor = Color.Gray;
            birthday_field.Text = "Дата рождения";
            birthday_field.ForeColor = Color.Gray;
            phone_field.Text = "Телефон";
            phone_field.ForeColor = Color.Gray;
            func_comboBox.Text = "Должность";
            func_comboBox.ForeColor = Color.Gray;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (userNameField.Text == "Введите ФИО")
            {
                MessageBox.Show("Введите ФИО");
                return;
            }
            if (PasswdField.Text == "*******")
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            if (birthday_field.Text == "Дата рождения")
            {
                MessageBox.Show("Дата рождения");
                return;
            }
            if (phone_field.Text == "Телефон")
            {
                MessageBox.Show("Телефон");
                return;
            } 
            if (func_comboBox.Text == "Должность")
            {
                MessageBox.Show("Должность");
                return;
            }

            //if (isUserExist())
            //    return;

            DB_shop db = new DB_shop();
            db.openConnection();

            MySqlCommand cmd = new MySqlCommand("SELECT `id func` FROM functions " +
                "WHERE `name func` = @name", db.getConnection());
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = func_comboBox.Text;
            object val = cmd.ExecuteScalar();

            MySqlCommand command = new MySqlCommand("INSERT INTO `personal` (`fio`, `birthday`, `phone`, `id func`, `passwd`) VALUES (@fio, @brth, @ph, @func, @pass)", db.getConnection());
            command.Parameters.Add("@fio", MySqlDbType.VarChar).Value = userNameField.Text;
            command.Parameters.Add("@brth", MySqlDbType.VarChar).Value = birthday_field.Text;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone_field.Text;
            command.Parameters.Add("@func", MySqlDbType.VarChar).Value = val.ToString();
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = PasswdField.Text;


            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт был создан");
                this.Hide();
                Login_Form login_Form = new Login_Form();
                login_Form.Show();
            }
            else
                MessageBox.Show("Аккаунт не был создан");

            db.closeConnection();
        }
        //public Boolean isUserExist()
        //{
        //    DB_shop db = new DB_shop();

        //    DataTable table = new DataTable();

        //    MySqlDataAdapter adapter = new MySqlDataAdapter();

        //    MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.getConnection());

        //    command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = LoginField.Text;

        //    adapter.SelectCommand = command;
        //    adapter.Fill(table);

        //    if (table.Rows.Count > 0)
        //    {
        //        MessageBox.Show("Такой логин уже имеется");
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void userNameField_Enter(object sender, EventArgs e)
        {
            if (userNameField.Text == "Введите ФИО")
            {
                userNameField.Text = "";
                userNameField.ForeColor = Color.Black;
            }
        }

        private void userNameField_Leave(object sender, EventArgs e)
        {
            if (userNameField.Text == "")
            {
                userNameField.Text = "Введите ФИО";
                userNameField.ForeColor = Color.Gray;
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

        private void registerlabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form login_Form = new Login_Form();
            login_Form.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void birthday_field_Enter(object sender, EventArgs e)
        {
            if (birthday_field.Text == "Дата рождения")
            {
                birthday_field.Text = "";
                birthday_field.ForeColor = Color.Black;
            }

        }

        private void birthday_field_Leave(object sender, EventArgs e)
        {
            if (birthday_field.Text == "")
            {
                birthday_field.Text = "Дата рождения";
                birthday_field.ForeColor = Color.Gray;
            }
        }

        private void phone_field_Enter(object sender, EventArgs e)
        {
            if (phone_field.Text == "Телефон")
            {
                phone_field.Text = "";
                phone_field.ForeColor = Color.Black;
            }
        }

        private void phone_field_Leave(object sender, EventArgs e)
        {
            if (phone_field.Text == "")
            {
                phone_field.Text = "Телефон";
                phone_field.ForeColor = Color.Gray;
            }
        }

        private void func_field_Enter(object sender, EventArgs e)
        {
            if (func_comboBox.Text == "Должность")
            {
                func_comboBox.Text = "";
                func_comboBox.ForeColor = Color.Black;
            }
        }

        private void func_field_Leave(object sender, EventArgs e)
        {
            if (func_comboBox.Text == "")
            {
                func_comboBox.Text = "Должность";
                func_comboBox.ForeColor = Color.Gray;
            }
        }
    }
}
