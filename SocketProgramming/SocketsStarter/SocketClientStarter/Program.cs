using System.Net;
using System.Net.Sockets;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        IPAddress ipAddress = null;
        int portNumber = 0;

        try
        {
            Console.WriteLine("*** Welcome to Socket Client Starter Example by Armin Kianian ***");
            Console.WriteLine("Please type a valid server IP address and press Enter: ");

            string strIpAddress = Console.ReadLine();

            if (!IPAddress.TryParse(strIpAddress, out ipAddress))
            {
                Console.WriteLine("Invalid server IP supplied.");
                return;
            }

            Console.WriteLine("Please supply a valid port number 0 - 65535 and press Enter: ");

            string strPortNumber = Console.ReadLine();

            if (!int.TryParse(strPortNumber.Trim(), out portNumber))
            {
                Console.WriteLine("Invalid port number supplied, return.");
                return;
            }

            if (portNumber <= 0 || portNumber > 65535)
            {
                Console.WriteLine("Port number must be between 0 and 65535.");
                return;
            }

            Console.WriteLine($"IPAddress: {ipAddress} - Port: {portNumber}");

            client.Connect(ipAddress, portNumber);

            Console.WriteLine("Connected to the server, type text and press enter to send it to the srever, type <EXIT> to close.");

            string inputCommand = string.Empty;

            while (true)
            {
                inputCommand = Console.ReadLine();

                if (inputCommand.Equals("<EXIT>"))
                {
                    break;
                }

                byte[] buffSend = Encoding.ASCII.GetBytes(inputCommand);

                client.Send(buffSend);

                byte[] buffReceived = new byte[128];
                int nRecv = client.Receive(buffReceived);

                Console.WriteLine("Data received: {0}", Encoding.ASCII.GetString(buffReceived, 0, nRecv));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            if (client != null)
            {
                if (client.Connected)
                {
                    client.Shutdown(SocketShutdown.Both);
                }

                client.Close();
                client.Dispose();
            }

        }

        Console.WriteLine("Press a key to exit ... ");
        Console.ReadKey();
    }
}