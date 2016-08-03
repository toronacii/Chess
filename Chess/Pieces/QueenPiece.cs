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
            public override bool Validate(IMovementContext context)
            {
                var tower = new RookPiece();
                var bishop = new BishopPiece();

                return tower.Validate(context) && bishop.Validate(context);
            }
        }
    }
}
