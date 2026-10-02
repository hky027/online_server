using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;

//服务端
namespace Server
{

    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint pos = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6666);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(pos);
            listener.Listen(4);

            Console.WriteLine("Server is working...");
            Socket sclient = listener.Accept();

            Console.WriteLine("Connected");

            byte[] readbuff = new byte[1024];
            int lenth = sclient.Receive(readbuff);
            string str = Encoding.Default.GetString(readbuff, 0, lenth);
             PlayerInfo p = JsonConvert.DeserializeObject<PlayerInfo>(str);

            Console.WriteLine(p.name);
            Console.ReadLine();
        }
    }

    public class PlayerInfo
    {
        public string name;
        public float x, y, z;

        public PlayerInfo(string n, float a, float b, float c)
        {
            name = n;
            x = a;
            y = b;
            z = c;
        }
    }
}
