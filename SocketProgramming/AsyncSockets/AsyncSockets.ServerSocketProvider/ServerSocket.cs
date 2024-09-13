using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;

namespace AsyncSockets.ServerSocketProvider
{
    public class ServerSocket
    {
        private IPAddress? _ipAddress;
        private int _port;
        private TcpListener? _tcpListener;
        private List<TcpClient> _clients;

        public bool KeepRunning { get; private set; }

        public ServerSocket()
        {
            _clients = new List<TcpClient>();
        }

        public async void StartListeningForIncomingConnection(IPAddress? ipAddress = null, int port = 23000)
        {
            if (ipAddress == null)
            {
                ipAddress = IPAddress.Any;
            }

            if (port <= 0)
            {
                port = 23000;
            }

            _ipAddress = ipAddress;
            _port = port;

            Debug.WriteLine($"IP Address: {_ipAddress} - Port: {_port}");

            _tcpListener = new TcpListener(_ipAddress, _port);

            try
            {
                _tcpListener.Start();

                KeepRunning = true;

                while (KeepRunning)
                {
                    var tcpClient = await _tcpListener.AcceptTcpClientAsync();

                    _clients.Add(tcpClient);

                    Debug.WriteLine($"Client connected successfully, Count: {_clients.Count} {tcpClient.Client.RemoteEndPoint}");

                    TakeCareOfTcpClient(tcpClient);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private async void TakeCareOfTcpClient(TcpClient tcpClient)
        {
            try
            {
                NetworkStream stream = tcpClient.GetStream();
                var streamReader = new StreamReader(stream);

                char[] buffer = new char[64];

                while (KeepRunning)
                {
                    Debug.WriteLine("*** Ready to read");
                    var totalNumberOfCharacters = await streamReader.ReadAsync(buffer, 0, buffer.Length);
                    Debug.WriteLine($"Total Number of Characters: {totalNumberOfCharacters}");

                    if (totalNumberOfCharacters == 0)
                    {
                        RemoveClient(tcpClient);
                        Debug.WriteLine("Socket disconnected");
                        break;
                    }

                    string receivedText = new string(buffer);
                    Debug.WriteLine($"*** RECEIVED: {receivedText}");

                    Array.Clear(buffer, 0, buffer.Length);
                }
            }
            catch (Exception ex)
            {
                RemoveClient(tcpClient);
                Debug.WriteLine(ex.ToString());
            }
        }

        private void RemoveClient(TcpClient tcpClient)
        {
            if (_clients.Contains(tcpClient))
            {
                _clients.Remove(tcpClient);
                Debug.WriteLine($"Client removed, count: {_clients.Count}");
            }
        }

        public async void SendToAll(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            try
            {
                byte[] bufferMessage = Encoding.ASCII.GetBytes(message);

                foreach (var client in _clients)
                {
                    client.GetStream().WriteAsync(bufferMessage, 0, bufferMessage.Length);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public void StopServer()
        {
            try
            {
                if (_tcpListener != null)
                {
                    _tcpListener.Stop();
                }

                // closing client sockets
                foreach (var client in _clients)
                {
                    client.Close();
                }

                _clients.Clear();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
