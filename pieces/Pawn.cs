using Chess.forms;
using System.Collections.Generic;
using System.Drawing;

namespace Chess.pieces
{
    internal class Pawn : Piece
    {
        private int _previous_x;

        public int Previous_x { get => _previous_x; set => _previous_x = value; }

        public Pawn(PieceColor color, PieceType type, Image image, bool active, int pos_x, int pos_y) : base(color, type, image, active, pos_x, pos_y)
        {
        }

        public override IEnumerable<int> ValidMoves()
        {
            int position = Pos_y + Pos_x * Game.BoardSize;

            switch (Color) 
            {
                case PieceColor.White:
                    if (Pos_x - 1 >= 0)
                    {
                        if (Pos_x == Game.BoardSize - 2)
                        {
                            for (int i = 1; i < 3; i++)
                            {
                                if (!IsOwnPiece(position - i * Game.BoardSize) && !IsEnemyPiece(position - i * Game.BoardSize))
                                {
                                    yield return position - i * Game.BoardSize;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (!IsOwnPiece(position - Game.BoardSize) && !IsEnemyPiece(position - Game.BoardSize))
                            {
                                yield return position - Game.BoardSize;
                            }
                        }
                        if (IsEnemyPiece(position - Game.BoardSize + 1) && Pos_y + 1 <= Game.BoardSize - 1)
                        {
                            yield return position - Game.BoardSize + 1;
                        }
                        if (IsEnemyPiece(position - Game.BoardSize - 1) && Pos_y - 1 >= 0)
                        {
                            yield return position - Game.BoardSize - 1;
                        }
                    }
                    break;
                case PieceColor.Black:
                    if (Pos_x + 1 <= Game.BoardSize)
                    {
                        if (Pos_x == 1)
                        {
                            for (int i = 1; i < 3; i++)
                            {
                                if (!IsOwnPiece(position + i * Game.BoardSize) && !IsEnemyPiece(position + i * Game.BoardSize))
                                {
                                    yield return position + i * Game.BoardSize;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (!IsOwnPiece(position + Game.BoardSize) && !IsEnemyPiece(position + Game.BoardSize))
                            {
                                yield return position + Game.BoardSize;
                            }
                        }
                        if (IsEnemyPiece(position + Game.BoardSize + 1) && Pos_y + 1 <= Game.BoardSize - 1)
                        {
                            yield return position + Game.BoardSize + 1;
                        }
                        if (IsEnemyPiece(position + Game.BoardSize - 1) && Pos_y - 1 >= 0)
                        {
                            yield return position + Game.BoardSize - 1;
                        }
                    }
                    break;
            }
        }

    }
}