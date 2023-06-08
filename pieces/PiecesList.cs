using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Chess.pieces
{
    internal class PiecesList
    {
        /*
         * This class represents lists of pieces for both players.
         */

        public static readonly string Path = Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName + "\\res\\";

        public static List<Piece> ListBlack = new List<Piece> {
            new King(PieceColor.Black, PieceType.King, Image.FromFile(Path + "b_king.png"), true, 0, 3),
            new Queen(PieceColor.Black, PieceType.Queen, Image.FromFile(Path + "b_queen.png"), true, 0, 4),
            new Rook(PieceColor.Black, PieceType.Rook, Image.FromFile(Path + "b_rook.png"), true, 0, 0),
            new Rook(PieceColor.Black, PieceType.Rook, Image.FromFile(Path + "b_rook.png"), true, 0, 7),
            new Bishop(PieceColor.Black, PieceType.Bishop, Image.FromFile(Path + "b_bishop.png"), true, 0, 2),
            new Bishop(PieceColor.Black, PieceType.Bishop, Image.FromFile(Path + "b_bishop.png"), true, 0, 5),
            new Knight(PieceColor.Black, PieceType.Knight, Image.FromFile(Path + "b_knight.png"), true, 0, 1),
            new Knight(PieceColor.Black, PieceType.Knight, Image.FromFile(Path + "b_knight.png"), true, 0, 6),
            new Pawn(PieceColor.Black, PieceType.Pawn, Image.FromFile(Path + "b_pawn.png"), true, 1, 0),
            new Pawn(PieceColor.Black, PieceType.Pawn, Image.FromFile(Path + "b_pawn.png"), true, 1, 1),
            new Pawn(PieceColor.Black, PieceType.Pawn, Image.FromFile(Path + "b_pawn.png"), true, 1, 2),
            new Pawn(PieceColor.Black, PieceType.Pawn, Image.FromFile(Path + "b_pawn.png"), true, 1, 3),
            new Pawn(PieceColor.Black, PieceType.Pawn, Image.FromFile(Path + "b_pawn.png"), true, 1, 4),
            new Pawn(PieceColor.Black, PieceType.Pawn, Image.FromFile(Path + "b_pawn.png"), true, 1, 5),
            new Pawn(PieceColor.Black, PieceType.Pawn, Image.FromFile(Path + "b_pawn.png"), true, 1, 6),
            new Pawn(PieceColor.Black, PieceType.Pawn, Image.FromFile(Path + "b_pawn.png"), true, 1, 7)
        };

        public static List<Piece> ListWhite = new List<Piece> {
            new King(PieceColor.White, PieceType.King, Image.FromFile(Path + "w_king.png"), true, 7, 3),
            new Queen(PieceColor.White, PieceType.Queen, Image.FromFile(Path + "w_queen.png"), true, 7, 4),
            new Rook(PieceColor.White, PieceType.Rook, Image.FromFile(Path + "w_rook.png"), true, 7, 0),
            new Rook(PieceColor.White, PieceType.Rook, Image.FromFile(Path + "w_rook.png"), true, 7, 7),
            new Bishop(PieceColor.White, PieceType.Bishop, Image.FromFile(Path + "w_bishop.png"), true, 7, 2),
            new Bishop(PieceColor.White, PieceType.Bishop, Image.FromFile(Path + "w_bishop.png"), true, 7, 5),
            new Knight(PieceColor.White, PieceType.Knight, Image.FromFile(Path + "w_knight.png"), true, 7, 1),
            new Knight(PieceColor.White, PieceType.Knight, Image.FromFile(Path + "w_knight.png"), true, 7, 6),
            new Pawn(PieceColor.White, PieceType.Pawn, Image.FromFile(Path + "w_pawn.png"), true, 6, 0),
            new Pawn(PieceColor.White, PieceType.Pawn, Image.FromFile(Path + "w_pawn.png"), true, 6, 1),
            new Pawn(PieceColor.White, PieceType.Pawn, Image.FromFile(Path + "w_pawn.png"), true, 6, 2),
            new Pawn(PieceColor.White, PieceType.Pawn, Image.FromFile(Path + "w_pawn.png"), true, 6, 3),
            new Pawn(PieceColor.White, PieceType.Pawn, Image.FromFile(Path + "w_pawn.png"), true, 6, 4),
            new Pawn(PieceColor.White, PieceType.Pawn, Image.FromFile(Path + "w_pawn.png"), true, 6, 5),
            new Pawn(PieceColor.White, PieceType.Pawn, Image.FromFile(Path + "w_pawn.png"), true, 6, 6),
            new Pawn(PieceColor.White, PieceType.Pawn, Image.FromFile(Path + "w_pawn.png"), true, 6, 7)
        };

    }
}