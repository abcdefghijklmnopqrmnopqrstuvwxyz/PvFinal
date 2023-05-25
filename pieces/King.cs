using Chess.forms;
using System.Collections.Generic;
using System.Drawing;

namespace Chess.pieces
{
    internal class King : Piece
    {
        public King(PieceColor color, PieceType type, Image image, bool active, int pos_x, int pos_y) : base(color, type, image, active, pos_x, pos_y)
        {
        }

        public override IEnumerable<int> ValidMoves()
        {
            int position = Pos_y + Pos_x * Game.BoardSize;

            if (Pos_y + 1 <= Game.BoardSize - 1)
            {
                if (!IsOwnPiece(position + 1))
                    yield return position + 1;
                if (!IsOwnPiece(position + Game.BoardSize + 1))
                    yield return position + Game.BoardSize + 1;
                if (!IsOwnPiece(position - Game.BoardSize + 1))
                    yield return position - Game.BoardSize + 1;
            }

            if (Pos_y - 1 >= 0)
            {
                if (!IsOwnPiece(position - 1))
                    yield return position - 1;
                if (!IsOwnPiece(position + Game.BoardSize - 1))
                    yield return position + Game.BoardSize - 1;
                if (!IsOwnPiece(position - Game.BoardSize - 1))
                    yield return position - Game.BoardSize - 1;
            }

            if (!IsOwnPiece(position + Game.BoardSize) && Pos_x + 1 >= 0)
                yield return position + Game.BoardSize;
            if (!IsOwnPiece(position - Game.BoardSize) && Pos_x - 1 <= Game.BoardSize - 1)
                yield return position - Game.BoardSize;
        }

    }
}