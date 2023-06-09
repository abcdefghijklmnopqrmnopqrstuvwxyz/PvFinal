﻿namespace Chess.forms
{
    partial class Selection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Selection));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Host = new System.Windows.Forms.Button();
            this.Join = new System.Windows.Forms.Button();
            this.IP = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Host, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Join, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.IP, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Host
            // 
            this.Host.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Host.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Host.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Host.Location = new System.Drawing.Point(96, 154);
            this.Host.Name = "Host";
            this.Host.Size = new System.Drawing.Size(207, 68);
            this.Host.TabIndex = 0;
            this.Host.Text = "Host";
            this.Host.UseVisualStyleBackColor = true;
            this.Host.Click += new System.EventHandler(this.Host_Click);
            // 
            // Join
            // 
            this.Join.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Join.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Join.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Join.Location = new System.Drawing.Point(496, 154);
            this.Join.Name = "Join";
            this.Join.Size = new System.Drawing.Size(207, 68);
            this.Join.TabIndex = 1;
            this.Join.Text = "Join";
            this.Join.UseVisualStyleBackColor = true;
            this.Join.Click += new System.EventHandler(this.Join_Click);
            // 
            // IP
            // 
            this.IP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IP.Font = new System.Drawing.Font("Tahoma", 24F);
            this.IP.Location = new System.Drawing.Point(500, 318);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(199, 39);
            this.IP.TabIndex = 2;
            // 
            // Selection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Selection";
            this.Text = "Select Role";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Host;
        private System.Windows.Forms.Button Join;
        private System.Windows.Forms.TextBox IP;
    }
}