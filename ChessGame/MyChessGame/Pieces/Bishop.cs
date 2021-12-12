using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChessGame
{
    class Bishop: Piece
    {
        public Bishop(PieceColor color, PieceType type) : base(color, PieceType.Bishop)
        {

        }
        public Bishop(PieceColor color, PieceType type,int X, int Y) : base(color, PieceType.Bishop,X,Y)
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

            if (!(adx == ady))
            {
                return false;
            }

            if (CheckUpRight(dx, dy, i1, i2, board) == false)
            {
                return false;
            }

            if (CheckDownRight(dx, dy, i1, i2, board) == false)
            {
                return false;
            }

            if (CheckUpLeft(dx, dy, i1, i2, board) == false)
            {
                return false;
            }

            if (CheckDownLeft(dx, dy, i1, i2, board) == false)
            {
                return false;
            }

            return true;
        }
    }
}
