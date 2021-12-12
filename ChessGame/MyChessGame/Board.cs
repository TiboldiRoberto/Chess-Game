using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChessGame
{
    class Board
    {
        private Piece[] pieces;
        private String color;
        private String recentMove;
        private bool gameOver;
        public bool turn;

        public Board(String color)
        {
            this.color = color;
            gameOver = false;
            pieces = new Piece[8 * 8];
            CreatePieces();
            if (color == "Black")
            {
                this.turn = false;
            }
            else
            {
                this.turn = true;
            }
        }
        public int GetIndex(int x, int y)
        {
            int i = y * 8 + x;
            return i;
        }

        public Piece GetPieceFromIndex(int index)
        {
            return pieces[index];
        }
        public Piece GetPiece(int x, int y)
        {
            int i = y * 8 + x;
            return pieces[i];
        }

        public void SetPiece(int x, int y, Piece piece)
        {
            int i = y * 8 + x;
            pieces[i] = piece;
        }

        #region CreatePieces
        private void CreatePieces()
        {
            if (color == "White")
            {
                for (int i = 0; i < 8; i++)
                {
                    SetPiece(i, 1, new Pawn(Piece.PieceColor.Black,Piece.PieceType.Pawn , i, 1));
                    SetPiece(i, 6, new Pawn(Piece.PieceColor.White, Piece.PieceType.Pawn, i, 6));

                    SetPiece(i, 2, new EmptyPiece(Piece.PieceColor.None, Piece.PieceType.Empty, i, 2));
                    SetPiece(i, 3, new EmptyPiece(Piece.PieceColor.None, Piece.PieceType.Empty, i, 3));
                    SetPiece(i, 4, new EmptyPiece(Piece.PieceColor.None, Piece.PieceType.Empty, i, 4));
                    SetPiece(i, 5, new EmptyPiece(Piece.PieceColor.None, Piece.PieceType.Empty, i, 5));

                    if (i == 0 || i == 7)
                    {
                        SetPiece(i, 0, new Rook(Piece.PieceColor.Black, Piece.PieceType.Rook, i, 0));
                        SetPiece(i, 7, new Rook(Piece.PieceColor.White, Piece.PieceType.Rook, i, 7));
                    }
                    if (i == 1 || i == 6)
                    {
                        SetPiece(i, 0, new Knight(Piece.PieceColor.Black, Piece.PieceType.Knight, i, 0));
                        SetPiece(i, 7, new Knight(Piece.PieceColor.White, Piece.PieceType.Knight, i, 7));
                    }
                    if (i == 2 || i == 5)
                    {
                        SetPiece(i, 0, new Bishop(Piece.PieceColor.Black, Piece.PieceType.Bishop, i, 0));
                        SetPiece(i, 7, new Bishop(Piece.PieceColor.White, Piece.PieceType.Bishop, i, 7));
                    }
                    if (i == 3)
                    {
                        SetPiece(i, 0, new Queen(Piece.PieceColor.Black, Piece.PieceType.Queen, i, 0));
                        SetPiece(i, 7, new Queen(Piece.PieceColor.White, Piece.PieceType.Queen, i, 7));
                    }
                    if (i == 4)
                    {
                        SetPiece(i, 0, new King(Piece.PieceColor.Black, Piece.PieceType.King, i, 0));
                        SetPiece(i, 7, new King(Piece.PieceColor.White, Piece.PieceType.King, i, 7));
                    }
                }
            }

            else if (color == "Black")
            {
                for (int i = 0; i < 8; i++)
                {
                    SetPiece(i, 1, new Pawn(Piece.PieceColor.White, Piece.PieceType.Pawn, i, 1));
                    SetPiece(i, 6, new Pawn(Piece.PieceColor.Black, Piece.PieceType.Pawn, i, 6));

                    SetPiece(i, 2, new EmptyPiece(Piece.PieceColor.None, Piece.PieceType.Empty, i, 2));
                    SetPiece(i, 3, new EmptyPiece(Piece.PieceColor.None, Piece.PieceType.Empty, i, 3));
                    SetPiece(i, 4, new EmptyPiece(Piece.PieceColor.None, Piece.PieceType.Empty, i, 4));
                    SetPiece(i, 5, new EmptyPiece(Piece.PieceColor.None, Piece.PieceType.Empty, i, 5));

                    if (i == 0 || i == 7)
                    {
                        SetPiece(i, 0, new Rook(Piece.PieceColor.White, Piece.PieceType.Rook, i, 0));
                        SetPiece(i, 7, new Rook(Piece.PieceColor.Black, Piece.PieceType.Rook, i, 7));
                    }
                    if (i == 1 || i == 6)
                    {
                        SetPiece(i, 0, new Knight(Piece.PieceColor.White, Piece.PieceType.Knight, i, 0));
                        SetPiece(i, 7, new Knight(Piece.PieceColor.Black, Piece.PieceType.Knight, i, 7));
                    }
                    if (i == 2 || i == 5)
                    {
                        SetPiece(i, 0, new Bishop(Piece.PieceColor.White, Piece.PieceType.Bishop, i, 0));
                        SetPiece(i, 7, new Bishop(Piece.PieceColor.Black, Piece.PieceType.Bishop, i, 7));
                    }
                    if (i == 4)
                    {
                        SetPiece(i, 0, new Queen(Piece.PieceColor.White, Piece.PieceType.Queen, i, 0));
                        SetPiece(i, 7, new Queen(Piece.PieceColor.Black, Piece.PieceType.Queen, i, 7));
                    }
                    if (i == 3)
                    {
                        SetPiece(i, 0, new King(Piece.PieceColor.White, Piece.PieceType.King, i, 0));
                        SetPiece(i, 7, new King(Piece.PieceColor.Black, Piece.PieceType.King, i, 7));
                    }
                }

            }
    }
        #endregion

        public String GetColor()
        {
            return this.color;
        }
        public String GetRecentMove()
        {
            return this.recentMove;
        }
        public void SetRecentMove(String data)
        {
            recentMove = data;
        }
        public bool IsGameOver()
        {
            return this.gameOver;
        }

        public bool IsTurn()
        {
            return this.turn;
        }
        public void ChangeTurn()
        {
            this.turn = !this.turn;
        }
        public void EndGame()
        {
            this.gameOver = true;
        }
    }

}
