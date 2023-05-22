﻿using Chess.pieces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chess.forms
{
    public partial class Game : Form
    {
        private readonly Button[,] chessboardButtons = new Button[8, 8];

        public Game()
        {
            InitializeComponent();
            ResizeComponents();
            SetupBoard();
            SetupPieces();
            ResizeImages();
        }

        private void BoardScreen_Resize(object sender, EventArgs e)
        {
            if (!(WindowState == FormWindowState.Minimized))
            {
                ResizeComponents();
                ResizeImages();
            }
        }

        private void ResizeComponents()
        {
            int width = this.ClientSize.Width / 4;
            int height = this.ClientSize.Height / 8;

            Font titleFont = new Font("Tahoma", width / 10, FontStyle.Regular);

            User1.Size = new Size(width, height);
            User2.Size = new Size(width, height);

            User1.Font = titleFont;
            User2.Font = titleFont;

            if (this.ClientSize.Height < this.ClientSize.Width)
            {
                int margin = (this.ClientSize.Width - this.ClientSize.Height) / 2;
                BoardLayout.Margin = new Padding(margin, 0, margin, 0);
            }
            else 
            {
                int margin = (this.ClientSize.Height - this.ClientSize.Width) / 3;
                BoardLayout.Margin = new Padding(0, margin, 0, margin);
            }
        }

        private void SetupBoard()
        {
            Color lightSquareColor = Color.White;
            Color darkSquareColor = Color.Gray;

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Button button = new Button();
                    button.Dock = DockStyle.Fill;
                    button.Margin = new Padding(0);

                    Color squareColor = (row + col) % 2 == 0 ? lightSquareColor : darkSquareColor;
                    button.BackColor = squareColor;

                    button.FlatStyle = FlatStyle.Flat;

                    chessboardButtons[row, col] = button;

                    BoardLayout.Controls.Add(button, col, row);

                    chessboardButtons[row, col] = button;
                }
            }
        }

        private void SetupPieces()
        {
            foreach (var x in Pieces.ListBlack)
            {
                chessboardButtons[x.Pos_y, x.Pos_x].Image = x.Image;
            }
            foreach (var x in Pieces.ListWhite)
            {
                chessboardButtons[x.Pos_y, x.Pos_x].Image = x.Image;
            }
        }

        private void ResizeImages()
        {
            foreach (var x in chessboardButtons)
            {
                if (x.Image != null)
                {
                    Size newSize = new Size(x.Width - x.Width / 5, x.Height - x.Height / 10);
                    x.Image = ResizeImage(x.Image, newSize);
                }
            }
        }

        private Image ResizeImage(Image image, Size newSize)
        {
            Bitmap resizedImage = new Bitmap(newSize.Width, newSize.Height);

            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, 0, 0, newSize.Width, newSize.Height);
            }

            return resizedImage;
        }

        public void SetupNames(string name1, string name2)
        {
            User1.Text = name1;
            User2.Text = name2;
        }

    }
}