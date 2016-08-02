using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class SquareCoordinate
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public bool IsValid()
        {
            return !((Row > 8 || Row < 1) || (Column > 8 || Column < 1));
        }

        public SquareCoordinate Move(int steps, int rowIncrement, int columnIncrement)
        {
            SquareCoordinate square = this;

            for(int i = 0; i < steps; i++)
            {
                square = new SquareCoordinate { Row = square.Row + rowIncrement, Column = square.Column + columnIncrement };
            }

            return square;
        }
        public SquareCoordinate Forward(int steps = 1)
        {
            return Move(steps, 1, 0);
        }

        public SquareCoordinate Backward(int steps = 1)
        {
            return Move(steps, -1, 0);
        }

        public SquareCoordinate ForwardRightDiagonal(int steps = 1)
        {
            return Move(steps, 1, 1);
        }

        public SquareCoordinate ForwardLeftDiagonal(int steps = 1)
        {
            return Move(steps, 1, -1);
        }

        public SquareCoordinate BackwardRightDiagonal(int steps = 1)
        {
            return Move(steps, -1, 1);
        }

        public SquareCoordinate BackwardLeftDiagonal(int steps = 1)
        {
            return Move(steps, -1, -1);
        }

        public SquareCoordinate Right(int steps = 1)
        {
            return Move(steps, 0, 1);
        }

        public SquareCoordinate Left(int steps = 1)
        {
            return Move(steps, 0, -1);
        }
    }
}
