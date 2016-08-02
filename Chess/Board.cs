using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Board
    {
        private PieceKind turn;
        private bool allowedShortCastlingForWhitePieces;
        private bool allowedLongCastlingForWhitePieces;
        private bool allowedShortCastlingForBlackPieces;
        private bool allowedLongCastlingForBlackPieces;

        private List<Square> squares;

        public Board()
        {
            InitializeSquares();
        }

        private void InitializeSquares()
        {
            Enumerable.Range(0, 64).ToList().ForEach(e => this.squares.Add(new Square()));
        }

        public void DoMove(string move)
        {
            //TODO Handle move translation


        }
    }
}