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
            public override bool Validate(IMovementContext context)
            {
                var moveDeltas = new List<Tuple<int, int>>
                {
                    new Tuple<int, int>(2, -1),
                    new Tuple<int, int>(2, 1),
                    new Tuple<int, int>(-2, -1),
                    new Tuple<int, int>(-2, 1),
                    new Tuple<int, int>(1, -2),
                    new Tuple<int, int>(1, 2),
                    new Tuple<int, int>(1, 2),
                    new Tuple<int, int>(1, -2)
                };

                return moveDeltas.Any(d => MatchMove(context.Position, context.Target, d.Item1, d.Item2));
            }

            private bool MatchMove(Square source, Square target, int rowDelta, int columnDelta)
            {
                return ((source.Row + rowDelta) == target.Row) && ((source.Column + columnDelta) == target.Column);
            }
        }
    }
}
