using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class MovementContext : IMovementContext
    {
        public PieceColor Color { get; set; }

        public Square Target { get; set; }

        public bool Moved { get; set; }

        public Square Position { get; set; }
    }
}
