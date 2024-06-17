// Server.cs
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer
{
    public class LoginServer
    {
        private const int DEFAULT_BUFFER_LENGTH = 1024;

        public static async Task RunServerAsync()
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 7029);

            Socket listenerSocket = null;
            try
            {
                listenerSocket = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listenerSocket.Bind(ipEndPoint);
                listenerSocket.Listen(10);
                Console.WriteLine($"Server listening on port: {ipEndPoint.Port}");

                while (true)
                {
                    using Socket clientSocket = await listenerSocket.AcceptAsync();
                    Console.WriteLine("Client connected");

                    var helloPacket = new PacketData.HelloPacket
                    {
                        PacketType = (ushort)PacketID.HELLO,
                        Data = new byte[] { 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x2D, 0x1A }
                    };

                    await clientSocket.SendAsync(new ArraySegment<byte>(PacketData.HelloPacket.Serialize(helloPacket)), SocketFlags.None);

                    while (true)
                    {
                        byte[] receiveBuffer = new byte[DEFAULT_BUFFER_LENGTH];
                        var receivedLength = await clientSocket.ReceiveAsync(receiveBuffer, SocketFlags.None);

                        if (receivedLength <= 0)
                        {
                            break;
                        }

                        // Handle received data based on PacketID
                        using (var ms = new MemoryStream(receiveBuffer))
                        using (var binaryReader = new BinaryReader(ms))
                        {
                            short packetSize = binaryReader.ReadInt16();
                            var packetId = (PacketID)binaryReader.ReadInt16();
                            Console.WriteLine($"Packet size: {packetSize}, Packet ID: {(int)packetId}");

                            byte[] packetData = new byte[receivedLength - 4];
                            Array.Copy(receiveBuffer, 4, packetData, 0, receivedLength - 4);

                            await PacketLogic.HandlePacket(clientSocket, packetId, packetData);
                        }
                    }
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Socket exception: {ex.Message}");
            }
            finally
            {
                listenerSocket?.Close();
            }
        }
    }
}


/*
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer
{
    public class LoginServer
    {
        private const int DEFAULT_BUFFER_LENGTH = 1024;

        public static async Task RunServerAsync()
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 7029);

            Socket listenerSocket = null;
            try
            {
                listenerSocket = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listenerSocket.Bind(ipEndPoint);
                listenerSocket.Listen(10);
                Console.WriteLine($"Server listening on port: {ipEndPoint.Port}");

                while (true)
                {
                    using Socket clientSocket = await listenerSocket.AcceptAsync();
                    Console.WriteLine("Client connected");
                    await clientSocket.SendAsync(PacketData.helloToClient, SocketFlags.None);

                    while (true)
                    {
                        byte[] receiveBuffer = new byte[DEFAULT_BUFFER_LENGTH];
                        var receivedLength = await clientSocket.ReceiveAsync(receiveBuffer, SocketFlags.None);

                        if (receivedLength <= 0)
                        {
                            break;
                        }

                        // Handle received data based on PacketID (implement logic here)
                        var ms = new MemoryStream(receiveBuffer);
                        var binaryReader = new BinaryReader(ms);
                        short packetSize = binaryReader.ReadInt16();
                        var packetId = (PacketID)binaryReader.ReadInt16();
                        Console.WriteLine($"Packet size: {packetSize}, Packet ID: {(int)packetId}");

                        await PacketLogic.HandlePacket(clientSocket, packetId);
                        
                    }
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Socket exception: {ex.Message}");
            }
            finally
            {
                listenerSocket?.Close();
            }
        }
    }
}
*/
