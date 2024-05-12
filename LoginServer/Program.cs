using System.Threading.Tasks;

namespace LoginServer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await GameServer.RunServerAsync();
        }
    }
}