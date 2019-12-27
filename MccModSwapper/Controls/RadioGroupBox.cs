using System;
using System.Linq;
using System.Windows.Forms;

namespace MccModSwapper.Controls
{
	public class RadioGroupBox : GroupBox
	{
		public event EventHandler SelectedChanged = delegate { };

		public int Selected
		{
			get { return _selected; }
			set
			{
				var val = 0;
				var radioButton = Controls.OfType<RadioButton>()
					.FirstOrDefault(r => r.Tag != null && int.TryParse(r.Tag.ToString(), out val) && val == value);

				if (radioButton == null)
					return;

				radioButton.Checked = true;
				_selected = val;
			}
		}
		private int _selected = -1;

		protected override void OnControlAdded(ControlEventArgs e)
		{
			base.OnControlAdded(e);

			if (e.Control is RadioButton radioButton)
				radioButton.CheckedChanged += radioButton_CheckedChanged;
		}

		private void radioButton_CheckedChanged(object sender, EventArgs e)
		{
			var radio = sender as RadioButton;

			if (radio.Checked && radio.Tag != null && int.TryParse(radio.Tag.ToString(), out var val))
			{
				_selected = val;
				SelectedChanged(radio, new EventArgs {  });
			}
		}
	}
}
