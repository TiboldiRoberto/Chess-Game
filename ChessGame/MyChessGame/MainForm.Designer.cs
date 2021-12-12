
namespace MyChessGame
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnHost = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.PortBox = new System.Windows.Forms.TextBox();
            this.IpBox = new System.Windows.Forms.TextBox();
            this.infoIP = new System.Windows.Forms.Label();
            this.infoPort = new System.Windows.Forms.Label();
            this.titleGame = new System.Windows.Forms.Label();
            this.InfoStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(141, 323);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(113, 40);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnHost
            // 
            this.btnHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHost.Location = new System.Drawing.Point(310, 323);
            this.btnHost.Name = "btnHost";
            this.btnHost.Size = new System.Drawing.Size(113, 40);
            this.btnHost.TabIndex = 1;
            this.btnHost.Text = "Host";
            this.btnHost.UseVisualStyleBackColor = true;
            this.btnHost.Click += new System.EventHandler(this.btnHost_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Location = new System.Drawing.Point(478, 323);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(113, 40);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // PortBox
            // 
            this.PortBox.Location = new System.Drawing.Point(254, 247);
            this.PortBox.Name = "PortBox";
            this.PortBox.ReadOnly = true;
            this.PortBox.Size = new System.Drawing.Size(228, 20);
            this.PortBox.TabIndex = 4;
            this.PortBox.Text = "3000";
            // 
            // IpBox
            // 
            this.IpBox.Location = new System.Drawing.Point(254, 193);
            this.IpBox.Name = "IpBox";
            this.IpBox.Size = new System.Drawing.Size(228, 20);
            this.IpBox.TabIndex = 5;
            // 
            // infoIP
            // 
            this.infoIP.AutoSize = true;
            this.infoIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoIP.Location = new System.Drawing.Point(191, 188);
            this.infoIP.Name = "infoIP";
            this.infoIP.Size = new System.Drawing.Size(34, 24);
            this.infoIP.TabIndex = 6;
            this.infoIP.Text = "IP:";
            // 
            // infoPort
            // 
            this.infoPort.AutoSize = true;
            this.infoPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoPort.Location = new System.Drawing.Point(172, 243);
            this.infoPort.Name = "infoPort";
            this.infoPort.Size = new System.Drawing.Size(53, 24);
            this.infoPort.TabIndex = 7;
            this.infoPort.Text = "Port:";
            // 
            // titleGame
            // 
            this.titleGame.AutoSize = true;
            this.titleGame.Font = new System.Drawing.Font("Ethnocentric Rg", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.titleGame.Location = new System.Drawing.Point(188, 94);
            this.titleGame.Name = "titleGame";
            this.titleGame.Size = new System.Drawing.Size(352, 42);
            this.titleGame.TabIndex = 8;
            this.titleGame.Text = "Chess Game";
            // 
            // InfoStatus
            // 
            this.InfoStatus.AutoSize = true;
            this.InfoStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoStatus.Location = new System.Drawing.Point(305, 402);
            this.InfoStatus.Name = "InfoStatus";
            this.InfoStatus.Size = new System.Drawing.Size(0, 29);
            this.InfoStatus.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 497);
            this.Controls.Add(this.InfoStatus);
            this.Controls.Add(this.titleGame);
            this.Controls.Add(this.infoPort);
            this.Controls.Add(this.infoIP);
            this.Controls.Add(this.IpBox);
            this.Controls.Add(this.PortBox);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnHost);
            this.Controls.Add(this.btnPlay);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnHost;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.TextBox PortBox;
        private System.Windows.Forms.TextBox IpBox;
        private System.Windows.Forms.Label infoIP;
        private System.Windows.Forms.Label infoPort;
        private System.Windows.Forms.Label titleGame;
        private System.Windows.Forms.Label InfoStatus;
    }
}

