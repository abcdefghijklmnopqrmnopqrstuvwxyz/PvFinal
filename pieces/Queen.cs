using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Chess.pieces
{
    internal class Queen : Rook
    {
        private readonly Bishop bishop;

        public Queen(PieceColor color, PieceType type, Image image, bool active, int pos_x, int pos_y) : base(color, type, image, active, pos_x, pos_y)
        {
            bishop = new Bishop(PieceColor.Null, PieceType.Null, null, false, 0, 0);
        }

        public override IEnumerable<int> ValidMoves()
        {
            bishop.Pos_x = Pos_x;
            bishop.Pos_y = Pos_y;
            bishop.Color = Color;

            foreach (var move in base.ValidMoves())
            {
                yield return move;
            }

            foreach (var move in bishop.ValidMoves())
            {
                yield return move;
            }
        }

    }
}