namespace HTTP.Server
{
	using System;

	public class Logger
    {
		public static bool Enabled = true;

		public static void Print(object objPrint, string additionalText = "")
		{
			if (!Enabled) return;
			if(string.IsNullOrEmpty(additionalText)) {
				Console.WriteLine($"{ objPrint.ToString() }");
			} else {
				Console.WriteLine($"{ additionalText } : { objPrint.ToString() }");
			}
		}
	}
}
