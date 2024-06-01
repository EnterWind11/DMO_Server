using System.Net.Sockets;

namespace WorldServer1;

public class WorldLogic
{
    public static async Task HandlePacket(Socket clientSocket, WorldID packetId)
    {
        switch (packetId)
        {
            case WorldID.LOGIN:
                Console.WriteLine("Received login packet");
                await clientSocket.SendAsync(WorldData.secondPacketFromServerToClient, SocketFlags.None);
                break;

            case WorldID.SERVER_SELECTION:
                Console.WriteLine("Received server selection packet");
                await clientSocket.SendAsync(WorldData.thirdPacketFromServerToClient, SocketFlags.None);
                break;

            case WorldID.CHARA_SELECTION:
                Console.WriteLine("Received character selection packet");
                await clientSocket.SendAsync(WorldData.fourthPacketFromServerToClient, SocketFlags.None);
                break;

            /*case WorldID.CONFIRM:
                Console.WriteLine("Received confirmation packet");
                await clientSocket.SendAsync(WorldData.sixthPacketFromServerToClient, SocketFlags.None);
                break;*/

            default:
                Console.WriteLine($"Packet ID {packetId} is not handled");
                break;
        }
    }
}