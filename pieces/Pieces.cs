using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Chess.pieces
{
    internal class Pieces
    {
        private static string Path = Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName + "\\res\\";

        public static List<Black> ListBlack = new List<Black> {
            new Black(PieceColor.Black, PieceType.King, Image.FromFile(Path + "b_king.png"), 3, 0),
            new Black(PieceColor.Black, PieceType.Queen, Image.FromFile(Path + "b_queen.png"), 4, 0),
            new Black(PieceColor.Black, PieceType.Rook, Image.FromFile(Path + "b_rook.png"), 0, 0),
            new Black(PieceColor.Black, PieceType.Rook, Image.FromFile(Path + "b_rook.png"), 7, 0),
            new Black(PieceColor.Black, PieceType.Bishop, Image.FromFile(Path + "b_bishop.png"), 2, 0),
            new Black(PieceColor.Black, PieceType.Bishop, Image.FromFile(Path + "b_bishop.png"), 5, 0),
            new Black(PieceColor.Black, PieceType.Knight, Image.FromFile(Path + "b_knight.png"), 1, 0),
            new Black(PieceColor.Black, PieceType.Knight, Image.FromFile(Path + "b_knight.png"), 6, 0),
            new Black(PieceColor.Black, PieceType.Pawn, Image.FromFile(Path + "b_pawn.png"), 0, 1),
            new Black(PieceColor.Black, PieceType.Pawn, Image.FromFile(Path + "b_pawn.png"), 1, 1),
            new Black(PieceColor.Black, PieceType.Pawn, Image.FromFile(Path + "b_pawn.png"), 2, 1),
            new Black(PieceColor.Black, PieceType.Pawn, Image.FromFile(Path + "b_pawn.png"), 3, 1),
            new Black(PieceColor.Black, PieceType.Pawn, Image.FromFile(Path + "b_pawn.png"), 4, 1),
            new Black(PieceColor.Black, PieceType.Pawn, Image.FromFile(Path + "b_pawn.png"), 5, 1),
            new Black(PieceColor.Black, PieceType.Pawn, Image.FromFile(Path + "b_pawn.png"), 6, 1),
            new Black(PieceColor.Black, PieceType.Pawn, Image.FromFile(Path + "b_pawn.png"), 7, 1)
        };

        public static List<White> ListWhite = new List<White> {
            new White(PieceColor.White, PieceType.King, Image.FromFile(Path + "w_king.png"), 3, 7),
            new White(PieceColor.White, PieceType.Queen, Image.FromFile(Path + "w_queen.png"), 4, 7),
            new White(PieceColor.White, PieceType.Rook, Image.FromFile(Path + "w_rook.png"), 0, 7),
            new White(PieceColor.White, PieceType.Rook, Image.FromFile(Path + "w_rook.png"), 7, 7),
            new White(PieceColor.White, PieceType.Bishop, Image.FromFile(Path + "w_bishop.png"), 2, 7),
            new White(PieceColor.White, PieceType.Bishop, Image.FromFile(Path + "w_bishop.png"), 5, 7),
            new White(PieceColor.White, PieceType.Knight, Image.FromFile(Path + "w_knight.png"), 1, 7),
            new White(PieceColor.White, PieceType.Knight, Image.FromFile(Path + "w_knight.png"), 6, 7),
            new White(PieceColor.White, PieceType.Pawn, Image.FromFile(Path + "w_pawn.png"), 0, 6),
            new White(PieceColor.White, PieceType.Pawn, Image.FromFile(Path + "w_pawn.png"), 1, 6),
            new White(PieceColor.White, PieceType.Pawn, Image.FromFile(Path + "w_pawn.png"), 2, 6),
            new White(PieceColor.White, PieceType.Pawn, Image.FromFile(Path + "w_pawn.png"), 3, 6),
            new White(PieceColor.White, PieceType.Pawn, Image.FromFile(Path + "w_pawn.png"), 4, 6),
            new White(PieceColor.White, PieceType.Pawn, Image.FromFile(Path + "w_pawn.png"), 5, 6),
            new White(PieceColor.White, PieceType.Pawn, Image.FromFile(Path + "w_pawn.png"), 6, 6),
            new White(PieceColor.White, PieceType.Pawn, Image.FromFile(Path + "w_pawn.png"), 7, 6)
        };

    }
}