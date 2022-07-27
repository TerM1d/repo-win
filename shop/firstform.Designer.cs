namespace first_form
{
    partial class firstform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(firstform));
            this.panel3 = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Label();
            this.button_adm = new System.Windows.Forms.Button();
            this.button_usr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.closeButton);
            this.panel3.Name = "panel3";
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseMove);
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.ForeColor = System.Drawing.Color.Orange;
            this.closeButton.Name = "closeButton";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // button_adm
            // 
            resources.ApplyResources(this.button_adm, "button_adm");
            this.button_adm.BackColor = System.Drawing.Color.DimGray;
            this.button_adm.ForeColor = System.Drawing.Color.Orange;
            this.button_adm.Name = "button_adm";
            this.button_adm.UseVisualStyleBackColor = false;
            this.button_adm.Click += new System.EventHandler(this.button_adm_Click);
            // 
            // button_usr
            // 
            resources.ApplyResources(this.button_usr, "button_usr");
            this.button_usr.BackColor = System.Drawing.Color.DimGray;
            this.button_usr.ForeColor = System.Drawing.Color.Orange;
            this.button_usr.Name = "button_usr";
            this.button_usr.UseVisualStyleBackColor = false;
            this.button_usr.Click += new System.EventHandler(this.button_usr_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // firstform
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_usr);
            this.Controls.Add(this.button_adm);
            this.Controls.Add(this.panel3);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "firstform";
            this.Load += new System.EventHandler(this.firstform_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel3;
        private Label closeButton;
        private Button button_adm;
        private Button button_usr;
        private Label label1;
        private Label label2;
    }
}