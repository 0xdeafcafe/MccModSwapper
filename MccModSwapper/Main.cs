using MccModSwapper.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Windows.Forms;

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
					"Settings failed to load",
					"Unable to load settings, so they have been wiped.For more info check \"logs.txt\" in the application folder.",
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
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			var helpDialog = new Help();

			helpDialog.ShowDialog(this);
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
				MessageBox.Show("Directory doesn't exist", "The selected directory doesn't exist!", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
	}
}
