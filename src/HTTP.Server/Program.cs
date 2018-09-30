namespace HTTP.Server
{
	using HTTP.Server.Sockets;
	using System;
	using System.Net;
	using System.Net.Sockets;
	using System.Threading.Tasks;

	class Program
    {
        static void Main(string[] args)
        {
			Task.Factory.StartNew(Run, TaskCreationOptions.LongRunning);
			Console.ReadLine();
        }

		static void Run()
		{
			new ServerSocket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
					.Run(new IPEndPoint(IPAddress.Loopback, 8089));
		}

    }
}
