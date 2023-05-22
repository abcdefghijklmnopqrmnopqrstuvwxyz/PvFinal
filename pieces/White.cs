using System.Drawing;

namespace Chess.pieces
{
    internal class White
    {
        private PieceColor _color;
        private PieceType _type;
        private Image _image;
        private int _pos_x;
        private int _pos_y;

        public PieceColor Color { get => _color; set => _color = value; }
        public PieceType Type { get => _type; set => _type = value; }
        public Image Image { get => _image; set => _image = value; }
        public int Pos_x { get => _pos_x; set => _pos_x = value; }
        public int Pos_y { get => _pos_y; set => _pos_y = value; }

        public White(PieceColor color, PieceType type, Image image, int pos_x, int pos_y)
        {
            Color = color;
            Type = type;
            Image = image;
            Pos_x = pos_x; 
            Pos_y = pos_y;
        }

    }
}