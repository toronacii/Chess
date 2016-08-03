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
       

        private PieceColor turn;
        private bool allowedShortCastlingForWhitePieces;
        private bool allowedLongCastlingForWhitePieces;
        private bool allowedShortCastlingForBlackPieces;
        private bool allowedLongCastlingForBlackPieces;

        Square[,] squares = new Square[9, 9];

        public Board()
        {
            InitializeSquares();
            DefaultPieces();
        }

        private void InitializeSquares()
        {
            for(var i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    var square = new Square { Row = i, Column = j };

                    squares[i,j] = square;
                }
            }
        }

        private void DefaultPieces()
        {
            for (var i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if(i == 2 || i == 7)
                    {
                        squares[i, j].Piece = Piece.Pawn;
                        squares[i, j].PieceColor = (i == 2) ? PieceColor.White : PieceColor.Black;
                    }
                    else if(i == 1 || i == 8)
                    {
                        if(j == 1 || j == 8)
                        {
                            squares[i, j].Piece = Piece.Rook;
                        }
                        else if(j == 2 || j == 7)
                        {
                            squares[i, j].Piece = Piece.Knight;
                        }
                        else if(j == 3 || j == 6)
                        {
                            squares[i, j].Piece = Piece.Bishop;
                        }
                        else if(j == 4)
                        {
                            squares[i, j].Piece = Piece.Queen;
                        }
                        else if (j == 5)
                        {
                            squares[i, j].Piece = Piece.King;
                        }

                        squares[i, j].PieceColor = (i == 1) ? PieceColor.White : PieceColor.Black;
                    }
                }
            }
        }

        public void DoMove(string move)
        {
            var moveTranslated = ParseMove(move);
            var sourceSquare = squares[moveTranslated.Item1.Row, moveTranslated.Item1.Column];
            var targetSquare = squares[moveTranslated.Item2.Row, moveTranslated.Item2.Column];

            if(sourceSquare.Piece == null || sourceSquare.PieceColor.Value != turn)
            {
                throw new InvalidOperationException("Invalid move, no source piece");
            }

            if (sourceSquare.PieceColor == targetSquare.PieceColor)
            {
                throw new InvalidOperationException("Invalid move, same color target piece");
            }

            SquareCoordinate sourceCoordinate = sourceSquare;
            var computedSquares = sourceSquare.Piece.ComputeControlledSquares(new PieceContext
            {
                Position = turn == PieceColor.White ? sourceCoordinate : !sourceCoordinate,
                Color = turn,
                Moved = false
            });

            if(turn == PieceColor.Black)
            {
                computedSquares = computedSquares.Select(sq => !sq);
            }

            if (!computedSquares.Contains(targetSquare))
            {
                throw new InvalidOperationException("Invalid move for selected piece");
            }
            

            if (sourceSquare.Piece != Piece.Knight)
            {
                var linearMovementSquares = sourceSquare.Piece.GetLinearMovement(sourceSquare, targetSquare);
                foreach (var square in linearMovementSquares)
                {
                    if(squares[square.Row, square.Column].Piece != null)
                    {
                        throw new InvalidOperationException("Invalid move, rule violation");
                    }
                }
            }

            

            var targetSquarePreviousPiece = targetSquare.Piece;
            var targetSquarePreviousPieceColor = targetSquare.PieceColor;

            targetSquare.Piece = sourceSquare.Piece;
            targetSquare.PieceColor = sourceSquare.PieceColor;
            sourceSquare.Piece = null;
            sourceSquare.PieceColor = null;

            turn = (turn == PieceColor.White) ? PieceColor.Black : PieceColor.White;

            


            //TODO Extravalidations


            //TODO Handle move translation


        }

        public Tuple<SquareCoordinate, SquareCoordinate> ParseMove(string move)
        {
            var matches = Regex.Match(move, "([A-H][1-8])-([A-H][1-8])", RegexOptions.IgnoreCase);
            if (!matches.Success)
            {
                throw new InvalidOperationException("Invalid move");
            }

            return new Tuple<SquareCoordinate, SquareCoordinate>(SquareCoordinate.Parse(matches.Groups[1].Value), SquareCoordinate.Parse(matches.Groups[2].Value));
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
                    sb.AppendFormat(" {0} |", squares[i, j]);
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
    }
}