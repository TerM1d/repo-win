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
    public partial class firstform : Form
    {
        public firstform()
        {
            InitializeComponent();
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

        private void button_adm_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form login_Form = new Login_Form();
            login_Form.Show();
        }

        private void button_usr_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Form user_Form = new User_Form();
            user_Form.Show();
        }

        private void firstform_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
