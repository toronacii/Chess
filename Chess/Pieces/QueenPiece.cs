using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public partial class Piece
    {
        private class QueenPiece: Piece, IPiece
        {
            public override IEnumerable<SquareCoordinate> ComputeControlledSquares(IPieceContext context)
            {
                var position = context.Position;
                var allowedMoves = new List<SquareCoordinate>();

                var tower = new TowerPiece();
                var bishop = new BishopPiece();

                allowedMoves.AddRange(tower.ComputeControlledSquares(context));
                allowedMoves.AddRange(bishop.ComputeControlledSquares(context));

                return allowedMoves;
            }
        }
    }
}
