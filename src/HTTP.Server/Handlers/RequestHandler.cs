namespace HTTP.Server.Handlers
{
	using HTTP.Server.Routers;
	using HTTP.Server.Streams;
	using System;
	using System.Net.Sockets;
	using System.Threading.Tasks;

	public class RequestHandler
	{
		private readonly Socket client;
		private readonly SocketNetworkStream stream;

		public RequestHandler(Socket client)
		{
			this.client = client;
			stream = new SocketNetworkStream(client);
		}

		public async Task Process()
		{
			try
			{
				await stream.Write(await ServerRouter.SetResponse(stream));
			}
			catch(Exception ex)
			{
				Logger.Print(ex.ToString());
			}
			finally
			{
				CloseConnections();
			}
		}

		private void CloseConnections()
		{
			client.Close();
			stream.Close();
		}
	}
}
