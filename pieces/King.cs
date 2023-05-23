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
            yield return 0;
        }

        public override bool IsOwnPiece(int x, int y)
        {
            return false;
        }

    }
}