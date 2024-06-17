// PacketID.cs
using System;

namespace LoginServer
{
    public enum PacketID : ushort
    {
        LOGIN = 65535,
        SERVER_SELECTION = 3301,
        CHARA_SELECTION = 1701,
        CONFIRM = 1702,
        HELLO = 17
    }
}


/*using System;

namespace LoginServer
{
    public enum PacketID : ushort
    {
        LOGIN = 65535,
        SERVER_SELECTION = 3301,
        CHARA_SELECTION = 1701,
        CONFIRM = 1702,
        
        /*LOGIN = 0xffff,
        SERVER_SELECTION = 0x0ce5,
        CHARA_SELECTION = 0x06a5,
        CONFIRM = 0x06a6,#1#
    }
}*/