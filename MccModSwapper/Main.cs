using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Windows.Forms;
using MccModSwapper.ViewModels;
using Emet.FileSystems;
using MccModSwapper.Enums;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MccModSwapper
{
	public partial class Main : Form
	{
		public readonly MainViewModel ViewModel;

		public Main()
		{
			InitializeComponent();

			try
			{
				ViewModel = MainViewModel.Load();
			}
			catch (Exception ex)
			{
				Program.Logger.LogError(ex, "Failed to load settings, wiping and creating new settings");

				MessageBox.Show(
					"Unable to load settings, so they have been wiped.For more info check \"logs.txt\" in the application folder.",
					"Settings failed to load",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				ViewModel = new MainViewModel();

				ViewModel.Save();
			}

			txtMccInstallPath.DataBindings.Add("Text", ViewModel, "MccInstallPath", false, DataSourceUpdateMode.OnPropertyChanged);
			txtMccInstallPath.DataBindings.Add("IsValid", ViewModel, "MccInstallPathValid", false, DataSourceUpdateMode.OnPropertyChanged);

			txtReachModsPath.DataBindings.Add("Text", ViewModel, "ReachModsPath", false, DataSourceUpdateMode.OnPropertyChanged);
			txtReachModsPath.DataBindings.Add("IsValid", ViewModel, "ReachModsPathValid", false, DataSourceUpdateMode.OnPropertyChanged);

			txtReachCleanPath.DataBindings.Add("Text", ViewModel, "ReachCleanPath", false, DataSourceUpdateMode.OnPropertyChanged);
			txtReachCleanPath.DataBindings.Add("IsValid", ViewModel, "ReachCleanPathValid", false, DataSourceUpdateMode.OnPropertyChanged);

			gbSwitcher.DataBindings.Add("Selected", ViewModel, "SwitchMode", false, DataSourceUpdateMode.OnPropertyChanged);

			btnDoSwap.DataBindings.Add("Enabled", ViewModel, "PathsValid", false, DataSourceUpdateMode.OnPropertyChanged);
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				return;

			Process.Start(new ProcessStartInfo("cmd", $"/c start https://github.com/0xdeafcafe/MccModSwapper"));
		}

		private void btnPath_Click(object sender, EventArgs e)
		{
			string selectedPath;
			var btn = sender as Button;

			using (var fbd = new FolderBrowserDialog())
			{
				fbd.ShowNewFolderButton = false;

				var result = fbd.ShowDialog(this);

				selectedPath = fbd.SelectedPath;

				if (result != DialogResult.OK || string.IsNullOrWhiteSpace(selectedPath))
					return;
			}

			if (!Directory.Exists(selectedPath))
			{
				Program.Logger.LogInformation("The selected directory doesn't exist", selectedPath, btn.Name);
				MessageBox.Show("The selected directory doesn't exist!", "Directory doesn't exist", MessageBoxButtons.OK, MessageBoxIcon.Information);

				return;
			}


			switch(btn.Name)
			{
				case "btnMccInstallPath":
					ViewModel.MccInstallPath = selectedPath;
					break;
				case "btnReachModsPath":
					ViewModel.ReachModsPath = selectedPath;
					break;
				case "btnReachCleanPath":
					ViewModel.ReachCleanPath = selectedPath;
					break;

				default:
					Program.Logger.LogWarning("Unknown button clicked", btn);
					return;
			}

			ViewModel.Save();
		}

		private void gbSwitcher_SelectedChanged(object sender, EventArgs e)
		{
			if (sender is RadioButton radioButton)
				ViewModel.SwitchMode = (SwitchMode)radioButton.Tag;
		}

		private void btnDoSwap_Click(object sender, EventArgs e)
		{
			// TODO(afr): Add logging and message boxes here

			if (!ViewModel.PathsValid)
				return;

			if (ViewModel.SwitchMode == SwitchMode.Unknown)
				return;

			var reachPath = $"{ViewModel.MccInstallPath}\\haloreach";
			var fileInfo = new FileInfo(reachPath);
			var isSymlink = fileInfo.Attributes.HasFlag(FileAttributes.ReparsePoint);
			var actuallyExists = fileInfo.Attributes.ToString() != "-1"; // Fun hack here bois

			// Something exists with the name haloreach, but it isn't a symlink
			if (!isSymlink && actuallyExists)
			{
				var result = MessageBox.Show(
					"Doing this will delete the existing \"haloreach\" folder in your MCC install path. Are you sure you want to continue?",
					"Hol up!",
					MessageBoxButtons.YesNoCancel,
					MessageBoxIcon.Warning
				);

				if (result != DialogResult.Yes)
					return;

				if (fileInfo.Attributes.HasFlag(FileAttributes.Directory))
				{
					Directory.Delete(reachPath, true);
				}
				else
				{
					try
					{
						File.Delete(reachPath);
					}
					catch (Exception ex)
					{
						Program.Logger.LogError(ex, "Unable to delete the haloreach path, assumed it was a file.", fileInfo.Attributes);

						MessageBox.Show(
							"There was an issue deleting the \"haloreach\" file in the MCC install path. Check the log file.",
							"Well that isn't good.",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error
						);

						return;
					}
				}
			}

			// If it's a symlink, just delete as it's safe
			if (isSymlink && actuallyExists)
				Directory.Delete(reachPath);

			// Decide which type of symlink to create..
			switch(ViewModel.SwitchMode)
			{
				case SwitchMode.Mods:
					FileSystem.CreateSymbolicLink(ViewModel.ReachModsPath, reachPath, FileType.SymbolicLink);
					break;
				case SwitchMode.Clean:
					FileSystem.CreateSymbolicLink(ViewModel.ReachCleanPath, reachPath, FileType.SymbolicLink);
					break;

				default:
					Program.Logger.LogError("Unknown SwitchMode specified", ViewModel.SwitchMode);

					return;
			}
		}
	}
}
