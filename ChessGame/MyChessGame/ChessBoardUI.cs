using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;

namespace MyChessGame
{
    public partial class ChessBoardUI : Form
    {

        private NetworkStream stream;
        private Board CurrentGame { get; set; }
        private Piece CurrentPiece { get; set; }
        private Dictionary<Piece, Bitmap> PieceBitmaps { get; set; }
        private int SquareWidth { get; set; }
        private int SquareHeight { get; set; }

        private bool selected = false;

        private bool update = false;

        private System.Windows.Forms.Timer tmr;

        public ChessBoardUI(NetworkStream stream, String color)
        {
            InitializeComponent();
            this.stream = stream;
            CurrentGame = new Board(color);
            CurrentPiece = new EmptyPiece(Piece.PieceColor.None, Piece.PieceType.Empty);
            if (color == "Black")
            {
                this.Text = "Chess - Host";
                this.InfoBox.Text = "Your opponent goes first";
            }
            else
            {
                this.Text = "Chess - Client";
                this.InfoBox.Text = "It's your turn first";
            }
            if(!CurrentGame.IsTurn())
            {
                WaitForResponse();
            }
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            if(CurrentGame.IsGameOver())
            {
                tmr = new System.Windows.Forms.Timer();
                tmr.Tick += delegate {
                    this.Close();
                };
                tmr.Interval = (int)TimeSpan.FromSeconds(5).TotalMilliseconds;
                tmr.Start();
            }
        }

        private void ChessBoard_Load(object sender, EventArgs e)
        {
            InitializeGame();
            DrawGame();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Point location = e.Location;
            int x = location.X / SquareWidth;
            int y = location.Y / SquareHeight;

            if (CurrentGame.IsGameOver() == false)
            {
                if (CurrentGame.IsTurn() == true) 
                {
                    if (CurrentPiece.Type == Piece.PieceType.Empty)
                    {
                        SelectPiece(x,y);
                        DrawGame();
                    }
                    else
                    {
                        MovePiece(x,y);
                        DrawGame();
                        CheckStatus();
                    }
                    if (CurrentGame.IsTurn() == false)
                    {
                        WriteMessage("Moved," + CurrentGame.GetRecentMove());

                        if (CurrentGame.IsGameOver() == false)
                        {
                            WaitForResponse();
                        }
                        else
                        {
                            stream.Close();
                        }
                    }
                }
            }
        }

        private void InitializeGame()
        {
            SquareWidth = 64;
            SquareHeight = 64;

            PieceBitmaps = new Dictionary<Piece, Bitmap>();
            PieceBitmaps.Add(new Pawn(Piece.PieceColor.Black, Piece.PieceType.Pawn), new Bitmap(Properties.Resources.Pawnb));
            PieceBitmaps.Add(new Pawn(Piece.PieceColor.White, Piece.PieceType.Pawn), new Bitmap(Properties.Resources.Pawnw));
            PieceBitmaps.Add(new Rook(Piece.PieceColor.Black, Piece.PieceType.Rook), new Bitmap(Properties.Resources.Rookb));
            PieceBitmaps.Add(new Knight(Piece.PieceColor.Black, Piece.PieceType.Knight), new Bitmap(Properties.Resources.Knightb));
            PieceBitmaps.Add(new Bishop(Piece.PieceColor.Black, Piece.PieceType.Bishop), new Bitmap(Properties.Resources.Bishopb));
            PieceBitmaps.Add(new Queen(Piece.PieceColor.Black, Piece.PieceType.Queen), new Bitmap(Properties.Resources.Queenb));
            PieceBitmaps.Add(new King(Piece.PieceColor.Black, Piece.PieceType.King), new Bitmap(Properties.Resources.Kingb));
            PieceBitmaps.Add(new Rook(Piece.PieceColor.White, Piece.PieceType.Rook), new Bitmap(Properties.Resources.Rookw));
            PieceBitmaps.Add(new Knight(Piece.PieceColor.White, Piece.PieceType.Knight), new Bitmap(Properties.Resources.Knightw));
            PieceBitmaps.Add(new Bishop(Piece.PieceColor.White, Piece.PieceType.Bishop), new Bitmap(Properties.Resources.Bishopw));
            PieceBitmaps.Add(new Queen(Piece.PieceColor.White, Piece.PieceType.Queen), new Bitmap(Properties.Resources.Queenw));
            PieceBitmaps.Add(new King(Piece.PieceColor.White, Piece.PieceType.King), new Bitmap(Properties.Resources.Kingw));
        }

