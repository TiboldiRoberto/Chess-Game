using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChessGame
{
    class Pawn : Piece
    {
        private bool moved;
        public Pawn(PieceColor color,PieceType type) : base(color, PieceType.Pawn)
        {
            this.moved = false;
        }

        public Pawn(PieceColor color, PieceType type, int X, int Y) : base(color, PieceType.Pawn, X, Y)
        {
            this.moved = false;
        }

        public override bool IsValidMove(int dx, int dy,int i1, int i2, Board board)
        {
            if (base.IsValidMove(dx, dy, i1, i2, board) == false)
            {
                return false;
            }

            int adx = Math.Abs(dx);
            int ady = Math.Abs(dy);

            if (this.moved == false && dy == -2)
            {
                if (board.GetPieceFromIndex(i2 + 8).Type != PieceType.Empty)
                {
                    moved = true;
                    return false;
                }
                if (adx != 0)
                {
                    moved = true;
                    return false;
                }
            }
            else
            {
                if (dy != -1)
                {
                    moved = true;
                    return false;
                }
                if (board.GetPieceFromIndex(i2).Type != PieceType.Empty)
                {
                    if (adx != 1)
                    {
                        moved = true;
                        return false;
                    }
                }
                else
                {
                    if (adx != 0)
                    {
                        moved = true;
                        return false;
                    }
                }
            }

            moved = true;
            return true;
        }
    }
}
