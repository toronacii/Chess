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
            public override bool Validate(IMovementContext context)
            {
                var direction = context.Color == PieceColor.White ? 1 : -1;
                var sourcePosition = context.Color == PieceColor.White ? 2 : 7;

                //Validation
                if (context.Position.Row == context.Target.Row)
                {
                    return false;
                }

                if ((context.Position.Row == sourcePosition) 
                    && ((context.Position.Row + (direction * 2)) != context.Target.Row)
                    && ((context.Position.Row + direction != context.Target.Row)))
                {
                    return false;
                }

                if ((context.Position.Row != sourcePosition) && (context.Position.Row + direction) != context.Target.Row)
                {
                    return false;
                }

                if((context.Position.Column == context.Target.Column) && context.Target.Piece != null)
                {
                    return false;
                }

                if((context.Position.Column != context.Target.Column) && Math.Abs(context.Position.Column - context.Target.Column) != 1)
                {
                    return false;
                }

                return this.IsValidLinearMovement(context.Position, context.Target);
            }
        }
    }
}
