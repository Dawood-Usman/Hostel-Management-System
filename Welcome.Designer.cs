
namespace Hostel_Management_System
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.panel1 = new System.Windows.Forms.Panel();
            this.WelcomeCross = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AW_AdminBtn = new System.Windows.Forms.Button();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.AW_StudentBtn = new System.Windows.Forms.Button();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.TeamBtn = new System.Windows.Forms.Button();
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WelcomeCross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.WelcomeCross);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1386, 148);
            this.panel1.TabIndex = 0;
            // 
            // WelcomeCross
            // 
            this.WelcomeCross.Image = ((System.Drawing.Image)(resources.GetObject("WelcomeCross.Image")));
            this.WelcomeCross.Location = new System.Drawing.Point(1312, 58);
            this.WelcomeCross.Name = "WelcomeCross";
            this.WelcomeCross.Size = new System.Drawing.Size(47, 32);
            this.WelcomeCross.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.WelcomeCross.TabIndex = 6;
            this.WelcomeCross.TabStop = false;
            this.WelcomeCross.Click += new System.EventHandler(this.WelcomeCross_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(396, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(594, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hostel Management System";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(52, 195);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(527, 529);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(606, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 55);
            this.label2.TabIndex = 2;
            this.label2.Text = "Welcome!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(611, 354);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(586, 189);
            this.label3.TabIndex = 3;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // AW_AdminBtn
            // 
            this.AW_AdminBtn.BackColor = System.Drawing.Color.Teal;
            this.AW_AdminBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AW_AdminBtn.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AW_AdminBtn.ForeColor = System.Drawing.Color.White;
            this.AW_AdminBtn.Location = new System.Drawing.Point(663, 578);
            this.AW_AdminBtn.Name = "AW_AdminBtn";
            this.AW_AdminBtn.Size = new System.Drawing.Size(183, 60);
            this.AW_AdminBtn.TabIndex = 4;
            this.AW_AdminBtn.Text = "Admin";
            this.AW_AdminBtn.UseVisualStyleBackColor = false;
            this.AW_AdminBtn.Click += new System.EventHandler(this.AW_AdminBtn_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 55;
            this.bunifuElipse1.TargetControl = this.AW_AdminBtn;
            // 
            // AW_StudentBtn
            // 
            this.AW_StudentBtn.BackColor = System.Drawing.Color.Teal;
            this.AW_StudentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AW_StudentBtn.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AW_StudentBtn.ForeColor = System.Drawing.Color.White;
            this.AW_StudentBtn.Location = new System.Drawing.Point(888, 578);
            this.AW_StudentBtn.Name = "AW_StudentBtn";
            this.AW_StudentBtn.Size = new System.Drawing.Size(183, 60);
            this.AW_StudentBtn.TabIndex = 5;
            this.AW_StudentBtn.Text = "Student";
            this.AW_StudentBtn.UseVisualStyleBackColor = false;
            this.AW_StudentBtn.Click += new System.EventHandler(this.AW_StudentBtn_Click);
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 55;
            this.bunifuElipse2.TargetControl = this.AW_StudentBtn;
            // 
            // TeamBtn
            // 
            this.TeamBtn.BackColor = System.Drawing.Color.Teal;
            this.TeamBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TeamBtn.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamBtn.ForeColor = System.Drawing.Color.White;
            this.TeamBtn.Location = new System.Drawing.Point(1113, 578);
            this.TeamBtn.Name = "TeamBtn";
            this.TeamBtn.Size = new System.Drawing.Size(183, 60);
            this.TeamBtn.TabIndex = 6;
            this.TeamBtn.Text = "Team";
            this.TeamBtn.UseVisualStyleBackColor = false;
            this.TeamBtn.Click += new System.EventHandler(this.TeamBtn_Click);
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 55;
            this.bunifuElipse3.TargetControl = this.TeamBtn;
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 779);
            this.Controls.Add(this.TeamBtn);
            this.Controls.Add(this.AW_StudentBtn);
            this.Controls.Add(this.AW_AdminBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WelcomeCross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AW_AdminBtn;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Button AW_StudentBtn;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.PictureBox WelcomeCross;
        private System.Windows.Forms.Button TeamBtn;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
    }
}

