using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public abstract partial class Piece : IPiece
    {
        public readonly static IPiece King = new KingPiece();
        public readonly static IPiece Queen = new QueenPiece();
        public readonly static IPiece Bishop = new BishopPiece();
        public readonly static IPiece Knight = new KnightPiece();
        public readonly static IPiece Rook = new RookPiece();
        public readonly static IPiece Pawn = new PawnPiece();

        protected Piece() { }
        
        protected virtual bool IsValidLinearMovement(Square source, Square target)
        {
            var allowedSquares = new List<Square>();
            var rowDelta = target.Row - source.Row;
            var columnDelta = target.Column - source.Column;

            var rowIncrement = ((rowDelta < 0) ? -1 : (rowDelta > 0) ? 1 : 0);
            var columnIncrement = ((columnDelta < 0) ? -1 : (columnDelta > 0) ? 1 : 0);

            var nextPosition = source.Move(1, rowIncrement, columnIncrement);
            while (nextPosition != null && !nextPosition.Equals(target))
            {
                allowedSquares.Add(nextPosition);

                nextPosition = nextPosition.Move(1, rowIncrement, columnIncrement);
            }

            return !allowedSquares.Any(s => s.Piece != null);
        }

        public abstract bool Validate(IMovementContext context);
    }
}
