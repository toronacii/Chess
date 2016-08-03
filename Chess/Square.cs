using System;
using System.Linq;

namespace Chess
{
    public class Square
    {
        private Array squaresArray;

        public Square(Array squaresArray, int row, int column)
        {
            this.squaresArray = squaresArray;
            this.Row = row;
            this.Column = column;
        }

        public PieceColor? PieceColor { get; set; }
        public IPiece Piece { get; set; }

        public int Row { get; protected set; }
        public int Column { get; protected set; }



        #region Move Logic

        public Square Move(int steps, int rowIncrement, int columnIncrement)
        {
            var row = this.Row;
            var column = this.Column;
            Square lastSquare = null;

            while (steps > 0)
            {
                row += rowIncrement;
                column += columnIncrement;

                if ((row >= 1 && row <= 8) && (column >= 1 && column <= 8))
                {
                    lastSquare = (Square)squaresArray.GetValue(new[] { row, column });

                    steps--;
                }
                else
                {
                    break;
                }
            }

            if (steps == 0)
            {
                return lastSquare;
            }
            else
            {
                return null;
            }
        }


        public Square Forward(int steps = 1)
        {
            return Move(steps, 1, 0);
        }

        public Square Backward(int steps = 1)
        {
            return Move(steps, -1, 0);
        }

        public Square ForwardRightDiagonal(int steps = 1)
        {
            return Move(steps, 1, 1);
        }

        public Square ForwardLeftDiagonal(int steps = 1)
        {
            return Move(steps, 1, -1);
        }

        public Square BackwardRightDiagonal(int steps = 1)
        {
            return Move(steps, -1, 1);
        }

        public Square BackwardLeftDiagonal(int steps = 1)
        {
            return Move(steps, -1, -1);
        }

        public Square Right(int steps = 1)
        {
            return Move(steps, 0, 1);
        }

        public Square Left(int steps = 1)
        {
            return Move(steps, 0, -1);
        }

        #endregion

        #region Helped Methods

        public bool IsDiagonalTo(Square position)
        {
            if (this.Row == position.Row || this.Column == position.Column)
            {
                return false;
            }

            var rowDelta = this.Row > position.Row ? - 1: 1;
            var columnDelta = this.Column > position.Column ? -1 : 1;
            var delta = Math.Abs(this.Row - position.Row);

            return ((Math.Abs(rowDelta) + Math.Abs(columnDelta) == 2)) && this.Move(delta, rowDelta, columnDelta) != null;
        }

        #endregion
        
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