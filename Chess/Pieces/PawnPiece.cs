using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public partial class Piece
    {
        private class PawnPiece : Piece, IPiece
        {
            public override IEnumerable<SquareCoordinate> ComputeControlledSquares(IPieceContext context)
            {
                var position = context.Position;
                var isOriginalPosition = position.Row == 2;
                var allowedMoves = new SquaresCollection();

                allowedMoves.Add(position.Forward());
                allowedMoves.Add(position.ForwardLeftDiagonal());
                allowedMoves.Add(position.ForwardRightDiagonal());

                if (isOriginalPosition)
                {
                    allowedMoves.Add(position.Forward(2));
                }

                return allowedMoves;
            }
        }
    }
}
