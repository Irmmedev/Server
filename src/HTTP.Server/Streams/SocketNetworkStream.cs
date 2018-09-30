namespace HTTP.Server.Streams
{
	using System;
	using System.Net.Sockets;
	using System.Text;
	using System.Threading.Tasks;

	public class SocketNetworkStream : NetworkStream
	{
		public SocketNetworkStream(Socket socket) : base(socket) { }

		public async Task<string> Read()
		{
			var buffer = new byte[1024];
			await ReadAsync(buffer, 0, buffer.Length);
			var message = Encoding.UTF8.GetString(buffer);
			Logger.Print(message);
			return message;
		}

		public async Task Write(string response)
		{
			await Socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(response)), SocketFlags.None);
		}
	}
}
