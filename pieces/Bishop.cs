using Chess.forms;
using System.Collections.Generic;
using System.Drawing;

namespace Chess.pieces
{
    internal class Bishop : Piece
    {
        public Bishop(PieceColor color, PieceType type, Image image, bool active, int pos_x, int pos_y) : base(color, type, image, active, pos_x, pos_y)
        {
        }

        public override IEnumerable<int> ValidMoves()
        {
            int position = Pos_y + Pos_x * Game.BoardSize;
            int index = Game.BoardSize + 1;
            int isout = 1;

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
                index += Game.BoardSize + 1;
                isout++;
            }

            index = Game.BoardSize - 1;
            isout = 1;

            while (Pos_y + isout <= Game.BoardSize - 1)
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
                index += Game.BoardSize - 1;
                isout++;
            }

            index = Game.BoardSize - 1;
            isout = 1;

            while (Pos_y - isout >= 0)
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
                index += Game.BoardSize - 1;
                isout++;
            }

            index = Game.BoardSize + 1;
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
                index += Game.BoardSize + 1;
                isout++;
            }
        }

    }
}