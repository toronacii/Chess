using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public partial class Piece
    {
        private class TowerPiece: Piece, IPiece
        {
            public override IEnumerable<SquareCoordinate> ComputeControlledSquares(IPieceContext context)
            {
                var position = context.Position;
                var allowedMoves = new SquaresCollection();

                for(var column = 1; column <= 8; column++)
                {
                    if (column < position.Column)
                    {
                        allowedMoves.Add(position.Left(position.Column - column));
                    }
                    else if(column > position.Column)
                    {
                        allowedMoves.Add(position.Right(column - position.Column));
                    }
                }

                for (var row = 1; row <= 8; row++)
                {
                    if (row < position.Row)
                    {
                        allowedMoves.Add(position.Backward(position.Row - row));
                    }
                    else if (row > position.Row)
                    {
                        allowedMoves.Add(position.Forward(row - position.Row));
                    }
                }

                return allowedMoves;
            }
        }
    }
}
