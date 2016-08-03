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

        public SquareCoordinate() { }
        public SquareCoordinate(int row, int column): this()
        {
            this.Row = row;
            this.Column = column;
        }

        public SquareCoordinate(Square sourceSquare): this(sourceSquare.Row, sourceSquare.Column) { }

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

        public SquareCoordinate Inverse()
        {
            return new SquareCoordinate(8 - Row + 1, 8 - Column + 1);
        }

        public static SquareCoordinate Parse(string value)
        {
            var squareCoordinate = new SquareCoordinate();
            squareCoordinate.Column = (int) Enum.Parse(typeof(Board.Columns), value.First().ToString().ToUpper());
            squareCoordinate.Row = Convert.ToInt32(value.Last().ToString());

            return squareCoordinate;
        }

        public override bool Equals(object obj)
        {
            var _obj = obj as SquareCoordinate;
            if(_obj == null)
            {
                return false;
            }

            return _obj.Row == this.Row && _obj.Column == this.Column;
        }

        public override int GetHashCode()
        {
            return string.Format("{0}{1}", ((Board.Columns)Column), Row).GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", ((Board.Columns)Column), Row);
        }

        public static SquareCoordinate operator !(SquareCoordinate c1)
        {
            return c1.Inverse();
        }
    }
}
