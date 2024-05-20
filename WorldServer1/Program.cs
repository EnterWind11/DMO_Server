using System.Threading.Tasks;

namespace WorldServer1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await WorldServer1.RunServerAsync();
        }
    }
}