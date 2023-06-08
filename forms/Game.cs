using Chess.pieces;
using Chess.tcp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Chess.forms
{
    public partial class Game : Form
    {
        /*
         * This class contains all logic for the game and UI.
         */

        private Server server;
        private Client client;
        private readonly Button[,] chessboardButtons = new Button[BoardSize, BoardSize];
        private Piece ActivePiece = null;
        private readonly bool IsServer;
        public static bool IsOnTurn = false;

        /*
         * Provides board size, pieces are made to be responsive so the board size can be changed. 
         * Pieces are placed static to the board, so if board size is changed, 
         * do not forget to check pieces lists in class 'Chess.pieces.PieceList.cs'
         */
        public const int BoardSize = 8;

        /// <summary>
        /// Inicializes game form and starts 'Server' instance listening for clients on background on port 2459
        /// </summary>
        public Game()
        {
            Init();
            IsServer = true;
            server = new Server(this);
        }

        /// <summary>
        /// Inicializes game form and starts 'Client' instance searching for server on background on port 2459
        /// </summary>
        /// <param name="ip"></param>
        public Game(string ip)
        {
            Init();
            IsServer = false;
            client = new Client(this, ip);
        }

        /// <summary>
        /// Inicializes game form.
        /// </summary>
        private void Init()
        {
            InitializeComponent();
            ResizeComponents();
            SetupBoard();
            SetupPieces();
        }

        private void BoardScreen_Resize(object sender, EventArgs e)
        {
            if (!(WindowState == FormWindowState.Minimized))
                ResizeComponents();
        }


        /// <summary>
        /// Resizes components of 'Game' form.
        /// </summary>
        private void ResizeComponents()
        {
            int width = ClientSize.Width / 4;
            int height = ClientSize.Height / BoardSize;

            Font titleFont = new Font("Tahoma", width / 10, FontStyle.Regular);

            User1.Size = new Size(width, height);
            User2.Size = new Size(width, height);

            User1.Font = titleFont;
            User2.Font = titleFont;

            if (ClientSize.Height < ClientSize.Width)
            {
                int margin = (ClientSize.Width - ClientSize.Height) / 2;
                BoardLayout.Margin = new Padding(margin, 0, margin, 0);
            }
            else 
            {
                int margin = (ClientSize.Height - ClientSize.Width) / 3;
                BoardLayout.Margin = new Padding(0, margin, 0, margin);
            }
        }

        /// <summary>
        /// Sets up chess board UI.
        /// </summary>
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

        /// <summary>
        /// Colours chess board to make black and white pattern.
        /// </summary>
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

        /// <summary>
        /// If users is on turn, tries to move.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TryMove(object sender, EventArgs e)
        {
            if (!IsOnTurn)
                return;

            int index = BoardLayout.GetColumn((Button)sender) + (BoardLayout.GetRow((Button)sender) * BoardSize);
            List<Piece> list = PiecesList.ListBlack.Concat(PiecesList.ListWhite).ToList();

            bool checkactive = true;

            foreach (Piece piece in list)
            {
                int pieceIndex = piece.Pos_y + (piece.Pos_x * BoardSize);
                if (pieceIndex == index && chessboardButtons[piece.Pos_x, piece.Pos_y].BackColor == Color.LightGreen)
                    checkactive = false;
            }

            if (checkactive)
                CheckActivePiece(index, list);

            for (int i = 0; i < chessboardButtons.GetLength(0); i++)
            {
                for (int j = 0; j < chessboardButtons.GetLength(1); j++)
                {
                    Button button = chessboardButtons[i, j];

                    if (button.BackColor == Color.LightGreen && j + (i * BoardSize) == index)
                    {
                        string msg = (ActivePiece.Pos_x * BoardSize + ActivePiece.Pos_y) + "," + i + "," + j;
                        if (IsServer)
                            Server.message = msg;
                        else
                            Client.message = msg;
                        DiscardPiece(j + i * BoardSize);
                        button.Image = ActivePiece.Image;
                        RemovePiece(ActivePiece.Pos_x, ActivePiece.Pos_y);
                        ActivePiece.Pos_x = i; 
                        ActivePiece.Pos_y = j;
                        ActivePiece = null;
                        Promote();
                    }
                }
            }

            ColorButtons();
            HighlightMoves();
        }

        /// <summary>
        /// Checks if pawn is on back line. If yes, promotes the pawn to queen.
        /// </summary>
        private void Promote()
        {
            List<Piece> list = PiecesList.ListBlack.Concat(PiecesList.ListWhite).ToList();

            foreach (Piece piece in list)
            {
                if (piece.Type == PieceType.Pawn && (piece.Pos_x == BoardSize - 1 || piece.Pos_x == 0))
                {
                    if (piece.Color == PieceColor.White)
                    {
                        PiecesList.ListWhite.Add(new Queen(piece.Color, PieceType.Queen, Image.FromFile(PiecesList.Path + "w_queen.png"), true, piece.Pos_x, piece.Pos_y));
                        chessboardButtons[piece.Pos_x, piece.Pos_y].Image = Image.FromFile(PiecesList.Path + "w_queen.png");
                    }
                    else
                    {
                        PiecesList.ListWhite.Add(new Queen(piece.Color, PieceType.Queen, Image.FromFile(PiecesList.Path + "b_queen.png"), true, piece.Pos_x, piece.Pos_y));
                        chessboardButtons[piece.Pos_x, piece.Pos_y].Image = Image.FromFile(PiecesList.Path + "b_queen.png");
                    }
                    piece.Active = false;
                    piece.Image = null;
                    piece.Pos_x = -1;
                    piece.Pos_y = -1;
                }
            }
        }

        /// <summary>
        /// Tries to discard the piece on specified index.
        /// </summary>
        /// <param name="index"></param>
        private void DiscardPiece(int index)
        {
            foreach (Piece piece in ActivePiece.Color == PieceColor.White ? PiecesList.ListBlack : PiecesList.ListWhite)
            {
                int pieceIndex = piece.Pos_y + (piece.Pos_x * BoardSize);
                if (pieceIndex == index)
                {
                    piece.Active = false;
                    piece.Image = null;
                    piece.Pos_x = -1;
                    piece.Pos_y = -1;
                    if (piece.Type == PieceType.King)
                    {
                        if (piece.Color == PieceColor.White)
                        {
                            Server.message += ",black";
                            Client.message += ",black";
                        }
                        else
                        {
                            Server.message += ",white";
                            Client.message += ",white";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Removes piece as background picture from button on specified coordinations.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void RemovePiece(int x, int y)
        {
            chessboardButtons[x, y].Image = null;
        }

        /// <summary>
        /// Puts piece that user clicked on into 'ActivePiece' instance for future manipulation.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="list"></param>
        private void CheckActivePiece(int index, List<Piece> list)
        {
            foreach (Piece piece in list)
            {
                int pieceIndex = piece.Pos_y + (piece.Pos_x * BoardSize);
                if (index == pieceIndex && piece.Active)
                {
                    if ((piece.Color == PieceColor.White && !IsServer) || (piece.Color == PieceColor.Black && IsServer))
                        return;
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

        /// <summary>
        /// For 'ActivePiece' instance, highlists all possible moves that can be made.
        /// </summary>
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

        /// <summary>
        /// Sets up all pieces to positions from static-made sets of pieces for 8x8 board size.
        /// </summary>
        private void SetupPieces()
        {
            foreach (var x in PiecesList.ListBlack)
                chessboardButtons[x.Pos_x, x.Pos_y].Image = x.Image;
            foreach (var x in PiecesList.ListWhite)
                chessboardButtons[x.Pos_x, x.Pos_y].Image = x.Image;
        }

        /// <summary>
        /// Moves opponents piece from 'index' to 'bx, by' coordinations.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="bx"></param>
        /// <param name="by"></param>
        public void OpponentMove(int index, int bx, int by)
        {
            List<Piece> list = PiecesList.ListBlack.Concat(PiecesList.ListWhite).ToList();

            foreach (Piece piece in list)
            {
                int pieceIndex = piece.Pos_y + (piece.Pos_x * BoardSize);
                if (pieceIndex == index)
                    ActivePiece = piece;
            }

            DiscardPiece(by + BoardSize * bx);
            chessboardButtons[bx, by].Image = ActivePiece.Image;
            RemovePiece(ActivePiece.Pos_x, ActivePiece.Pos_y);
            ActivePiece.Pos_x = bx;
            ActivePiece.Pos_y = by;
            ActivePiece = null;
            Promote();
        }

        /// <summary>
        /// Setups names for both users.
        /// </summary>
        /// <param name="name1"></param>
        /// <param name="name2"></param>
        public void SetupNames(string name1, string name2)
        {
            User1.Text = name1;
            User2.Text = name2;
        }

    }
}