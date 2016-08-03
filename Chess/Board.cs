using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chess
{
    public class Board
    {
        public enum Columns: int { A = 1, B, C, D, E, F, G, H }
        private Array squaresArray = Array.CreateInstance(typeof(Square), new int[] { 8, 8 }, new int[] { 1, 1 });

        private PieceColor turn;
        private bool allowedShortCastlingForWhitePieces;
        private bool allowedLongCastlingForWhitePieces;
        private bool allowedShortCastlingForBlackPieces;
        private bool allowedLongCastlingForBlackPieces;

        public Board()
        {
            InitializeSquares();
            DefaultPieces();
        }

        public void DoMove(string move)
        {
            var moveTranslated = ParseMove(move);

            var sourceSquare = moveTranslated.Item1;
            var targetSquare =  moveTranslated.Item2;

            if(sourceSquare.Piece == null || sourceSquare.PieceColor.Value != turn)
            {
                throw new InvalidOperationException("Invalid move, no source piece");
            }

            if (sourceSquare.PieceColor == targetSquare.PieceColor)
            {
                throw new InvalidOperationException("Invalid move, same color target piece");
            }
            
            var movementContext = new MovementContext
            {
                Color = this.turn,
                Moved = false,
                Position = sourceSquare,
                Target = targetSquare
            };

            if (!sourceSquare.Piece.Validate(movementContext))
            {
                throw new InvalidOperationException("Invalid move");
            }
            

            var targetSquarePreviousPiece = targetSquare.Piece;
            var targetSquarePreviousPieceColor = targetSquare.PieceColor;

            targetSquare.Piece = sourceSquare.Piece;
            targetSquare.PieceColor = sourceSquare.PieceColor;
            sourceSquare.Piece = null;
            sourceSquare.PieceColor = null;

            turn = (turn == PieceColor.White) ? PieceColor.Black : PieceColor.White;
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("   ---------------------------------");
            for (var i = 8; i >= 1; i--)
            {
                sb.AppendFormat(" {0} |", i);
                for (int j = 1; j <= 8; j++)
                {
                    sb.AppendFormat(" {0} |", (Square)squaresArray.GetValue(new[] { i, j }));
                }
                
                sb.AppendLine("\n   ---------------------------------");
            }

            sb.Append("    ");
            for (int j = 1; j <= 8; j++)
            {
                sb.AppendFormat(" {0}  ", (Columns)j);
            }

            sb.AppendFormat("\n\nTurn: {0}", this.turn.ToString());

            return sb.ToString();
        }

        #region Private 

        private void InitializeSquares()
        {
            for (var i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    var square = new Square(squaresArray, i, j);
                    squaresArray.SetValue(square, new[] { i, j });
                }
            }
        }

        private void DefaultPieces()
        {
            for (var i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    var square = (Square)squaresArray.GetValue(new[] { i, j });

                    if (i == 2 || i == 7)
                    {
                        square.Piece = Piece.Pawn;
                        square.PieceColor = (i == 2) ? PieceColor.White : PieceColor.Black;
                    }
                    else if (i == 1 || i == 8)
                    {
                        if (j == 1 || j == 8)
                        {
                            square.Piece = Piece.Rook;
                        }
                        else if (j == 2 || j == 7)
                        {
                            square.Piece = Piece.Knight;
                        }
                        else if (j == 3 || j == 6)
                        {
                            square.Piece = Piece.Bishop;
                        }
                        else if (j == 4)
                        {
                            square.Piece = Piece.Queen;
                        }
                        else if (j == 5)
                        {
                            square.Piece = Piece.King;
                        }

                        square.PieceColor = (i == 1) ? PieceColor.White : PieceColor.Black;
                    }
                }
            }
        }

        private Tuple<Square, Square> ParseMove(string move)
        {
            var matches = Regex.Match(move, "([A-H][1-8])-([A-H][1-8])", RegexOptions.IgnoreCase);
            if (!matches.Success)
            {
                throw new InvalidOperationException("Invalid move");
            }



            return new Tuple<Square, Square>(this.GetSquareFromString(matches.Groups[1].Value), this.GetSquareFromString(matches.Groups[2].Value));
        }

        private Square GetSquareFromString(string value)
        {
            var column = (int)Enum.Parse(typeof(Board.Columns), value.First().ToString().ToUpper());
            var row = Convert.ToInt32(value.Last().ToString());

            return (Square)squaresArray.GetValue(new[] { row, column });
        }
    
        #endregion
    }
}