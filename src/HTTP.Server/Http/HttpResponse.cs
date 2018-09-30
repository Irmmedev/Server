namespace HTTP.Server.Http
{
	using System.Text;

	public class HttpResponse
    {
		public static StringBuilder SetHeader()
		{
			var builder = new StringBuilder();
			builder.AppendLine(@"HTTP/1.1 200 OK");
			builder.AppendLine(@"Content-Type: text/html");
			builder.AppendLine(@"");
			return builder;
		}
    }
}
