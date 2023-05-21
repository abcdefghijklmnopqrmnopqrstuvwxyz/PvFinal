namespace Chess.forms
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.ScreenLayout = new System.Windows.Forms.TableLayoutPanel();
            this.User1 = new System.Windows.Forms.Label();
            this.User2 = new System.Windows.Forms.Label();
            this.BoardLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ScreenLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScreenLayout
            // 
            this.ScreenLayout.ColumnCount = 1;
            this.ScreenLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ScreenLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ScreenLayout.Controls.Add(this.User1, 0, 0);
            this.ScreenLayout.Controls.Add(this.User2, 0, 2);
            this.ScreenLayout.Controls.Add(this.BoardLayout, 0, 1);
            this.ScreenLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScreenLayout.Location = new System.Drawing.Point(0, 0);
            this.ScreenLayout.Name = "ScreenLayout";
            this.ScreenLayout.RowCount = 3;
            this.ScreenLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ScreenLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.ScreenLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ScreenLayout.Size = new System.Drawing.Size(1200, 900);
            this.ScreenLayout.TabIndex = 0;
            // 
            // User1
            // 
            this.User1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.User1.AutoSize = true;
            this.User1.Font = new System.Drawing.Font("Tahoma", 24F);
            this.User1.Location = new System.Drawing.Point(437, 25);
            this.User1.Name = "User1";
            this.User1.Size = new System.Drawing.Size(325, 39);
            this.User1.TabIndex = 0;
            this.User1.Text = "Searching for game...";
            // 
            // User2
            // 
            this.User2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.User2.AutoSize = true;
            this.User2.Font = new System.Drawing.Font("Tahoma", 24F);
            this.User2.Location = new System.Drawing.Point(437, 835);
            this.User2.Name = "User2";
            this.User2.Size = new System.Drawing.Size(325, 39);
            this.User2.TabIndex = 1;
            this.User2.Text = "Searching for game...";
            // 
            // BoardLayout
            // 
            this.BoardLayout.ColumnCount = 8;
            this.BoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BoardLayout.Location = new System.Drawing.Point(3, 93);
            this.BoardLayout.Name = "BoardLayout";
            this.BoardLayout.RowCount = 8;
            this.BoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.BoardLayout.Size = new System.Drawing.Size(1194, 714);
            this.BoardLayout.TabIndex = 2;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 900);
            this.Controls.Add(this.ScreenLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Game";
            this.Text = "Chess Duel";
            this.Resize += new System.EventHandler(this.BoardScreen_Resize);
            this.ScreenLayout.ResumeLayout(false);
            this.ScreenLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ScreenLayout;
        private System.Windows.Forms.Label User1;
        private System.Windows.Forms.Label User2;
        private System.Windows.Forms.TableLayoutPanel BoardLayout;
    }
}