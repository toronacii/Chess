using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public partial class Piece
    {
        private class KnightPiece : Piece, IPiece
        {
            public override IEnumerable<SquareCoordinate> ComputeControlledSquares(IPieceContext context)
            {
                var position = context.Position;
                var allowedSquares = new SquaresCollection();

                allowedSquares.Add(position.Move(1, 3, -1));
                allowedSquares.Add(position.Move(1, 3, 1));
                allowedSquares.Add(position.Move(1, -3, -1));
                allowedSquares.Add(position.Move(1, -3, 1));
                allowedSquares.Add(position.Move(1, 1, -3));
                allowedSquares.Add(position.Move(1, 1, 3));
                allowedSquares.Add(position.Move(1, -1, -3));
                allowedSquares.Add(position.Move(1, -1, 3));

                return allowedSquares;

            }
        }
    }
}
