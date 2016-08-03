using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public interface IPiece
    {
        IEnumerable<SquareCoordinate> ComputeControlledSquares(IPieceContext context);
        IEnumerable<SquareCoordinate> GetLinearMovement(SquareCoordinate source, SquareCoordinate target);
    }
}
