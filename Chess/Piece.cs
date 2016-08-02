using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public abstract partial class Piece : IPiece
    {
        public readonly static IPiece King = new KingPiece();
        public readonly static IPiece Queen = new QueenPiece();
        public readonly static IPiece Bishop = new BishopPiece();
        public readonly static IPiece Knight = new KnightPiece();
        public readonly static IPiece Tower = new TowerPiece();
        public readonly static IPiece Pawn = new PawnPiece();

        protected Piece() { }

        public abstract IEnumerable<SquareCoordinate> ComputeControlledSquares(IPieceContext context);
    }
}
