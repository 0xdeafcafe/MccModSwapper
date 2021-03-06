﻿using MccModSwapper.Controls;

namespace MccModSwapper
{
	partial class Main
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtMccInstallPath = new ExtendedTextBox();
			this.btnMccInstallPath = new System.Windows.Forms.Button();
			this.lblMccInstallPath = new System.Windows.Forms.Label();
			this.gbPaths = new System.Windows.Forms.GroupBox();
			this.btnReachCleanPath = new System.Windows.Forms.Button();
			this.lblReachCleanPath = new System.Windows.Forms.Label();
			this.txtReachCleanPath = new ExtendedTextBox();
			this.lblReachModsPath = new System.Windows.Forms.Label();
			this.btnReachModsPath = new System.Windows.Forms.Button();
			this.txtReachModsPath = new ExtendedTextBox();
			this.gbSwitcher = new RadioGroupBox();
			this.btnDoSwap = new System.Windows.Forms.Button();
			this.rbSwitchClean = new System.Windows.Forms.RadioButton();
			this.rbSwitchMods = new System.Windows.Forms.RadioButton();
			this.btnHelp = new System.Windows.Forms.Button();
			this.gbPaths.SuspendLayout();
			this.gbSwitcher.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtMccInstallPath
			// 
			this.txtMccInstallPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMccInstallPath.Location = new System.Drawing.Point(114, 19);
			this.txtMccInstallPath.Name = "txtMccInstallPath";
			this.txtMccInstallPath.Size = new System.Drawing.Size(363, 23);
			this.txtMccInstallPath.TabIndex = 0;
			// 
			// btnMccInstallPath
			// 
			this.btnMccInstallPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnMccInstallPath.Location = new System.Drawing.Point(483, 18);
			this.btnMccInstallPath.Name = "btnMccInstallPath";
			this.btnMccInstallPath.Size = new System.Drawing.Size(75, 23);
			this.btnMccInstallPath.TabIndex = 1;
			this.btnMccInstallPath.Text = "Pick";
			this.btnMccInstallPath.UseVisualStyleBackColor = true;
			this.btnMccInstallPath.Click += new System.EventHandler(this.btnPath_Click);
			// 
			// lblMccInstallPath
			// 
			this.lblMccInstallPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblMccInstallPath.AutoSize = true;
			this.lblMccInstallPath.Location = new System.Drawing.Point(6, 22);
			this.lblMccInstallPath.Name = "lblMccInstallPath";
			this.lblMccInstallPath.Size = new System.Drawing.Size(98, 15);
			this.lblMccInstallPath.TabIndex = 2;
			this.lblMccInstallPath.Text = "MCC install path:";
			// 
			// gbPaths
			// 
			this.gbPaths.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbPaths.Controls.Add(this.btnReachCleanPath);
			this.gbPaths.Controls.Add(this.btnReachModsPath);
			this.gbPaths.Controls.Add(this.btnMccInstallPath);
			this.gbPaths.Controls.Add(this.lblReachCleanPath);
			this.gbPaths.Controls.Add(this.txtReachCleanPath);
			this.gbPaths.Controls.Add(this.lblReachModsPath);
			this.gbPaths.Controls.Add(this.txtReachModsPath);
			this.gbPaths.Controls.Add(this.txtMccInstallPath);
			this.gbPaths.Controls.Add(this.lblMccInstallPath);
			this.gbPaths.Location = new System.Drawing.Point(12, 12);
			this.gbPaths.Name = "gbPaths";
			this.gbPaths.Size = new System.Drawing.Size(564, 110);
			this.gbPaths.TabIndex = 3;
			this.gbPaths.TabStop = false;
			this.gbPaths.Text = "Paths";
			// 
			// btnReachCleanPath
			// 
			this.btnReachCleanPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnReachCleanPath.Location = new System.Drawing.Point(483, 76);
			this.btnReachCleanPath.Name = "btnReachCleanPath";
			this.btnReachCleanPath.Size = new System.Drawing.Size(75, 23);
			this.btnReachCleanPath.TabIndex = 1;
			this.btnReachCleanPath.Text = "Pick";
			this.btnReachCleanPath.UseVisualStyleBackColor = true;
			this.btnReachCleanPath.Click += new System.EventHandler(this.btnPath_Click);
			// 
			// lblReachCleanPath
			// 
			this.lblReachCleanPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblReachCleanPath.AutoSize = true;
			this.lblReachCleanPath.Location = new System.Drawing.Point(6, 80);
			this.lblReachCleanPath.Name = "lblReachCleanPath";
			this.lblReachCleanPath.Size = new System.Drawing.Size(100, 15);
			this.lblReachCleanPath.TabIndex = 2;
			this.lblReachCleanPath.Text = "Reach clean path:";
			// 
			// txtReachCleanPath
			// 
			this.txtReachCleanPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtReachCleanPath.Location = new System.Drawing.Point(114, 77);
			this.txtReachCleanPath.Name = "txtReachCleanPath";
			this.txtReachCleanPath.Size = new System.Drawing.Size(363, 23);
			this.txtReachCleanPath.TabIndex = 0;
			// 
			// lblReachModsPath
			// 
			this.lblReachModsPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblReachModsPath.AutoSize = true;
			this.lblReachModsPath.Location = new System.Drawing.Point(6, 51);
			this.lblReachModsPath.Name = "lblReachModsPath";
			this.lblReachModsPath.Size = new System.Drawing.Size(102, 15);
			this.lblReachModsPath.TabIndex = 2;
			this.lblReachModsPath.Text = "Reach mods path:";
			// 
			// btnReachModsPath
			// 
			this.btnReachModsPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnReachModsPath.Location = new System.Drawing.Point(483, 47);
			this.btnReachModsPath.Name = "btnReachModsPath";
			this.btnReachModsPath.Size = new System.Drawing.Size(75, 23);
			this.btnReachModsPath.TabIndex = 1;
			this.btnReachModsPath.Text = "Pick";
			this.btnReachModsPath.UseVisualStyleBackColor = true;
			this.btnReachModsPath.Click += new System.EventHandler(this.btnPath_Click);
			// 
			// txtReachModsPath
			// 
			this.txtReachModsPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtReachModsPath.Location = new System.Drawing.Point(114, 48);
			this.txtReachModsPath.Name = "txtReachModsPath";
			this.txtReachModsPath.Size = new System.Drawing.Size(363, 23);
			this.txtReachModsPath.TabIndex = 0;
			// 
			// gbSwitcher
			// 
			this.gbSwitcher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbSwitcher.Controls.Add(this.btnDoSwap);
			this.gbSwitcher.Controls.Add(this.rbSwitchClean);
			this.gbSwitcher.Controls.Add(this.rbSwitchMods);
			this.gbSwitcher.Location = new System.Drawing.Point(12, 128);
			this.gbSwitcher.Name = "gbSwitcher";
			this.gbSwitcher.Size = new System.Drawing.Size(564, 102);
			this.gbSwitcher.TabIndex = 4;
			this.gbSwitcher.TabStop = false;
			this.gbSwitcher.Text = "Switcher";
			this.gbSwitcher.SelectedChanged += gbSwitcher_SelectedChanged;
			// 
			// btnDoSwap
			// 
			this.btnDoSwap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDoSwap.Location = new System.Drawing.Point(6, 72);
			this.btnDoSwap.Name = "btnDoSwap";
			this.btnDoSwap.Size = new System.Drawing.Size(552, 23);
			this.btnDoSwap.TabIndex = 1;
			this.btnDoSwap.Text = "Do le swap";
			this.btnDoSwap.UseVisualStyleBackColor = true;
			this.btnDoSwap.Click += new System.EventHandler(this.btnDoSwap_Click);
			// 
			// rbSwitchMods
			// 
			this.rbSwitchMods.AutoSize = true;
			this.rbSwitchMods.Location = new System.Drawing.Point(6, 22);
			this.rbSwitchMods.Name = "rbSwitchMods";
			this.rbSwitchMods.Size = new System.Drawing.Size(107, 19);
			this.rbSwitchMods.TabIndex = 0;
			this.rbSwitchMods.TabStop = true;
			this.rbSwitchMods.Text = "Switch to modded content";
			this.rbSwitchMods.UseVisualStyleBackColor = true;
			this.rbSwitchMods.Tag = 0;
			// 
			// rbSwitchClean
			// 
			this.rbSwitchClean.AutoSize = true;
			this.rbSwitchClean.Location = new System.Drawing.Point(6, 47);
			this.rbSwitchClean.Name = "rbSwitchClean";
			this.rbSwitchClean.Size = new System.Drawing.Size(105, 19);
			this.rbSwitchClean.TabIndex = 0;
			this.rbSwitchClean.TabStop = true;
			this.rbSwitchClean.Text = "Switch to clean content";
			this.rbSwitchClean.UseVisualStyleBackColor = true;
			this.rbSwitchClean.Tag = 1;
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnHelp.Location = new System.Drawing.Point(12, 236);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(564, 23);
			this.btnHelp.TabIndex = 1;
			this.btnHelp.Text = "Help?";
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(588, 270);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.gbSwitcher);
			this.Controls.Add(this.gbPaths);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1000, 309);
			this.MinimumSize = new System.Drawing.Size(400, 309);
			this.Name = "Main";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Auto;
			this.Text = "MCC - Mod Swapper";
			this.gbPaths.ResumeLayout(false);
			this.gbPaths.PerformLayout();
			this.gbSwitcher.ResumeLayout(false);
			this.gbSwitcher.PerformLayout();
			this.ResumeLayout(false);
			this.Icon = MccModSwapper.Properties.Resources.ShittyIcon;

		}

		#endregion

		private ExtendedTextBox txtMccInstallPath;
		private System.Windows.Forms.Button btnMccInstallPath;
		private System.Windows.Forms.Label lblMccInstallPath;
		private System.Windows.Forms.GroupBox gbPaths;
		private System.Windows.Forms.Button btnReachCleanPath;
		private System.Windows.Forms.Label lblReachCleanPath;
		private System.Windows.Forms.Label lblReachModsPath;
		private System.Windows.Forms.Button btnReachModsPath;
		private ExtendedTextBox txtReachModsPath;
		private RadioGroupBox gbSwitcher;
		private System.Windows.Forms.Button btnDoSwap;
		private System.Windows.Forms.RadioButton rbSwitchClean;
		private System.Windows.Forms.RadioButton rbSwitchMods;
		private ExtendedTextBox txtReachCleanPath;
		private System.Windows.Forms.Button btnHelp;
	}
}

