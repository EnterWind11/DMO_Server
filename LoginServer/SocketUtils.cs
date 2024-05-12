using System.Net.Sockets;

namespace LoginServer
{
    public static class SocketUtils
    {
        public static string GetSocketErrorDescription(SocketError errorCode)
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