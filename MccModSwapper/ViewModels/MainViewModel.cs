using Microsoft.Extensions.Logging;
using System.IO;
using Emet.FileSystems;
using Newtonsoft.Json;
using SemVer;

namespace MccModSwapper.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		[JsonIgnore]
		private const string _storagePath = "settings.json";

		[JsonIgnore]
		public static string CurrentVersion { get { return "1.0.0"; } }

		public string Version { get { return "1.0.0"; } }

		public string MccInstallPath
		{
			get { return _mccInstallPath; }
			set
			{
				SetField(ref _mccInstallPath, value, "MccInstallPath");
				OnPropertyChanged("MccInstallPathValid");
				OnPropertyChanged("PathsValid");
				CheckSymbolicStatus();
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
				CheckSymbolicStatus();
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
				CheckSymbolicStatus();
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

		[JsonIgnore]
		public bool SwitchToMods
		{
			get { return _switchToMods; }
			set { SetField(ref _switchToMods, value, "SwitchToMods"); }
		}
		private bool _switchToMods;

		[JsonIgnore]
		public bool SwitchToClean
		{
			get { return _switchToClean; }
			set { SetField(ref _switchToClean, value, "SwitchToClean"); }
		}
		private bool _switchToClean;

		private void CheckSymbolicStatus()
		{
			SwitchToMods = false;
			SwitchToClean = false;

			if (!PathsValid)
				return;

			var reachPath = $"{MccInstallPath}\\haloreach";
			var reachPathInfo = new FileInfo(reachPath);
			var isSymlink = reachPathInfo.Attributes.HasFlag(FileAttributes.ReparsePoint);

			if (!isSymlink)
				return;

			try
			{
				var symLink = FileSystem.ReadLink(reachPath);

				if (symLink == ReachModsPath)
					SwitchToMods = true;
				else if (symLink == ReachCleanPath)
					SwitchToClean = true;
			}
			catch (IOException ex)
			{
				Program.Logger.LogError(ex, "Unable to read haloreach path in MCC install directory");

				if (ex.HResult != 2)
				{
					// TODO(afr): Write messagebox
				}
			}
		}

		public void Save()
		{
			File.WriteAllText(_storagePath, JsonConvert.SerializeObject(this));
		}

		private void SaveIfValid()
		{
			if (!PathsValid)
				return;

			Program.Logger.LogInformation("Paths are valid, saving settings");

			Save();
		}

		public static MainViewModel Load()
		{
			Program.Logger.LogInformation("Loading settings");

			if (!File.Exists(_storagePath))
			{
				Program.Logger.LogInformation("No settings found, creating new");

				return DiscardAndSaveNew();
			}

			Program.Logger.LogInformation("Existing settings found, deseralizing");

			var viewModelString = File.ReadAllText(_storagePath);
			var viewModel = JsonConvert.DeserializeObject<MainViewModel>(viewModelString);
			var range = new Range($"~{CurrentVersion}");

			if (range.IsSatisfied(viewModel.Version))
				return viewModel;

			Program.Logger.LogInformation("Settings version does not match, discarding", viewModel.Version, CurrentVersion);

			return DiscardAndSaveNew();
		}

		private static MainViewModel DiscardAndSaveNew()
		{
			var newViewModel = new MainViewModel();

			newViewModel.Save();

			return newViewModel;
		}
	}
}
