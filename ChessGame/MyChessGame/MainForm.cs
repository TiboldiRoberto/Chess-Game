using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace MyChessGame
{
    public partial class MainForm : Form
    {
        private NetworkStream stream;
        public String version = "5.4";
        public MainForm()
        {
            InitializeComponent();
        }

        private String ReadMessage()
        {
            Byte[] bytes = new Byte[256];
            String data = null;
            Int32 i = stream.Read(bytes, 0, bytes.Length);
            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
            return data;
        }

        private void WriteMessage(String data)
        {
            Byte[] bytes = new Byte[256];
            bytes = System.Text.Encoding.ASCII.GetBytes(data);
            stream.Write(bytes, 0, bytes.Length);
        }

        private void SendDisconnectMessage()
        {
            if (stream.CanRead)
            {
                WriteMessage("Disconnected");
                stream.Close();
            }
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = IpBox.Text;
                Int32 port = Convert.ToInt32(PortBox.Text);
                TcpClient client = new TcpClient(ip, port);

                InfoStatus.Text = "Connecting to host...";

                this.stream = client.GetStream();

                WriteMessage("5.4");

                String data = ReadMessage();

                if (data == "Connected")
                {
                    InfoStatus.Text = "Connected!";
                    this.Hide();
                    ChessBoardUI chessBoard = new ChessBoardUI(stream, "White");
                    chessBoard.ShowDialog();
                }
                else
                {
                    if (data == "Invalid version")
                    {
                        InfoStatus.Text = "Wrong version!";
                    }
                    else
                    {
                        InfoStatus.Text = data;
                    }
                    stream.Close();
                }

                this.Show();

                SendDisconnectMessage();

                client.Close();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("ArgumentNullException: " + ex);
            }
            catch (SocketException ex)
            {
                MessageBox.Show("SocketException" + ex, "Error");
            }
        }

        private void btnHost_Click(object sender, EventArgs e)
        {
            TcpListener server = null;
            try
            {
                Int32 port = Convert.ToInt32(PortBox.Text);

                server = new TcpListener(System.Net.IPAddress.Any, port);
                server.Start();

                InfoStatus.Text = "Waiting for connection...";

                TcpClient client = server.AcceptTcpClient();
                InfoStatus.Text = "Connected!";

                this.stream = client.GetStream();

                String data = ReadMessage();

                if(data == this.version){
                    WriteMessage("Connected");

                    this.Hide();
                    ChessBoardUI chess = new ChessBoardUI(stream, "Black");
                    chess.ShowDialog();

                    SendDisconnectMessage();
                }
                else
                {
                    WriteMessage("Invalid version");
                }

                this.Show();
            }
            catch (SocketException ex)
            {
                MessageBox.Show("SocketException" + ex, "Error");
            }
            finally
            {
                server.Stop();
            }
        }
    }
}
