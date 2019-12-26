using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MccModSwapper.Controls
{
	public class ExtendedTextBox : TextBox
	{
		public bool IsValid { get; set; } = true;

		[DllImport("user32.dll")]
		static extern IntPtr GetWindowDC(IntPtr hWnd);

		[DllImport("user32.dll")]
		static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		[DllImport("user32.dll")]
		static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprc, IntPtr hrgn, uint flags);

		public ExtendedTextBox() : base()
		{
			BorderStyle = BorderStyle.Fixed3D;
		}

		protected override void WndProc(ref Message m)
		{
			// Can you believe it's this fucking weird and hacky to change the border colour? Never thought I'd
			// see the day I thought HTML/CSS was well designed.
			base.WndProc(ref m);

			if (IsValid)
				return;

			var hdc = GetWindowDC(Handle);
			var variance = 1;

			using (var graphics = Graphics.FromHdcInternal(hdc))
			using (var pen = new Pen(Color.FromArgb(0xfc, 0x32, 0x33)))
			{
				graphics.DrawRectangle(pen, new Rectangle(0, 0, Width - variance, Height - variance));
			}

			ReleaseDC(Handle, hdc);
		}
	}
}
