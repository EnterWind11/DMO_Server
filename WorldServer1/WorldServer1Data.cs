﻿using System;

namespace LoginServer
{
    public static class PacketData
    {
        public static byte[] helloToClient = new byte[]
        {
            0x11, 0x00, 0xFF, 0xFF, 0x08, 0xC2,
            0x02, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x01, 0x2D, 0x1A
        };

        public static byte[] secondPacketFromServerToClient = new byte[]
        {
            0x0c, 0x00, 0xfe, 0xff, 0x49, 0xbc, 0x09, 0xc2,
            0xdc, 0x65, 0x30, 0x1a
        };

        public static byte[] thirdPacketFromServerToClient = new byte[]
        {
            0x0b, 0x00, 0xe5, 0x0c, 0x00, 0x00, 0x00, 0x00,
            0x01, 0x37, 0x1a
        };

        public static byte[] fourthPacketFromServerToClient = new byte[]
        {
            0x76, 0x00, 0xa5, 0x06, 0x01, 0x02, 0x00, 0x00,
            0x00, 0x07, 0x4c, 0x75, 0x63, 0x65, 0x6d, 0x6f,
            0x6e, 0x00, 0x00, 0x00, 0x01, 0x01, 0x05, 0x05,
            0x06, 0x64, 0x65, 0x6c, 0x65, 0x74, 0x65, 0x00,
            0x28, 0x65, 0x37, 0x39, 0x35, 0x65, 0x35, 0x62,
            0x65, 0x33, 0x31, 0x32, 0x64, 0x65, 0x65, 0x30,
            0x32, 0x36, 0x31, 0x65, 0x34, 0x31, 0x64, 0x39,
            0x65, 0x38, 0x62, 0x33, 0x39, 0x61, 0x36, 0x35,
            0x30, 0x34, 0x62, 0x64, 0x66, 0x34, 0x31, 0x61,
            0x31, 0x00, 0x28, 0x36, 0x36, 0x32, 0x63, 0x61,
            0x33, 0x33, 0x38, 0x38, 0x35, 0x31, 0x63, 0x33,
            0x38, 0x62, 0x65, 0x39, 0x66, 0x35, 0x39, 0x63,
            0x32, 0x62, 0x64, 0x64, 0x66, 0x33, 0x32, 0x63,
            0x38, 0x62, 0x61, 0x37, 0x33, 0x36, 0x33, 0x32,
            0x33, 0x64, 0x31, 0x00, 0x4a, 0x1a
        };

        public static byte[] sixthPacketFromServerToClient = new byte[]
        {
            0x23, 0x00, 0x85, 0x03, 0x74, 0x09, 0x00, 0x00,
            0xf7, 0x78, 0x5d, 0x51, 0x0e, 0x7f, 0x00, 0x00, 
            0x01, 0x00, 0x58, 0x1b, 0x00, 0x00, 0x00, 0x1f, 
            0x1a
        };
    }
}
