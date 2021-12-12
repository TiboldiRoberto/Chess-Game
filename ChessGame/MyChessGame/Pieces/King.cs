using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChessGame
{
    class King:Piece
    {
        public King(PieceColor color, PieceType type) : base(color, PieceType.King)
        {

        }
        public King(PieceColor color, PieceType type,int X,int Y) : base(color, PieceType.King,X,Y)
        {

        }

        public override bool IsValidMove(int dx, int dy, int i1, int i2, Board board)
        {
            if (base.IsValidMove(dx, dy, i1, i2, board) == false)
            {
                return false;
            }

            int adx = Math.Abs(dx);
            int ady = Math.Abs(dy);

            if (adx > 1 || ady > 1)
            {
                return false;
            }

            if (CorrectDiagonal(adx, ady) == false)
            {
                return false;
            }

            return true;
        }
    }
}
