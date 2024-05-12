using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace LoginServer
{
    public class PacketLogic
    {
        public static async Task HandlePacket(Socket clientSocket, PacketID packetId)
        {
            switch (packetId)
            {
                case PacketID.LOGIN:
                    Console.WriteLine("Received login packet");
                    await clientSocket.SendAsync(PacketData.secondPacketFromServerToClient, SocketFlags.None);
                    break;

                case PacketID.SERVER_SELECTION:
                    Console.WriteLine("Received server selection packet");
                    await clientSocket.SendAsync(PacketData.thirdPacketFromServerToClient, SocketFlags.None);
                    break;

                case PacketID.CHARA_SELECTION:
                    Console.WriteLine("Received character selection packet");
                    await clientSocket.SendAsync(PacketData.fourthPacketFromServerToClient, SocketFlags.None);
                    break;

                case PacketID.CONFIRM:
                    Console.WriteLine("Received confirmation packet");
                    await clientSocket.SendAsync(PacketData.sixthPacketFromServerToClient, SocketFlags.None);
                    break;

                default:
                    Console.WriteLine($"Packet ID {packetId} is not handled");
                    break;
            }
        }
    }
}