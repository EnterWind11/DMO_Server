﻿namespace LoginServer
{
    public enum PacketID : ushort
    {
        LOGIN = 0xffff,
        SERVER_SELECTION = 0x0ce5,
        CHARA_SELECTION = 0x06a5,
        CONFIRM = 0x06a6, // client to server which triggers the server to send the gameserver ip
    }
}