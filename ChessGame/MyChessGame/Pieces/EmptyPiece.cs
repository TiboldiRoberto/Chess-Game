using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChessGame
{
    class EmptyPiece:Piece
    {
        public EmptyPiece(PieceColor color, PieceType type) : base(PieceColor.None, PieceType.Empty)
        {
 
        }
        public EmptyPiece(PieceColor color, PieceType type, int X, int Y) : base(PieceColor.None, PieceType.Empty, X, Y)
        {

        }
        


        public override bool IsValidMove(int dx, int dy, int i1, int i2, Board board)
        {
            return false;
        }
    }
}
