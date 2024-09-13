using System.Net;
using System.Net.Sockets;
using System.Text;

internal class Program
{

    private static void Main(string[] args)
    {
        Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPAddress iPAddress = IPAddress.Any;
        IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 23000);

        try
        {
            listenerSocket.Bind(iPEndPoint);
            listenerSocket.Listen(5);

            Console.WriteLine("About to accept incoming connection.");

            Socket client = listenerSocket.Accept(); // blocking operation

            Console.WriteLine($"Client connected. {client.ToString()} - IP End Point: {client.RemoteEndPoint.ToString()}");

            byte[] buff = new byte[128];


            while (true)
            {
                var numberOfReceivedBytes = client.Receive(buff);

                Console.WriteLine($"Number of received bytes:{numberOfReceivedBytes}");
                Console.WriteLine($"Data sent by client is:{buff}");

                string receivedText = Encoding.UTF8.GetString(buff, 0, numberOfReceivedBytes);

                Console.WriteLine($"Data sent by client is: {receivedText}");

                client.Send(buff);

                if (receivedText == "x")
                {
                    break;
                }

                Array.Clear(buff, 0, buff.Length);
                numberOfReceivedBytes = 0;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }
}