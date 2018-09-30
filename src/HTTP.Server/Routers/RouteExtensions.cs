namespace HTTP.Server.Routers
{
	using System;
	using System.IO;

	public static class RouteExtensions
    {
		public static bool IsEmptyUrl(this string url)
		{
			return url.Length == 1 && url.Contains("/");
		}

		public static bool IsUrl(this string url)
		{
			return url.Contains("/");
		}

		public static string MapUrl(this string message)
		{
			var request = message.Split('\n')[0].Split(' ');
			if (request[0] == "GET" && request.Length == 3) {
				return request[1];
			}
			return string.Empty;
		}

		public static string GetHtml(this string request)
		{
			try
			{
				var directory = Environment.CurrentDirectory + "/Content/";
				var url = request.MapUrl();
				if (url.IsEmptyUrl() || url == Routes.Index) {
					return File.ReadAllText(directory + Routes.Index);
				}
				if (url.IsUrl()) {
					return File.ReadAllText(directory + Routes.Error);
				}
			}
			catch(FileNotFoundException)
			{
				return "<html><head></head><body>Not found html file please try rebuild project...</body></html>";
			}
			return string.Empty;
		}
    }
}
