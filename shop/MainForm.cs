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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            showTable();

            change_pr_box.Text = "id для изменения";
            change_pr_box.ForeColor = Color.Gray;

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

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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


        private void del_pr_button_Click(object sender, EventArgs e)
        {
            if (del_pr_textBox.Text == "") { return; }
            string product = del_pr_textBox.Text;

            DB_shop shop = new DB_shop();

            shop.openConnection();
            
            MySqlCommand command = new MySqlCommand("DELETE FROM `product` WHERE `id product` = @id;", shop.getConnection());

            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = product;

            command.ExecuteNonQuery();
            dataGridView1.Rows.Clear();
            shop.closeConnection();
            del_pr_textBox.Text = "";
            showTable();

        }

        private void add_pr_button_Click(object sender, EventArgs e)
        {
            if (Product_box.Text == "" || Price_box.Text == "" || Amount_box.Text == "" || 
                categ_comboBox.Text == "" || manuf_comboBox.Text == "")
            {
                MessageBox.Show("Для добавления продукта заполните все поля");
                return;
            }
            DB_shop shop = new DB_shop();
            shop.openConnection();


            MySqlCommand cmdCateg = new MySqlCommand("SELECT `id category` FROM category " +
                "WHERE `name category` = @name_c", shop.getConnection());
            cmdCateg.Parameters.Add("@name_c", MySqlDbType.VarChar).Value = categ_comboBox.Text;
            object val_categ = cmdCateg.ExecuteScalar();

            MySqlCommand cmdManuf = new MySqlCommand("SELECT `id manuf` FROM manufacturer " +
               "WHERE `name manuf` = @name_m", shop.getConnection());
            cmdManuf.Parameters.Add("@name_m", MySqlDbType.VarChar).Value = manuf_comboBox.Text;
            object val_manuf = cmdManuf.ExecuteScalar();

            MySqlCommand command = new MySqlCommand("INSERT INTO `product` (`id product`, `name product`, " +
                "`price`, `amount`, `id category`, `id manuf`) VALUES (NULL, @product, @price, " +
                "@amount, @categ, @manuf);", shop.getConnection());

            command.Parameters.Add("@product", MySqlDbType.VarChar).Value = Product_box.Text;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = Price_box.Text;
            command.Parameters.Add("@amount", MySqlDbType.VarChar).Value = Amount_box.Text;
            command.Parameters.Add("@categ", MySqlDbType.VarChar).Value = val_categ.ToString();
            command.Parameters.Add("@manuf", MySqlDbType.VarChar).Value = val_manuf.ToString();
            
            command.ExecuteNonQuery();
            dataGridView1.Rows.Clear();
            showTable();
            Product_box.Text = "";
            Price_box.Text = "";
            Amount_box.Text = "";
            categ_comboBox.Text = "";
            manuf_comboBox.Text = "";
            shop.closeConnection();
        }

        private void show_tbl_button_Click(object sender, EventArgs e)
        {
            showTable();
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


        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.DarkRed;
        }

        private void change_pr_button_Click(object sender, EventArgs e)
        {
            if (Product_box.Text == "" || Price_box.Text == "" || Amount_box.Text == "" ||
                categ_comboBox.Text == "" || manuf_comboBox.Text == "" || change_pr_box.Text == "")
            {
                MessageBox.Show("Для изменения продукта заполните все поля");
                return;
            }
            DB_shop shop = new DB_shop();
            shop.openConnection();

            MySqlCommand cmdCateg = new MySqlCommand("SELECT `id category` FROM category " +
                "WHERE `name category` = @name_c", shop.getConnection());
            cmdCateg.Parameters.Add("@name_c", MySqlDbType.VarChar).Value = categ_comboBox.Text;
            object val_categ = cmdCateg.ExecuteScalar();

            MySqlCommand cmdManuf = new MySqlCommand("SELECT `id manuf` FROM manufacturer " +
               "WHERE `name manuf` = @name_m", shop.getConnection());
            cmdManuf.Parameters.Add("@name_m", MySqlDbType.VarChar).Value = manuf_comboBox.Text;
            object val_manuf = cmdManuf.ExecuteScalar();


            MySqlCommand command = new MySqlCommand("UPDATE `product` SET `name product`= @new_name, " +
                "`price`= @new_price,`amount`= @new_amount,`id category`= @new_categ,`id manuf`= @new_manuf " +
                "WHERE `id product` = @id_pr;", shop.getConnection());

            command.Parameters.Add("@new_name", MySqlDbType.VarChar).Value = Product_box.Text;
            command.Parameters.Add("@new_price", MySqlDbType.VarChar).Value = Price_box.Text;
            command.Parameters.Add("@new_amount", MySqlDbType.VarChar).Value = Amount_box.Text;
            command.Parameters.Add("@new_categ", MySqlDbType.VarChar).Value = val_categ.ToString();
            command.Parameters.Add("@new_manuf", MySqlDbType.VarChar).Value = val_manuf.ToString();
            command.Parameters.Add("@id_pr", MySqlDbType.VarChar).Value = change_pr_box.Text;

            command.ExecuteNonQuery();
            dataGridView1.Rows.Clear();
            showTable();
            Product_box.Text = "";
            Price_box.Text = "";
            Amount_box.Text = "";
            categ_comboBox.Text = "";
            manuf_comboBox.Text = "";
            change_pr_box.Text = "";
            shop.closeConnection();
        }

        private void change_pr_box_Enter(object sender, EventArgs e)
        {
            if(change_pr_box.Text == "id для изменения")
            {
                change_pr_box.Text = "";
                change_pr_box.ForeColor = Color.Black;
            }
        }

        private void change_pr_box_Leave(object sender, EventArgs e)
        {
            if (change_pr_box.Text == "")
            {
                change_pr_box.Text = "id для изменения";
                change_pr_box.ForeColor = Color.Gray;
            }
        }


        private void back_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form login_Form = new Login_Form();
            login_Form.Show();
        }
    }
}
