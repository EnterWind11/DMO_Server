using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WorldServer1
{
    public class WorldServer1
    {
        private const int DEFAULT_BUFFER_LENGTH = 1024;

        public static async Task RunServerAsync()
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 7000);

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
                    await clientSocket.SendAsync(WorldData.helloToClient, SocketFlags.None);

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
                        var packetId = (WorldID)binaryReader.ReadInt16();
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
