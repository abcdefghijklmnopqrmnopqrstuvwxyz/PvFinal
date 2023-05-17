namespace Chess.forms
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Username = new System.Windows.Forms.Label();
            this.Nameinput = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.Passinput = new System.Windows.Forms.TextBox();
            this.Regbutton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Username, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Nameinput, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Password, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Passinput, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Regbutton, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Username
            // 
            this.Username.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Sitka Text", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Username.Location = new System.Drawing.Point(63, 60);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(273, 69);
            this.Username.TabIndex = 0;
            this.Username.Text = "Username:";
            // 
            // Nameinput
            // 
            this.Nameinput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Nameinput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Nameinput.Font = new System.Drawing.Font("Sitka Text", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Nameinput.Location = new System.Drawing.Point(463, 71);
            this.Nameinput.MaxLength = 255;
            this.Nameinput.Name = "Nameinput";
            this.Nameinput.Size = new System.Drawing.Size(274, 47);
            this.Nameinput.TabIndex = 1;
            this.Nameinput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Nameinput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Nameinput_KeyPress);
            // 
            // Password
            // 
            this.Password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Sitka Text", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Password.Location = new System.Drawing.Point(70, 159);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(260, 69);
            this.Password.TabIndex = 2;
            this.Password.Text = "Password:";
            // 
            // Passinput
            // 
            this.Passinput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Passinput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Passinput.Font = new System.Drawing.Font("Sitka Text", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Passinput.Location = new System.Drawing.Point(463, 170);
            this.Passinput.MaxLength = 255;
            this.Passinput.Name = "Passinput";
            this.Passinput.PasswordChar = '*';
            this.Passinput.Size = new System.Drawing.Size(274, 47);
            this.Passinput.TabIndex = 3;
            this.Passinput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Passinput.UseSystemPasswordChar = true;
            // 
            // Regbutton
            // 
            this.Regbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Regbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Regbutton.Font = new System.Drawing.Font("Sitka Text", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Regbutton.Location = new System.Drawing.Point(523, 348);
            this.Regbutton.Name = "Regbutton";
            this.Regbutton.Size = new System.Drawing.Size(154, 54);
            this.Regbutton.TabIndex = 4;
            this.Regbutton.Text = "Register";
            this.Regbutton.UseVisualStyleBackColor = true;
            this.Regbutton.Click += new System.EventHandler(this.Regbutton_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Register";
            this.Text = "Register";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.TextBox Nameinput;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox Passinput;
        private System.Windows.Forms.Button Regbutton;

    }
}