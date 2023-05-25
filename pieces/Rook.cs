using Chess.forms;
using System.Collections.Generic;
using System.Drawing;

namespace Chess.pieces
{
    internal class Rook : Piece
    {
        public Rook(PieceColor color, PieceType type, Image image, bool active, int pos_x, int pos_y) : base(color, type, image, active, pos_x, pos_y)
        {
        }

        public override IEnumerable<int> ValidMoves()
        {
            int position = Pos_y + Pos_x * Game.BoardSize;
            int index = Game.BoardSize;
            int isout = 1;

            while (Pos_x - isout >= 0)
            {
                if (!IsOwnPiece(position - index))
                {
                    if (IsEnemyPiece(position - index))
                    {
                        yield return position - index;
                        break;
                    }
                    yield return position - index;
                }
                else
                    break;
                index += Game.BoardSize;
                isout++;
            }

            index = Game.BoardSize;
            isout = 1;

            while (Pos_x + isout <= Game.BoardSize - 1)
            {
                if (!IsOwnPiece(position + index))
                {
                    if (IsEnemyPiece(position + index))
                    {
                        yield return position + index;
                        break;
                    }
                    yield return position + index;
                }
                else
                    break;
                index += Game.BoardSize;
                isout++;
            }

            index = 1;
            isout = 1;

            while (Pos_y + isout <= Game.BoardSize - 1)
            {
                if (!IsOwnPiece(position + index))
                {
                    if (IsEnemyPiece(position + index))
                    {
                        yield return position + index;
                        break;
                    }
                    yield return position + index;
                }
                else
                    break;
                index++;
                isout++;
            }

            index = 1;
            isout = 1;

            while (Pos_y - isout >= 0)
            {
                if (!IsOwnPiece(position - index))
                {
                    if (IsEnemyPiece(position - index))
                    {
                        yield return position - index;
                        break;
                    }
                    yield return position - index;
                }
                else
                    break;
                index++;
                isout++;
            }
        }

    }
}