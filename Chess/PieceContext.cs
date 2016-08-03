using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class PieceContext : IPieceContext
    {
        public PieceColor Color { get; set; }

        public bool Moved { get; set; }

        public SquareCoordinate Position { get; set; }
    }
}
