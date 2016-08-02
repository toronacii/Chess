using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public partial class Piece
    {
        private class BishopPiece: Piece, IPiece
        {
            public override IEnumerable<SquareCoordinate> ComputeControlledSquares(IPieceContext context)
            {
                var position = context.Position;
                var allowedMoves = new List<SquareCoordinate>();

                allowedMoves.AddRange(GetDiagonalSquares(position, 1, 1));
                allowedMoves.AddRange(GetDiagonalSquares(position, 1, -1));
                allowedMoves.AddRange(GetDiagonalSquares(position, -1, 1));
                allowedMoves.AddRange(GetDiagonalSquares(position, -1, -1));

                return allowedMoves;
            }

            public IEnumerable<SquareCoordinate> GetDiagonalSquares(SquareCoordinate position, int rowIncrement, int columnIncrement)
            {
                var allowedSquares = new List<SquareCoordinate>();
                var nextPosition = position.Move(1, rowIncrement, columnIncrement);
                while(nextPosition.IsValid())
                {
                    allowedSquares.Add(nextPosition);

                    nextPosition = nextPosition.Move(1, rowIncrement, columnIncrement);
                }

                return allowedSquares;
            }
        }
    }
}
