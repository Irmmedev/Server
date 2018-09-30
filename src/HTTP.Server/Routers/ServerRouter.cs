namespace HTTP.Server.Routers
{
	using HTTP.Server.Http;
	using HTTP.Server.Streams;
	using System.Threading.Tasks;

	public class ServerRouter
    {
		public static async Task<string> SetResponse(SocketNetworkStream socketNetworkStream)
		{
			var httpRawRequest = await socketNetworkStream.Read();
			return HttpResponse.SetHeader().AppendLine(httpRawRequest.GetHtml()).ToString();
		}
    }
}
