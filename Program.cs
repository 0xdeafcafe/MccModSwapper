using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Windows.Forms;

namespace MccModSwapper
{
	public class Program
	{
		public static ILogger<Program> Logger { get; private set; }

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Main());

			var loggerFactory = new LoggerFactory();
			var loggerConfig = new LoggerConfiguration()
				.WriteTo.Console()
				.WriteTo.File("logs.txt", rollingInterval: RollingInterval.Hour)
				.CreateLogger();

			loggerFactory.AddSerilog(loggerConfig);

			Logger = loggerFactory.CreateLogger<Program>();
		}
	}
}
