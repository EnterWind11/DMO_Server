using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LoginServer
{
    public class GameServer
    {
        private const int DEFAULT_BUFFER_LENGTH = 1024;

        public static async Task RunServerAsync(string[] args)
        {
            // Initialize Winsock
            IPHostEntry ipEntry = await Dns.GetHostEntryAsync(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Any;
            IPEndPoint ipEndPoint = new(ipAddress, 7029);

            Socket listenerSocket = null;
            try
            {
                // Bind the listener socket to the local endpoint
                listenerSocket = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listenerSocket.Bind(ipEndPoint);
                listenerSocket.Listen(10);
                Console.WriteLine($"Server is listening for incoming connections from port: {ipEndPoint.Port}");

                // Accept incoming connection
                using Socket clientSocket = await listenerSocket.AcceptAsync();
                Console.WriteLine("Client connected");
                Console.WriteLine("Sending hello to client");
                
                await clientSocket.SendAsync(helloToClient, SocketFlags.None);
                
                while (true)
                {
                    byte[] receiveBuffer = new byte[DEFAULT_BUFFER_LENGTH];
                    var receivedLength = await clientSocket.ReceiveAsync(receiveBuffer, SocketFlags.None);

                    if (receivedLength <= 0)
                    {
                        //Console.WriteLine("received less than 0 bytes");
                        continue;
                    }

                    var ms = new MemoryStream(receiveBuffer);
                    var binaryReader = new BinaryReader(ms);

                    short packetSize = binaryReader.ReadInt16();
                    var packetId = (PacketID)binaryReader.ReadInt16();

                    Console.WriteLine($"packet size {packetSize} packetId: {(short)packetId}");
                    
                    var test = Encoding.UTF8.GetString(receiveBuffer, 0, receivedLength);
                    var hexString = BitConverter.ToString(receiveBuffer, 0, receivedLength);
                    Console.WriteLine($"received {receivedLength} bytes data: {hexString} as string {test}");
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Socket exception: {ex.Message}");

                if (ex.SocketErrorCode > 0)
                {
                    Console.WriteLine(
                        $"Error code: {(int)ex.SocketErrorCode} ({GetSocketErrorDescription(ex.SocketErrorCode)})");
                }
            }

            listenerSocket?.Close();
        }
        
        private static byte[] GeneratePacket(int index)
        {
            // Simulate generating a packet based on some index
            return BitConverter.GetBytes(index);
        }
        
        private static string GetSocketErrorDescription(SocketError errorCode)
        {
            switch (errorCode)
            {
                case SocketError.AccessDenied:
                    return "Access denied";
                case SocketError.AddressAlreadyInUse:
                    return "Address already in use";
                case SocketError.ConnectionAborted:
                    return "Connection aborted";
                default:
                    return "Unknown error";
            }
        }
    }
}
