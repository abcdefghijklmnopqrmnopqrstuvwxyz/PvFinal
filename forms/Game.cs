using Chess.pieces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Chess.forms
{
    public partial class Game : Form
    {
        private readonly Button[,] chessboardButtons = new Button[BoardSize, BoardSize];
        public const int BoardSize = 8;
        private Piece ActivePiece = null;

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
            int height = this.ClientSize.Height / BoardSize;

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

            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    Button button = new Button();
                    button.Dock = DockStyle.Fill;
                    button.Margin = new Padding(0);
                    button.BackgroundImageLayout = ImageLayout.Center;
                    button.Click += TryMove;  
                    button.FlatStyle = FlatStyle.Flat;
                    BoardLayout.Controls.Add(button, col, row);
                    chessboardButtons[row, col] = button;
                }
            }

            ColorButtons();
        }

        private void ColorButtons()
        {
            for (int i = 0; i < chessboardButtons.GetLength(0); i++)
            {
                for (int j = 0; j < chessboardButtons.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                        chessboardButtons[i, j].BackColor = Color.White;
                    else
                        chessboardButtons[i, j].BackColor = Color.Gray;
                }
            }
        }

        private void TryMove(object sender, EventArgs e)
        {
            int index = BoardLayout.GetColumn((Button)sender) + (BoardLayout.GetRow((Button)sender) * BoardSize);

            CheckActivePiece(index);

            for (int i = 0; i < chessboardButtons.GetLength(0); i++)
            {
                for (int j = 0; j < chessboardButtons.GetLength(1); j++)
                {
                    Button button = chessboardButtons[i, j];

                    if (button.BackColor == Color.LightGreen && j + (i * BoardSize) == index)
                    {
                        button.Image = ActivePiece.Image;
                        RemovePiece(ActivePiece.Pos_x, ActivePiece.Pos_y);
                        //Previous_x změna pro braní mimochodem
                        ActivePiece.Pos_x = i;
                        ActivePiece.Pos_y = j;
                    }
                }
            }

            ColorButtons();
            HighlightMoves();
            ResizeImages();
        }

        private void RemovePiece(int x, int y)
        {
            chessboardButtons[x, y].Image = null;
        }

        private void CheckActivePiece(int index)
        {
            List<Piece> list = PiecesList.ListBlack.Concat(PiecesList.ListWhite).ToList();

            foreach (Piece piece in list)
            {
                int pieceIndex = piece.Pos_y + (piece.Pos_x * BoardSize);

                if (index == pieceIndex)
                {
                    ActivePiece = piece;
                    return;
                }
            }

            for (int i = 0; i < chessboardButtons.GetLength(0); i++)
            {
                for (int j = 0; j < chessboardButtons.GetLength(1); j++)
                {
                    Button button = chessboardButtons[i, j];

                    if (button.BackColor == Color.LightGreen && j + (i * BoardSize) == index)
                        return;
                }
            }

            ActivePiece = null;
        }

        private void HighlightMoves()
        {
            if (ActivePiece != null)
            {
                chessboardButtons[ActivePiece.Pos_x, ActivePiece.Pos_y].BackColor = Color.IndianRed;

                foreach (int position in ActivePiece.ValidMoves())
                {
                    for (int i = 0; i < chessboardButtons.GetLength(0); i++)
                    {
                        for (int j = 0; j < chessboardButtons.GetLength(1); j++)
                        {
                            if (j + (i * BoardSize) == position)
                                chessboardButtons[i, j].BackColor = Color.LightGreen;
                        }
                    }
                }
            }
        }

        private void SetupPieces()
        {
            foreach (var x in PiecesList.ListBlack)
                chessboardButtons[x.Pos_x, x.Pos_y].Image = x.Image;
            foreach (var x in PiecesList.ListWhite)
                chessboardButtons[x.Pos_x, x.Pos_y].Image = x.Image;
        }

        private void ResizeImages()
        {
            foreach (var x in chessboardButtons)
            {
                if (x.Image != null)
                {
                    Size newSize = new Size(x.Width - x.Width / 3, x.Height - x.Height / 6);
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