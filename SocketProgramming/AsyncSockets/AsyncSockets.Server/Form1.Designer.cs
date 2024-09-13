namespace AsyncSockets.Server
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAcceptIncomingConnection = new Button();
            btnSendAll = new Button();
            label1 = new Label();
            txtMessage = new TextBox();
            btnStopServer = new Button();
            SuspendLayout();
            // 
            // btnAcceptIncomingConnection
            // 
            btnAcceptIncomingConnection.Location = new Point(24, 25);
            btnAcceptIncomingConnection.Name = "btnAcceptIncomingConnection";
            btnAcceptIncomingConnection.Size = new Size(334, 34);
            btnAcceptIncomingConnection.TabIndex = 0;
            btnAcceptIncomingConnection.Text = "Accept Incoming Connection";
            btnAcceptIncomingConnection.UseVisualStyleBackColor = true;
            btnAcceptIncomingConnection.Click += btnAcceptIncomingConnection_Click;
            // 
            // btnSendAll
            // 
            btnSendAll.Location = new Point(606, 112);
            btnSendAll.Name = "btnSendAll";
            btnSendAll.Size = new Size(112, 34);
            btnSendAll.TabIndex = 1;
            btnSendAll.Text = "&Send All";
            btnSendAll.UseVisualStyleBackColor = true;
            btnSendAll.Click += btnSendAll_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 112);
            label1.Name = "label1";
            label1.Size = new Size(86, 25);
            label1.TabIndex = 2;
            label1.Text = "Message:";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(116, 112);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(462, 31);
            txtMessage.TabIndex = 3;
            txtMessage.Text = "Message for client";
            // 
            // btnStopServer
            // 
            btnStopServer.Location = new Point(24, 197);
            btnStopServer.Name = "btnStopServer";
            btnStopServer.Size = new Size(168, 34);
            btnStopServer.TabIndex = 4;
            btnStopServer.Text = "S&top Server";
            btnStopServer.UseVisualStyleBackColor = true;
            btnStopServer.Click += btnStopServer_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(761, 270);
            Controls.Add(btnStopServer);
            Controls.Add(txtMessage);
            Controls.Add(label1);
            Controls.Add(btnSendAll);
            Controls.Add(btnAcceptIncomingConnection);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAcceptIncomingConnection;
        private Button btnSendAll;
        private Label label1;
        private TextBox txtMessage;
        private Button btnStopServer;
    }
}
