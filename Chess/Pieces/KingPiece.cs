using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public partial class Piece
    {
        private class KingPiece : Piece, IPiece
        {
            public override IEnumerable<SquareCoordinate> ComputeControlledSquares(IPieceContext context)
            {
                var position = context.Position;
                var allowedMoves = new SquaresCollection();

                allowedMoves.Add(position.ForwardLeftDiagonal());
                allowedMoves.Add(position.Forward());
                allowedMoves.Add(position.BackwardRightDiagonal());
                allowedMoves.Add(position.Left());
                allowedMoves.Add(position.Right());
                allowedMoves.Add(position.BackwardLeftDiagonal());
                allowedMoves.Add(position.Backward());
                allowedMoves.Add(position.BackwardRightDiagonal());
                
                return allowedMoves;
            }
        }
    }
}
