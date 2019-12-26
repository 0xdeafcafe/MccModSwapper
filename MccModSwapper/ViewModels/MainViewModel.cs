using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;

namespace MccModSwapper.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		[JsonIgnore]
		private const string _storagePath = "settings.json";

		public string MccInstallPath
		{
			get { return _mccInstallPath; }
			set
			{
				SetField(ref _mccInstallPath, value, "MccInstallPath");
				OnPropertyChanged("MccInstallPathValid");
				OnPropertyChanged("PathsValid");
				SaveIfValid();
			}
		}
		private string _mccInstallPath = "";

		public string ReachModsPath
		{
			get { return _reachModsPath; }
			set
			{
				SetField(ref _reachModsPath, value, "ReachModsPath");
				OnPropertyChanged("ReachModsPathValid");
				OnPropertyChanged("PathsValid");
				SaveIfValid();
			}
		}
		private string _reachModsPath = "";

		public string ReachCleanPath
		{
			get { return _reachCleanPath; }
			set
			{
				SetField(ref _reachCleanPath, value, "ReachCleanPath");
				OnPropertyChanged("ReachCleanPathValid");
				OnPropertyChanged("PathsValid");
				SaveIfValid();
			}
		}
		private string _reachCleanPath = "";

		[JsonIgnore]
		public bool MccInstallPathValid { get { return Directory.Exists(MccInstallPath); } }

		[JsonIgnore]
		public bool ReachModsPathValid { get { return Directory.Exists(ReachModsPath); } }

		[JsonIgnore]
		public bool ReachCleanPathValid { get { return Directory.Exists(ReachCleanPath); } }

		[JsonIgnore]
		public bool PathsValid { get { return MccInstallPathValid && ReachModsPathValid && ReachCleanPathValid; } }

		private void SaveIfValid()
		{
			if (!PathsValid)
				return;

			Program.Logger.LogInformation("Paths are valid, saving settings");

			Save();
		}
		
		public void Save()
		{
			File.WriteAllText(_storagePath, JsonConvert.SerializeObject(this));
		}

		public static MainViewModel Load()
		{
			Program.Logger.LogInformation("Loading settings");

			if (!File.Exists(_storagePath))
			{
				Program.Logger.LogInformation("No settings found, creating new");

				var newViewModel = new MainViewModel();

				newViewModel.Save();

				return newViewModel;
			}

			Program.Logger.LogInformation("Existing settings found, deseralizing");

			var viewModelString = File.ReadAllText(_storagePath);

			return JsonConvert.DeserializeObject<MainViewModel>(viewModelString);
		}
	}
}
