namespace HTTP.Server.Sockets
{
	using HTTP.Server.Handlers;
	using System;
	using System.Net;
	using System.Net.Sockets;
	using System.Threading;

	public class ServerSocket : Socket
    {
		public ServerSocket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
			:base (addressFamily, socketType, protocolType) { }

		public void Run(IPEndPoint endPoint)
		{
			try
			{
				Bind(endPoint);
				Listen(int.MaxValue);
				Logger.Print(endPoint, "Server started");
				while (true)
				{
					var args = new SocketAsyncEventArgs();
					args.Completed += async (sender, e) =>
					{
						await new RequestHandler(e.AcceptSocket).Process();
					};
					AcceptAsync(args);
					Thread.Sleep(1);
				}
			}
			catch (ObjectDisposedException ex)
			{
				Logger.Print(ex, "Connection problem");
			}
			catch (Exception ex)
			{
				Logger.Print(ex);
			}
		}
	}
}
