using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public partial class Piece
    {
        private class RookPiece: Piece, IPiece
        {
            public override bool Validate(IMovementContext context)
            {
                if(context.Position.Row == context.Target.Row || context.Position.Column == context.Target.Column)
                {
                    return this.IsValidLinearMovement(context.Position, context.Target);
                }

                return false;
            }
            
        }
    }
}
