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
    public partial class User_Form : Form
    {
        public User_Form()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            showTable();
        }

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

        private void find_pr_button_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();

            string product = find_product_box.Text;

            DB_shop shop = new DB_shop();

            shop.openConnection();

            MySqlCommand command = new MySqlCommand("SELECT `id product`, `name product`, `price`, " +
                "`amount`, `category`.`name category`, `manufacturer`.`name manuf` FROM `product` " +
                "INNER JOIN category ON `product`.`id category` = `category`.`id category` " +
                "INNER JOIN manufacturer ON `product`.`id manuf` = `manufacturer`.`id manuf` " +
                "WHERE `name product` = @pr;", shop.getConnection());

            command.Parameters.Add("@pr", MySqlDbType.VarChar).Value = product;

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[6]);
                for (int i = 0; i < 6; i++) { data[data.Count - 1][i] = reader[i].ToString(); }
            }

            reader.Close();
            shop.closeConnection();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);

            find_product_box.Text = "";
        }
        private void showTable()
        {
            dataGridView1.Rows.Clear();

            DB_shop shop = new DB_shop();

            shop.openConnection();

            MySqlCommand command = new MySqlCommand("SELECT `id product`, `name product`, `price`, `amount`, " +
                "`category`.`name category`, `manufacturer`.`name manuf` FROM `product` " +
                "INNER JOIN category ON `product`.`id category` = `category`.`id category` " +
                "INNER JOIN manufacturer ON `product`.`id manuf` = `manufacturer`.`id manuf`" +
                "ORDER BY `id product`;", shop.getConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[6]);

                for (int i = 0; i < 6; i++) { data[data.Count - 1][i] = reader[i].ToString(); }

            }
            reader.Close();
            shop.closeConnection();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);

        }

        private void show_tbl_button_Click(object sender, EventArgs e)
        {
            showTable();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.DarkRed;

        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            firstform firstform = new firstform();
            firstform.Show();
        }
    }
}
