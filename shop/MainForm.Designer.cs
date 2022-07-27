namespace first_form
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.change_pr_button = new System.Windows.Forms.Button();
            this.change_pr_box = new System.Windows.Forms.TextBox();
            this.manuf_comboBox = new System.Windows.Forms.ComboBox();
            this.categ_comboBox = new System.Windows.Forms.ComboBox();
            this.show_tbl_button = new System.Windows.Forms.Button();
            this.add_pr_button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Amount_box = new System.Windows.Forms.TextBox();
            this.Price_box = new System.Windows.Forms.TextBox();
            this.Product_box = new System.Windows.Forms.TextBox();
            this.del_pr_button = new System.Windows.Forms.Button();
            this.del_pr_textBox = new System.Windows.Forms.TextBox();
            this.find_pr_button = new System.Windows.Forms.Button();
            this.find_product_box = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manuf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Label();
            this.back_button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.change_pr_button);
            this.panel1.Controls.Add(this.change_pr_box);
            this.panel1.Controls.Add(this.manuf_comboBox);
            this.panel1.Controls.Add(this.categ_comboBox);
            this.panel1.Controls.Add(this.show_tbl_button);
            this.panel1.Controls.Add(this.add_pr_button);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Amount_box);
            this.panel1.Controls.Add(this.Price_box);
            this.panel1.Controls.Add(this.Product_box);
            this.panel1.Controls.Add(this.del_pr_button);
            this.panel1.Controls.Add(this.del_pr_textBox);
            this.panel1.Controls.Add(this.find_pr_button);
            this.panel1.Controls.Add(this.find_product_box);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1173, 579);
            this.panel1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sitka Text", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(70, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(245, 40);
            this.label6.TabIndex = 32;
            this.label6.Text = "База продуктов";
            // 
            // change_pr_button
            // 
            this.change_pr_button.BackColor = System.Drawing.Color.DarkGray;
            this.change_pr_button.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.change_pr_button.ForeColor = System.Drawing.Color.Black;
            this.change_pr_button.Location = new System.Drawing.Point(394, 504);
            this.change_pr_button.Name = "change_pr_button";
            this.change_pr_button.Size = new System.Drawing.Size(220, 47);
            this.change_pr_button.TabIndex = 31;
            this.change_pr_button.Text = "Изменить продукт";
            this.change_pr_button.UseVisualStyleBackColor = false;
            this.change_pr_button.Click += new System.EventHandler(this.change_pr_button_Click);
            // 
            // change_pr_box
            // 
            this.change_pr_box.Location = new System.Drawing.Point(394, 471);
            this.change_pr_box.Name = "change_pr_box";
            this.change_pr_box.Size = new System.Drawing.Size(220, 27);
            this.change_pr_box.TabIndex = 30;
            this.change_pr_box.Enter += new System.EventHandler(this.change_pr_box_Enter);
            this.change_pr_box.Leave += new System.EventHandler(this.change_pr_box_Leave);
            // 
            // manuf_comboBox
            // 
            this.manuf_comboBox.FormattingEnabled = true;
            this.manuf_comboBox.Items.AddRange(new object[] {
            "alphine",
            "red bull",
            "ferrari"});
            this.manuf_comboBox.Location = new System.Drawing.Point(178, 340);
            this.manuf_comboBox.Name = "manuf_comboBox";
            this.manuf_comboBox.Size = new System.Drawing.Size(162, 28);
            this.manuf_comboBox.TabIndex = 29;
            // 
            // categ_comboBox
            // 
            this.categ_comboBox.FormattingEnabled = true;
            this.categ_comboBox.Items.AddRange(new object[] {
            "sport",
            "food",
            "car"});
            this.categ_comboBox.Location = new System.Drawing.Point(178, 281);
            this.categ_comboBox.Name = "categ_comboBox";
            this.categ_comboBox.Size = new System.Drawing.Size(162, 28);
            this.categ_comboBox.TabIndex = 2;
            // 
            // show_tbl_button
            // 
            this.show_tbl_button.BackColor = System.Drawing.Color.DarkGray;
            this.show_tbl_button.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.show_tbl_button.Location = new System.Drawing.Point(39, 489);
            this.show_tbl_button.Name = "show_tbl_button";
            this.show_tbl_button.Size = new System.Drawing.Size(301, 62);
            this.show_tbl_button.TabIndex = 26;
            this.show_tbl_button.Text = "Обновить таблицу";
            this.show_tbl_button.UseVisualStyleBackColor = false;
            this.show_tbl_button.Click += new System.EventHandler(this.show_tbl_button_Click);
            // 
            // add_pr_button
            // 
            this.add_pr_button.BackColor = System.Drawing.Color.DarkGray;
            this.add_pr_button.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.add_pr_button.Location = new System.Drawing.Point(39, 412);
            this.add_pr_button.Name = "add_pr_button";
            this.add_pr_button.Size = new System.Drawing.Size(301, 62);
            this.add_pr_button.TabIndex = 25;
            this.add_pr_button.Text = "Добавить продукт";
            this.add_pr_button.UseVisualStyleBackColor = false;
            this.add_pr_button.Click += new System.EventHandler(this.add_pr_button_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sitka Text", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.DarkOrange;
            this.label5.Location = new System.Drawing.Point(12, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 33);
            this.label5.TabIndex = 24;
            this.label5.Text = "Manufactury";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Text", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.DarkOrange;
            this.label4.Location = new System.Drawing.Point(26, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 33);
            this.label4.TabIndex = 23;
            this.label4.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Text", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.DarkOrange;
            this.label3.Location = new System.Drawing.Point(39, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 33);
            this.label3.TabIndex = 22;
            this.label3.Text = "Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Text", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.DarkOrange;
            this.label2.Location = new System.Drawing.Point(70, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 33);
            this.label2.TabIndex = 21;
            this.label2.Text = "Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.DarkOrange;
            this.label1.Location = new System.Drawing.Point(39, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 33);
            this.label1.TabIndex = 20;
            this.label1.Text = "Product";
            // 
            // Amount_box
            // 
            this.Amount_box.Location = new System.Drawing.Point(178, 225);
            this.Amount_box.Name = "Amount_box";
            this.Amount_box.Size = new System.Drawing.Size(162, 27);
            this.Amount_box.TabIndex = 17;
            // 
            // Price_box
            // 
            this.Price_box.Location = new System.Drawing.Point(178, 170);
            this.Price_box.Name = "Price_box";
            this.Price_box.Size = new System.Drawing.Size(162, 27);
            this.Price_box.TabIndex = 16;
            // 
            // Product_box
            // 
            this.Product_box.Location = new System.Drawing.Point(178, 112);
            this.Product_box.Name = "Product_box";
            this.Product_box.Size = new System.Drawing.Size(162, 27);
            this.Product_box.TabIndex = 15;
            // 
            // del_pr_button
            // 
            this.del_pr_button.BackColor = System.Drawing.Color.DarkGray;
            this.del_pr_button.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.del_pr_button.Location = new System.Drawing.Point(905, 504);
            this.del_pr_button.Name = "del_pr_button";
            this.del_pr_button.Size = new System.Drawing.Size(220, 47);
            this.del_pr_button.TabIndex = 14;
            this.del_pr_button.Text = "Удалить продукт по id";
            this.del_pr_button.UseVisualStyleBackColor = false;
            this.del_pr_button.Click += new System.EventHandler(this.del_pr_button_Click);
            // 
            // del_pr_textBox
            // 
            this.del_pr_textBox.Location = new System.Drawing.Point(905, 471);
            this.del_pr_textBox.Name = "del_pr_textBox";
            this.del_pr_textBox.Size = new System.Drawing.Size(220, 27);
            this.del_pr_textBox.TabIndex = 12;
            // 
            // find_pr_button
            // 
            this.find_pr_button.BackColor = System.Drawing.Color.DarkGray;
            this.find_pr_button.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.find_pr_button.Location = new System.Drawing.Point(652, 504);
            this.find_pr_button.Name = "find_pr_button";
            this.find_pr_button.Size = new System.Drawing.Size(220, 47);
            this.find_pr_button.TabIndex = 11;
            this.find_pr_button.Text = "Найти продукт";
            this.find_pr_button.UseVisualStyleBackColor = false;
            this.find_pr_button.Click += new System.EventHandler(this.find_pr_button_Click);
            // 
            // find_product_box
            // 
            this.find_product_box.Location = new System.Drawing.Point(652, 471);
            this.find_product_box.Name = "find_product_box";
            this.find_product_box.Size = new System.Drawing.Size(220, 27);
            this.find_product_box.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Product,
            this.price,
            this.Amount,
            this.category,
            this.manuf});
            this.dataGridView1.Location = new System.Drawing.Point(356, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(804, 431);
            this.dataGridView1.TabIndex = 9;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 125;
            // 
            // Product
            // 
            this.Product.HeaderText = "Product";
            this.Product.MinimumWidth = 6;
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            this.Product.Width = 125;
            // 
            // price
            // 
            this.price.HeaderText = "Price";
            this.price.MinimumWidth = 6;
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 125;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.MinimumWidth = 6;
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 125;
            // 
            // category
            // 
            this.category.HeaderText = "Category";
            this.category.MinimumWidth = 6;
            this.category.Name = "category";
            this.category.ReadOnly = true;
            this.category.Width = 125;
            // 
            // manuf
            // 
            this.manuf.HeaderText = "Manuf";
            this.manuf.MinimumWidth = 6;
            this.manuf.Name = "manuf";
            this.manuf.ReadOnly = true;
            this.manuf.Width = 125;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.panel3.Controls.Add(this.back_button);
            this.panel3.Controls.Add(this.closeButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1173, 28);
            this.panel3.TabIndex = 7;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseMove);
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI Black", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.closeButton.ForeColor = System.Drawing.Color.DarkRed;
            this.closeButton.Location = new System.Drawing.Point(1146, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(26, 28);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Х";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // back_button
            // 
            this.back_button.Location = new System.Drawing.Point(0, 0);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(94, 29);
            this.back_button.TabIndex = 33;
            this.back_button.Text = "Назад";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 577);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Label closeButton;
        private DataGridView dataGridView1;
        private TextBox find_product_box;
        private Button find_pr_button;
        private TextBox del_pr_textBox;
        private Button del_pr_button;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn Product;
        private DataGridViewTextBoxColumn price;
        private DataGridViewTextBoxColumn Amount;
        private DataGridViewTextBoxColumn category;
        private DataGridViewTextBoxColumn manuf;
        private Label label1;
        private TextBox Amount_box;
        private TextBox Price_box;
        private TextBox Product_box;
        private Button add_pr_button;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button show_tbl_button;
        private ComboBox categ_comboBox;
        private ComboBox manuf_comboBox;
        private Button change_pr_button;
        private TextBox change_pr_box;
        private Label label6;
        private Button back_button;
    }
}