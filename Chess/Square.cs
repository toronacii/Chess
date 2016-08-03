namespace Chess
{
    public class Square
    {
        public PieceColor? PieceColor { get; set; }
        public IPiece Piece { get; set; }

        public int Row { get; set; }
        public int Column { get; set; }

        public static implicit operator SquareCoordinate(Square square)  // implicit digit to byte conversion operator
        {
            return new SquareCoordinate(square);
        }

        public override string ToString()
        {
            if(Piece == null)
            {
                return " ";
            }
            else
            {
                if(Piece == Chess.Piece.Pawn)
                {
                     return (PieceColor == Chess.PieceColor.White) 
                        ? char.ConvertFromUtf32((int)WhitePieceChars.Pawn) 
                        : char.ConvertFromUtf32((int)BlackPieceChars.Pawn);
                }

                if (Piece == Chess.Piece.King)
                {
                    return (PieceColor == Chess.PieceColor.White)
                       ? char.ConvertFromUtf32((int)WhitePieceChars.King)
                       : char.ConvertFromUtf32((int)BlackPieceChars.King);
                }

                if (Piece == Chess.Piece.Queen)
                {
                    return (PieceColor == Chess.PieceColor.White)
                       ? char.ConvertFromUtf32((int)WhitePieceChars.Queen)
                       : char.ConvertFromUtf32((int)BlackPieceChars.Queen);
                }

                if (Piece == Chess.Piece.Bishop)
                {
                    return (PieceColor == Chess.PieceColor.White)
                       ? char.ConvertFromUtf32((int)WhitePieceChars.Bishop)
                       : char.ConvertFromUtf32((int)BlackPieceChars.Bishop);
                }

                if (Piece == Chess.Piece.Knight)
                {
                    return (PieceColor == Chess.PieceColor.White)
                       ? char.ConvertFromUtf32((int)WhitePieceChars.Knight)
                       : char.ConvertFromUtf32((int)BlackPieceChars.Knight);
                }

                if (Piece == Chess.Piece.Rook)
                {
                    return (PieceColor == Chess.PieceColor.White)
                       ? char.ConvertFromUtf32((int)WhitePieceChars.Rook)
                       : char.ConvertFromUtf32((int)BlackPieceChars.Rook);
                }

                return string.Empty;
            }
        }

        private enum WhitePieceChars: int
        {
            King = 'K',
            Queen = 'Q',
            Rook = 'R',
            Bishop = 'B',
            Knight = 'K',
            Pawn = 'P',
        }

        private enum BlackPieceChars : int
        {
            King = 'k',
            Queen = 'q',
            Rook = 'r',
            Bishop = 'b',
            Knight = 'n',
            Pawn = 'p',
        }
    }
}