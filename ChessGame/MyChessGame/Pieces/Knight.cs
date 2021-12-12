using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChessGame
{
    class Knight:Piece 
    {
         public Knight(PieceColor color, PieceType type) : base(color, PieceType.Knight)
        {

        }
        public Knight(PieceColor color, PieceType type, int X, int Y) : base(color, PieceType.Knight,X,Y)
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

            if (!((adx == 2 && ady == 1) || (adx == 1 && ady == 2)))
            {
                return false;
            }

            return true;
        }
    }

}
