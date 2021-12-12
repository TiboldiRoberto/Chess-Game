using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChessGame
{
    class Piece
    {
        #region Properties
        private PieceColor color;
        private PieceType type;
        private int X, Y;
        public enum PieceType
        {
            Pawn,
            Rook,
            Knight,
            Bishop,
            Queen,
            King,
            Empty
        }

        public enum PieceColor
        {
            Black,
            White,
            None
        }
        #endregion

        public Piece(PieceColor color, PieceType type)
        {
            this.color = color;
            this.type = type;
        }

        public Piece(PieceColor color, PieceType type, int X, int Y)
        {
            this.color = color;
            this.type = type;
            this.X = X;
            this.Y = Y;
        }

        public PieceType Type
        {
            get { return type; }
        }

        public PieceColor Color
        {
            get { return color; }
        }

        public int GetPositionX()
        {
            return this.X;
        }

        public void SetPositionX(int x)
        {
            this.X = x;
        }
        public void SetPositionY(int y)
        {
            this.Y = y;
        }
        public int GetPositionY()
        {
            return this.Y;
        }

        #region For Dictionary
        protected bool Equals(Piece other)
        {
            return color == other.color && type == other.type;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Piece)obj);
        }

        public override int GetHashCode()  //Se foloseste cand adaugam elemente in dictionar
        {
            unchecked
            {
                return ((int)color * 397) ^ (int)type;
            }
        }

        public static bool operator ==(Piece left, Piece right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Piece left, Piece right)
        {
            return !Equals(left, right);
        }
        #endregion

        #region Movement Validator
        public virtual bool IsValidMove(int dx, int dy,int i1, int i2, Board board)
        {
            return true;
        }

        public bool CheckUp(int dx, int dy, int i1, int i2, Board board)
        {
            if (dy < 0)
            {
                for (int i = i1 - 8; i > i2; i -= 8)
                {
                    if (board.GetPieceFromIndex(i).Type != PieceType.Empty)
                    {
                        return false;
                    }
                }
            }
            return true;

        }

        public bool CheckDown(int dx, int dy, int i1, int i2, Board board)
        {
            if (dy > 0)
            {
                for (int i = i1 + 8; i < i2; i += 8)
                {
                    if (board.GetPieceFromIndex(i).Type != PieceType.Empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckLeft(int dx, int dy, int i1, int i2, Board board)
        {
            if (dx < 0)
            {
                for (int i = i1 - 1; i > i2; i--)
                {
                    if (board.GetPieceFromIndex(i).Type != PieceType.Empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckRight(int dx, int dy, int i1, int i2, Board board)
        {
            if (dx > 0)
            {
                for (int i = i1 + 1; i < i2; i++)
                {
                    if (board.GetPieceFromIndex(i).Type != PieceType.Empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckUpRight(int dx, int dy, int i1, int i2, Board board)
        {
            if (dx > 0 && dy < 0)
            {
                for (int i = i1 - 7; i > i2; i -= 7)
                {
                    if (board.GetPieceFromIndex(i).Type != PieceType.Empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckDownRight(int dx, int dy, int i1, int i2, Board board)
        {
            if (dx > 0 && dy > 0)
            {
                for (int i = i1 + 9; i < i2; i += 9)
                {
                    if (board.GetPieceFromIndex(i).Type != PieceType.Empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckUpLeft(int dx, int dy, int i1, int i2, Board board)
        {
            if (dx < 0 && dy < 0)
            {
                for (int i = i1 - 9; i > i2; i -= 9)
                {
                    if (board.GetPieceFromIndex(i).Type != PieceType.Empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckDownLeft(int dx, int dy, int i1, int i2, Board board)
        {
            if (dx < 0 && dy > 0)
            {
                for (int i = i1 + 7; i < i2; i += 7)
                {
                    if (board.GetPieceFromIndex(i).Type != PieceType.Empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CorrectDiagonal(int adx, int ady)
        {
            if (adx > 0 && ady > 0)
            {
                if (adx != ady)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
