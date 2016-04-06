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
	partial class frmCustomFilenameEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomFilenameEditor));
			this.txtPattern = new System.Windows.Forms.TextBox();
			this.lblLabels1 = new System.Windows.Forms.Label();
			this.tlbOptions = new System.Windows.Forms.ToolStrip();
			this.btnField = new System.Windows.Forms.ToolStripDropDownButton();
			this.mnuFieldFilename = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFieldExtension = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFieldLine1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuFieldGlobalCounter = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFieldLocalCounter = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFieldLine2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuFieldFoldername = new System.Windows.Forms.ToolStripMenuItem();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.tlbOptions.SuspendLayout();
			this.pnlButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtPattern
			// 
			this.txtPattern.AccessibleDescription = null;
			this.txtPattern.AccessibleName = null;
			resources.ApplyResources(this.txtPattern, "txtPattern");
			this.txtPattern.BackgroundImage = null;
			this.txtPattern.Font = null;
			this.txtPattern.Name = "txtPattern";
			// 
			// lblLabels1
			// 
			this.lblLabels1.AccessibleDescription = null;
			this.lblLabels1.AccessibleName = null;
			resources.ApplyResources(this.lblLabels1, "lblLabels1");
			this.lblLabels1.Font = null;
			this.lblLabels1.Name = "lblLabels1";
			// 
			// tlbOptions
			// 
			this.tlbOptions.AccessibleDescription = null;
			this.tlbOptions.AccessibleName = null;
			resources.ApplyResources(this.tlbOptions, "tlbOptions");
			this.tlbOptions.BackgroundImage = null;
			this.tlbOptions.Font = null;
			this.tlbOptions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tlbOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnField});
			this.tlbOptions.Name = "tlbOptions";
			// 
			// btnField
			// 
			this.btnField.AccessibleDescription = null;
			this.btnField.AccessibleName = null;
			resources.ApplyResources(this.btnField, "btnField");
			this.btnField.BackgroundImage = null;
			this.btnField.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFieldFilename,
            this.mnuFieldExtension,
            this.mnuFieldLine1,
            this.mnuFieldGlobalCounter,
            this.mnuFieldLocalCounter,
            this.mnuFieldLine2,
            this.mnuFieldFoldername});
			this.btnField.Name = "btnField";
			// 
			// mnuFieldFilename
			// 
			this.mnuFieldFilename.AccessibleDescription = null;
			this.mnuFieldFilename.AccessibleName = null;
			resources.ApplyResources(this.mnuFieldFilename, "mnuFieldFilename");
			this.mnuFieldFilename.BackgroundImage = null;
			this.mnuFieldFilename.Name = "mnuFieldFilename";
			this.mnuFieldFilename.ShortcutKeyDisplayString = null;
			this.mnuFieldFilename.Click += new System.EventHandler(this.mnuFieldFilename_Click);
			// 
			// mnuFieldExtension
			// 
			this.mnuFieldExtension.AccessibleDescription = null;
			this.mnuFieldExtension.AccessibleName = null;
			resources.ApplyResources(this.mnuFieldExtension, "mnuFieldExtension");
			this.mnuFieldExtension.BackgroundImage = null;
			this.mnuFieldExtension.Name = "mnuFieldExtension";
			this.mnuFieldExtension.ShortcutKeyDisplayString = null;
			this.mnuFieldExtension.Click += new System.EventHandler(this.mnuFieldExtension_Click);
			// 
			// mnuFieldLine1
			// 
			this.mnuFieldLine1.AccessibleDescription = null;
			this.mnuFieldLine1.AccessibleName = null;
			resources.ApplyResources(this.mnuFieldLine1, "mnuFieldLine1");
			this.mnuFieldLine1.Name = "mnuFieldLine1";
			// 
			// mnuFieldGlobalCounter
			// 
			this.mnuFieldGlobalCounter.AccessibleDescription = null;
			this.mnuFieldGlobalCounter.AccessibleName = null;
			resources.ApplyResources(this.mnuFieldGlobalCounter, "mnuFieldGlobalCounter");
			this.mnuFieldGlobalCounter.BackgroundImage = null;
			this.mnuFieldGlobalCounter.Name = "mnuFieldGlobalCounter";
			this.mnuFieldGlobalCounter.ShortcutKeyDisplayString = null;
			this.mnuFieldGlobalCounter.Click += new System.EventHandler(this.mnuFieldGlobalCounter_Click);
			// 
			// mnuFieldLocalCounter
			// 
			this.mnuFieldLocalCounter.AccessibleDescription = null;
			this.mnuFieldLocalCounter.AccessibleName = null;
			resources.ApplyResources(this.mnuFieldLocalCounter, "mnuFieldLocalCounter");
			this.mnuFieldLocalCounter.BackgroundImage = null;
			this.mnuFieldLocalCounter.Name = "mnuFieldLocalCounter";
			this.mnuFieldLocalCounter.ShortcutKeyDisplayString = null;
			this.mnuFieldLocalCounter.Click += new System.EventHandler(this.mnuFieldLocalCounter_Click);
			// 
			// mnuFieldLine2
			// 
			this.mnuFieldLine2.AccessibleDescription = null;
			this.mnuFieldLine2.AccessibleName = null;
			resources.ApplyResources(this.mnuFieldLine2, "mnuFieldLine2");
			this.mnuFieldLine2.Name = "mnuFieldLine2";
			// 
			// mnuFieldFoldername
			// 
			this.mnuFieldFoldername.AccessibleDescription = null;
			this.mnuFieldFoldername.AccessibleName = null;
			resources.ApplyResources(this.mnuFieldFoldername, "mnuFieldFoldername");
			this.mnuFieldFoldername.BackgroundImage = null;
			this.mnuFieldFoldername.Name = "mnuFieldFoldername";
			this.mnuFieldFoldername.ShortcutKeyDisplayString = null;
			this.mnuFieldFoldername.Click += new System.EventHandler(this.mnuFieldFoldername_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.AccessibleDescription = null;
			this.btnCancel.AccessibleName = null;
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.BackgroundImage = null;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = null;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.AccessibleDescription = null;
			this.btnOK.AccessibleName = null;
			resources.ApplyResources(this.btnOK, "btnOK");
			this.btnOK.BackgroundImage = null;
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Font = null;
			this.btnOK.Name = "btnOK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// pnlButtons
			// 
			this.pnlButtons.AccessibleDescription = null;
			this.pnlButtons.AccessibleName = null;
			resources.ApplyResources(this.pnlButtons, "pnlButtons");
			this.pnlButtons.BackgroundImage = null;
			this.pnlButtons.Controls.Add(this.tlbOptions);
			this.pnlButtons.Font = null;
			this.pnlButtons.Name = "pnlButtons";
			// 
			// frmCustomFilenameEditor
			// 
			this.AcceptButton = this.btnOK;
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.pnlButtons);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lblLabels1);
			this.Controls.Add(this.txtPattern);
			this.Font = null;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = null;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCustomFilenameEditor";
			this.ShowInTaskbar = false;
			this.Load += new System.EventHandler(this.frmCustomFilenameEditor_Load);
			this.tlbOptions.ResumeLayout(false);
			this.tlbOptions.PerformLayout();
			this.pnlButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtPattern;
		private System.Windows.Forms.Label lblLabels1;
		private System.Windows.Forms.ToolStrip tlbOptions;
		private System.Windows.Forms.ToolStripDropDownButton btnField;
		private System.Windows.Forms.ToolStripMenuItem mnuFieldFilename;
		private System.Windows.Forms.ToolStripMenuItem mnuFieldExtension;
		private System.Windows.Forms.ToolStripSeparator mnuFieldLine1;
		private System.Windows.Forms.ToolStripMenuItem mnuFieldGlobalCounter;
		private System.Windows.Forms.ToolStripMenuItem mnuFieldLocalCounter;
		private System.Windows.Forms.ToolStripSeparator mnuFieldLine2;
		private System.Windows.Forms.ToolStripMenuItem mnuFieldFoldername;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Panel pnlButtons;
	}
}