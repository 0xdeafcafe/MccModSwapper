using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;

namespace MccModSwapper
{
	public class Settings
	{
		[JsonIgnore]
		private const string _settingsPath = "settings.json";

		public string MccInstallPath { get; set; }

		public string ReachModsPath { get; set; }

		public string ReachCleanPath { get; set; }

		public void Save()
		{
			var settings = JsonConvert.SerializeObject(this);

			File.WriteAllText(_settingsPath, settings);
		}

		public static Settings Load()
		{
			Program.Logger.Log(LogLevel.Information, "Loading settings");

			if (!File.Exists(_settingsPath))
			{
				Program.Logger.Log(LogLevel.Information, "No settings found, creating new");

				var newSettings = new Settings();

				newSettings.Save();

				return newSettings;
			}

			Program.Logger.Log(LogLevel.Information, "Existing settings found, deseralizing");

			var settingsString = File.ReadAllText(_settingsPath);
			var settings = JsonConvert.DeserializeObject<Settings>(settingsString);

			return settings;
		}
	}
}
