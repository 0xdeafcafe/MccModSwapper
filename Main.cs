using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace MccModSwapper
{
	public partial class Main : Form
	{
		private readonly Settings _settings;

		public Main()
		{
			InitializeComponent();

			try
			{
				_settings = Settings.Load();
			}
			catch (Exception ex)
			{
				Program.Logger.Log(LogLevel.Error, "Failed to load settings, wiping and creating new settings", ex);

				MessageBox.Show(
					"Settings failed to load",
					"Unable to load settings, so they have been wiped.For more info check \"logs.txt\" in the application folder.",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				_settings = new Settings();

				_settings.Save();
			}
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			var helpDialog = new Help();

			helpDialog.ShowDialog(this);
		}
	}
}
