using AsyncSockets.ServerSocketProvider;

namespace AsyncSockets.Server
{
    public partial class Form1 : Form
    {
        private ServerSocket _serverSocket;

        public Form1()
        {
            InitializeComponent();
            _serverSocket = new ServerSocket();
        }

        private void btnAcceptIncomingConnection_Click(object sender, EventArgs e)
        {
            _serverSocket.StartListeningForIncomingConnection();
        }

        private void btnSendAll_Click(object sender, EventArgs e)
        {
            _serverSocket.SendToAll(txtMessage.Text.Trim());
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            _serverSocket.StopServer();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _serverSocket.StopServer();
        }
    }
}
