// PacketLogic.cs
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace LoginServer
{
    public static class PacketLogic
    {
        public static async Task HandlePacket(Socket clientSocket, PacketID packetId, byte[] data)
        {
            switch (packetId)
            {
                case PacketID.LOGIN:
                    var loginPacket = PacketData.LoginPacket.Deserialize(data);
                    Console.WriteLine($"Login Attempt: {loginPacket.Username}");
                    await clientSocket.SendAsync(new ArraySegment<byte>(data), SocketFlags.None);
                    break;
                case PacketID.SERVER_SELECTION:
                    var serverPacket = PacketData.ServerSelectionPacket.Deserialize(data);
                    Console.WriteLine($"Server Selection: Server ID {serverPacket.ServerId}");
                    break;
                case PacketID.CHARA_SELECTION:
                    var charaPacket = PacketData.CharacterSelectionPacket.Deserialize(data);
                    Console.WriteLine($"Character Selection Attempt for ID: {charaPacket.CharacterId}");
                    break;
                case PacketID.CONFIRM:
                    var confirmPacket = PacketData.ConfirmationPacket.Deserialize(data);
                    Console.WriteLine($"Confirmation Received: {confirmPacket.IsConfirmed}");
                    break;
                case PacketID.HELLO:
                    var helloPacket = PacketData.HelloPacket.Deserialize(data);
                    Console.WriteLine("Hello packet received");
                    break;
                default:
                    Console.WriteLine($"Unhandled Packet ID: {packetId}");
                    break;
            }
        }
    }
}

/*using System.Net.Sockets;
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
}*/