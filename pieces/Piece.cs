using Chess.forms;
using System.Collections.Generic;
using System.Drawing;

namespace Chess.pieces
{
    internal class Piece
    {
        private PieceColor _color;
        private PieceType _type;
        private Image _image;
        private bool _active;
        private int _pos_x;
        private int _pos_y;

        public PieceColor Color { get => _color; set => _color = value; }
        public PieceType Type { get => _type; set => _type = value; }
        public Image Image { get => _image; set => _image = value; }
        public bool Active { get => _active; set => _active = value; }
        public int Pos_x { get => _pos_x; set => _pos_x = value; }
        public int Pos_y { get => _pos_y; set => _pos_y = value; }

        protected Piece(PieceColor color, PieceType type, Image image, bool active, int pos_x, int pos_y)
        {
            Color = color;
            Type = type;
            Image = image;
            Active = active;
            Pos_x = pos_x;
            Pos_y = pos_y;
        }

        /// <summary>
        /// Gets valid moves for its piece.
        /// </summary>
        /// <returns>Enumeration of moves</returns>
        /// <exception cref="System.Exception"></exception>
        public virtual IEnumerable<int> ValidMoves()
        {
            throw new System.Exception(message: "Not implemented.");
        }

        /// <summary>
        /// Check if on specified index of board is same team piece.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>True/False</returns>
        protected bool IsOwnPiece(int index)
        {
            foreach (Piece piece in Color == PieceColor.White ? PiecesList.ListWhite : PiecesList.ListBlack)
            {
                if (piece.Pos_y + (piece.Pos_x * Game.BoardSize) == index && piece.Active)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Check if on specified index of board is enemy team piece.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>True/False</returns>
        protected bool IsEnemyPiece(int index)
        {
            foreach (Piece piece in Color == PieceColor.White ? PiecesList.ListBlack : PiecesList.ListWhite)
            {
                if (piece.Pos_y + (piece.Pos_x * Game.BoardSize) == index && piece.Active)
                    return true;
            }
            return false;
        }

    }
}