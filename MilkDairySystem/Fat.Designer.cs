
namespace MilkDairySystem
{
    partial class Fat
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtdate = new System.Windows.Forms.TextBox();
            this.txttime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBackAccount = new System.Windows.Forms.Button();
            this.txtFat = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.txtShowFat = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.txtFatid = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtdate);
            this.panel1.Controls.Add(this.txttime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 142);
            this.panel1.TabIndex = 2;
            // 
            // txtdate
            // 
            this.txtdate.BackColor = System.Drawing.Color.White;
            this.txtdate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtdate.Enabled = false;
            this.txtdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdate.ForeColor = System.Drawing.Color.Red;
            this.txtdate.Location = new System.Drawing.Point(814, 28);
            this.txtdate.Multiline = true;
            this.txtdate.Name = "txtdate";
            this.txtdate.Size = new System.Drawing.Size(158, 31);
            this.txtdate.TabIndex = 7;
            this.txtdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txttime
            // 
            this.txttime.BackColor = System.Drawing.Color.White;
            this.txttime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txttime.Enabled = false;
            this.txttime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttime.ForeColor = System.Drawing.Color.Red;
            this.txttime.Location = new System.Drawing.Point(814, 0);
            this.txttime.Multiline = true;
            this.txttime.Name = "txttime";
            this.txttime.ReadOnly = true;
            this.txttime.Size = new System.Drawing.Size(158, 27);
            this.txttime.TabIndex = 6;
            this.txttime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(179, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(587, 45);
            this.label2.TabIndex = 2;
            this.label2.Text = "Milk Dairy Management System";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::MilkDairySystem.Properties.Resources.milk;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(0, 148);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(972, 600);
            this.panel2.TabIndex = 24;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnBackAccount);
            this.panel3.Controls.Add(this.txtFat);
            this.panel3.Controls.Add(this.txtShowFat);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.btnAddAccount);
            this.panel3.Controls.Add(this.txtFatid);
            this.panel3.Location = new System.Drawing.Point(83, 110);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(811, 398);
            this.panel3.TabIndex = 5;
            // 
            // btnBackAccount
            // 
            this.btnBackAccount.BackColor = System.Drawing.Color.Violet;
            this.btnBackAccount.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackAccount.Location = new System.Drawing.Point(465, 228);
            this.btnBackAccount.Name = "btnBackAccount";
            this.btnBackAccount.Size = new System.Drawing.Size(162, 48);
            this.btnBackAccount.TabIndex = 35;
            this.btnBackAccount.Text = "BACK";
            this.btnBackAccount.UseVisualStyleBackColor = false;
            this.btnBackAccount.Click += new System.EventHandler(this.btnBackAccount_Click);
            // 
            // txtFat
            // 
            this.txtFat.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtFat.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFat.Location = new System.Drawing.Point(306, 163);
            this.txtFat.Multiline = true;
            this.txtFat.Name = "txtFat";
            this.txtFat.Size = new System.Drawing.Size(391, 25);
            this.txtFat.TabIndex = 32;
            this.txtFat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFat_KeyPress);
            // 
            // txtShowFat
            // 
            this.txtShowFat.BackColor = System.Drawing.SystemColors.Menu;
            this.txtShowFat.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtShowFat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtShowFat.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShowFat.Location = new System.Drawing.Point(311, 105);
            this.txtShowFat.Multiline = true;
            this.txtShowFat.Name = "txtShowFat";
            this.txtShowFat.Size = new System.Drawing.Size(232, 25);
            this.txtShowFat.TabIndex = 31;
            this.txtShowFat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtShowFat.TextChanged += new System.EventHandler(this.txtShowFat_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(331, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 30);
            this.label4.TabIndex = 23;
            this.label4.Text = "Update Fat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(127, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 25);
            this.label5.TabIndex = 24;
            this.label5.Text = "Fat Current Price";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(128, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 25);
            this.label7.TabIndex = 25;
            this.label7.Text = "Update Fat Price ";
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.BackColor = System.Drawing.Color.Violet;
            this.btnAddAccount.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAccount.Location = new System.Drawing.Point(201, 228);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(162, 48);
            this.btnAddAccount.TabIndex = 30;
            this.btnAddAccount.Text = "UPDATE";
            this.btnAddAccount.UseVisualStyleBackColor = false;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // txtFatid
            // 
            this.txtFatid.BackColor = System.Drawing.SystemColors.Menu;
            this.txtFatid.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtFatid.Enabled = false;
            this.txtFatid.Location = new System.Drawing.Point(203, 233);
            this.txtFatid.Multiline = true;
            this.txtFatid.Name = "txtFatid";
            this.txtFatid.Size = new System.Drawing.Size(10, 10);
            this.txtFatid.TabIndex = 36;
            this.txtFatid.Text = "1";
            this.txtFatid.TextChanged += new System.EventHandler(this.txtFatid_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(340, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(309, 35);
            this.label3.TabIndex = 4;
            this.label3.Text = "||   FAT DETAIL    ||";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Fat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 744);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Fat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fat";
            this.Load += new System.EventHandler(this.Fat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtdate;
        private System.Windows.Forms.TextBox txttime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnBackAccount;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtFat;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtShowFat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Label label3;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtFatid;
        private System.Windows.Forms.Timer timer1;
    }
}