#region Copyright
/**
 * SimpleResizer - Resizes and edits multiple images at once.
 * Copyright (C) 2007 Daniël Pelsmaeker
 * 
 * This file is part of SimpleResizer.
 * 
 * SimpleResizer is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * SimpleResizer is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with SimpleResizer.  If not, see http://www.gnu.org/licenses/.
 * 
 * Contributors:
 * - 
 */
#endregion

namespace SimpleResizer
{
	partial class frmReport
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.btnSaveAs = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.txtReport = new System.Windows.Forms.TextBox();
			this.dlgSaveAs = new System.Windows.Forms.SaveFileDialog();
			this.pnlButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlButtons
			// 
			this.pnlButtons.AccessibleDescription = null;
			this.pnlButtons.AccessibleName = null;
			resources.ApplyResources(this.pnlButtons, "pnlButtons");
			this.pnlButtons.BackgroundImage = null;
			this.pnlButtons.Controls.Add(this.btnSaveAs);
			this.pnlButtons.Controls.Add(this.btnClose);
			this.pnlButtons.Font = null;
			this.pnlButtons.Name = "pnlButtons";
			// 
			// btnSaveAs
			// 
			this.btnSaveAs.AccessibleDescription = null;
			this.btnSaveAs.AccessibleName = null;
			resources.ApplyResources(this.btnSaveAs, "btnSaveAs");
			this.btnSaveAs.BackgroundImage = null;
			this.btnSaveAs.Font = null;
			this.btnSaveAs.Name = "btnSaveAs";
			this.btnSaveAs.UseVisualStyleBackColor = true;
			this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
			// 
			// btnClose
			// 
			this.btnClose.AccessibleDescription = null;
			this.btnClose.AccessibleName = null;
			resources.ApplyResources(this.btnClose, "btnClose");
			this.btnClose.BackgroundImage = null;
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnClose.Font = null;
			this.btnClose.Name = "btnClose";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// txtReport
			// 
			this.txtReport.AccessibleDescription = null;
			this.txtReport.AccessibleName = null;
			resources.ApplyResources(this.txtReport, "txtReport");
			this.txtReport.BackColor = System.Drawing.SystemColors.Window;
			this.txtReport.BackgroundImage = null;
			this.txtReport.Font = null;
			this.txtReport.Name = "txtReport";
			this.txtReport.ReadOnly = true;
			// 
			// dlgSaveAs
			// 
			this.dlgSaveAs.DefaultExt = "txt";
			this.dlgSaveAs.FileName = "rapport.txt";
			resources.ApplyResources(this.dlgSaveAs, "dlgSaveAs");
			// 
			// frmReport
			// 
			this.AcceptButton = this.btnClose;
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.CancelButton = this.btnClose;
			this.Controls.Add(this.txtReport);
			this.Controls.Add(this.pnlButtons);
			this.Font = null;
			this.Icon = null;
			this.MinimizeBox = false;
			this.Name = "frmReport";
			this.Load += new System.EventHandler(this.frmReport_Load);
			this.pnlButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pnlButtons;
		private System.Windows.Forms.Button btnSaveAs;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.TextBox txtReport;
		private System.Windows.Forms.SaveFileDialog dlgSaveAs;
	}
}