        private void DrawGame()
        {
            var squareSize = new Size(SquareWidth, SquareHeight);
            Bitmap bitmap = CreateBoard(squareSize);
            DrawPieces(bitmap);
            pictureBox1.Image = bitmap;
        }

        private Bitmap CreateBoard(Size squareSize)
        {
            int squareWidth = squareSize.Width;
            int squareHeight = squareSize.Height;
            var bitmap = new Bitmap(squareWidth * 8, squareHeight * 8);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Brush brush;
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        if((x % 2 == 0 && y % 2 == 0) || (x % 2 != 0 && y % 2 != 0))
                                { brush = Brushes.White; }
                        else    { brush = Brushes.Gray; }
                        if(selected && x==CurrentPiece.GetPositionX() && y==CurrentPiece.GetPositionY()) { brush = Brushes.Red; }
                        graphics.FillRectangle(brush, new Rectangle(x * squareWidth, y * squareHeight, squareWidth, squareHeight)); // coordinatele x,y si dimensiunile
                    }
                }
            }
            return bitmap;
        }

        private void DrawPieces(Bitmap bitmap)
        {
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Board board = CurrentGame;
                
                for (int x = 0; x <8; x++)
                {
                    for (int y = 0; y <8; y++)
                    {
                        int i = y * 8 + x;
                        Piece piece = board.GetPieceFromIndex(i);
                        if (piece.Type != Piece.PieceType.Empty)
                        {
                            Bitmap bitmap1 = PieceBitmaps[piece];

                            graphics.DrawImageUnscaled(bitmap1, new Point((x * SquareWidth + 2), (y * SquareHeight + 2)) );
                        }
                    }
                }
            }
        }

        private void SelectPiece(int x, int y)
        {
            Piece piece = CurrentGame.GetPiece(x, y);
            if (piece.Type != Piece.PieceType.Empty)
            {
                InfoBox.Text = string.Format("You picked a {0} {1} at location {2},{3}", piece.Color, piece.Type, x, y);
                selected = true;
                CurrentPiece = piece;
            } 
            else
            {
                InfoBox.Text = "Nothing there !";
            }
            
        }

        private void MovePiece(int x2, int y2)
        {  
            int x1 = CurrentPiece.GetPositionX();
            int y1 = CurrentPiece.GetPositionY();
            int i1 = CurrentGame.GetIndex(x1, y1);
            int i2 = CurrentGame.GetIndex(x2, y2);

            int dx = x2 - x1;
            int dy = y2 - y1;

            //Piece piece1 = CurrentGame.GetPiece(x1, x2);
            Piece piece2 = CurrentGame.GetPiece(x2, y2);

            //if (piece2.Type != Piece.PieceType.Empty)
            //{
            //    SelectPiece(x2, y2);             //Astfel putem selecta mai multe piese inainte sa mutam
            //    return;                         //ne permite sa iesim din secventa if else si din funcite
            //}
            //else 
            if (update == false && CurrentPiece.IsValidMove(dx,dy,i1,i2,CurrentGame))
            {      
                CurrentGame.SetPiece(x1,y1, new EmptyPiece(Piece.PieceColor.None, Piece.PieceType.Empty,x1,y1));  
                CurrentGame.SetPiece(x2, y2, CurrentPiece);
                CurrentPiece.SetPositionX(x2);
                CurrentPiece.SetPositionY(y2);
                selected = false;
                InfoBox.Text = string.Format("You dropped a {0} {1} at location {2},{3}", CurrentPiece.Color, CurrentPiece.Type, x2, y2);

                CurrentPiece = new EmptyPiece(Piece.PieceColor.None, Piece.PieceType.Empty);
                CurrentGame.SetRecentMove(i1 + "," + i2);
                CurrentGame.turn = false;
            }
            else if(update)
            {
                CurrentGame.SetPiece(x1, y1, new EmptyPiece(Piece.PieceColor.None, Piece.PieceType.Empty, x1, y1));
                CurrentGame.SetPiece(x2, y2, CurrentPiece);
                CurrentPiece.SetPositionX(x2);
                CurrentPiece.SetPositionY(y2);
                selected = false;
                update = false;
                InfoBox.Text = string.Format("Your opponent dropped a {0} {1} at location {2},{3}", CurrentPiece.Color, CurrentPiece.Type, x2, y2);
            }
            else
            {
                InfoBox.Text = "Invalid move!";
            }
        }

        public void CheckStatus()
        {
            Board board = CurrentGame;
            bool bKing = false;
            bool wKing = false;
            for(int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    CurrentPiece = board.GetPiece(x, y);
                        if (CurrentPiece.Type == Piece.PieceType.King)
                        {
                            if (CurrentPiece.Color == Piece.PieceColor.Black)
                            {
                                bKing = true;
                            }
                            if (CurrentPiece.Color == Piece.PieceColor.White)
                            {
                                wKing = true;
                            }
                        }
                }
            }

            if(bKing== false)
            {
                InfoBox.Text = "Client Win Host Lose";
                CurrentGame.EndGame();
                CloseForm();
            }
            if(wKing == false)
            {
                InfoBox.Text = "Host Win Client Lose";
                CurrentGame.EndGame();
                CloseForm();
            }
        }

        private void CloseForm()
        {
            tmr = new System.Windows.Forms.Timer();
            tmr.Tick += delegate {
                this.Close();
            };
            tmr.Interval = (int)TimeSpan.FromSeconds(5).TotalMilliseconds;
            tmr.Start();
        }

        public void  UpdateGame(String data)
        {
            String[] dataString = data.Split(',');

            if (dataString[0] == "Moved")
            {
                int l = 63;
                Piece p1 = CurrentGame.GetPieceFromIndex(63 - Convert.ToInt32(dataString[1]));
                //Piece p2 = CurrentGame.GetPieceFromIndex(63 - Convert.ToInt32(dataString[2]));
                
                int x1 = p1.GetPositionX();
                int y1 = p1.GetPositionY();
                int x2 = (l - Convert.ToInt32(dataString[2])) % 8;
                int y2 = (l - Convert.ToInt32(dataString[2])) / 8;

                CurrentPiece = p1;
                update = true;

                SelectPiece(x1, y1);
                MovePiece(x2,y2);
                DrawGame();
                CheckStatus();

                CurrentPiece = new EmptyPiece(Piece.PieceColor.None, Piece.PieceType.Empty); 

                CurrentGame.ChangeTurn();

            }
        }

        private async void WaitForResponse()
        {
            try
            {
                Byte[] bytes = new Byte[256];
                String data = null;
                Int32 i = await stream.ReadAsync(bytes, 0, bytes.Length);
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                UpdateGame(data);
            }
            catch (ObjectDisposedException ex)
            {
                InfoBox.Text = "Opponent disconnected. You won!";
                CurrentGame.EndGame();
                stream.Close();
            }
        }

        private void WriteMessage(String data)
        {
            Byte[] bytes = new Byte[256];
            bytes = System.Text.Encoding.ASCII.GetBytes(data);
            stream.Write(bytes, 0, bytes.Length);
        }

      
    }
}
