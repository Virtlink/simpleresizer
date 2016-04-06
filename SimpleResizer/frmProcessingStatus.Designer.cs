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
	partial class frmProcessingStatus
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcessingStatus));
			this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pnlInteractionArea = new System.Windows.Forms.Panel();
			this.pnlProgressBar = new System.Windows.Forms.Panel();
			this.prbProgress = new System.Windows.Forms.ProgressBar();
			this.pnlContent = new System.Windows.Forms.Panel();
			this.lblContent = new System.Windows.Forms.LinkLabel();
			this.pnlInstruction = new System.Windows.Forms.Panel();
			this.lblInstruction = new System.Windows.Forms.Label();
			this.pctIcon = new System.Windows.Forms.PictureBox();
			this.bgwProcessor = new System.ComponentModel.BackgroundWorker();
			this.pnlButtons.SuspendLayout();
			this.pnlInteractionArea.SuspendLayout();
			this.pnlProgressBar.SuspendLayout();
			this.pnlContent.SuspendLayout();
			this.pnlInstruction.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pctIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlButtons
			// 
			this.pnlButtons.AccessibleDescription = null;
			this.pnlButtons.AccessibleName = null;
			resources.ApplyResources(this.pnlButtons, "pnlButtons");
			this.pnlButtons.BackgroundImage = null;
			this.pnlButtons.Controls.Add(this.btnCancel);
			this.pnlButtons.Font = null;
			this.pnlButtons.Name = "pnlButtons";
			// 
			// btnCancel
			// 
			this.btnCancel.AccessibleDescription = null;
			this.btnCancel.AccessibleName = null;
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.BackgroundImage = null;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = null;
			this.btnCancel.MaximumSize = new System.Drawing.Size(0, 27);
			this.btnCancel.MinimumSize = new System.Drawing.Size(79, 27);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// pnlInteractionArea
			// 
			this.pnlInteractionArea.AccessibleDescription = null;
			this.pnlInteractionArea.AccessibleName = null;
			resources.ApplyResources(this.pnlInteractionArea, "pnlInteractionArea");
			this.pnlInteractionArea.BackColor = System.Drawing.SystemColors.Window;
			this.pnlInteractionArea.BackgroundImage = null;
			this.pnlInteractionArea.Controls.Add(this.pnlProgressBar);
			this.pnlInteractionArea.Controls.Add(this.pnlContent);
			this.pnlInteractionArea.Font = null;
			this.pnlInteractionArea.Name = "pnlInteractionArea";
			// 
			// pnlProgressBar
			// 
			this.pnlProgressBar.AccessibleDescription = null;
			this.pnlProgressBar.AccessibleName = null;
			resources.ApplyResources(this.pnlProgressBar, "pnlProgressBar");
			this.pnlProgressBar.BackgroundImage = null;
			this.pnlProgressBar.Controls.Add(this.prbProgress);
			this.pnlProgressBar.Font = null;
			this.pnlProgressBar.Name = "pnlProgressBar";
			// 
			// prbProgress
			// 
			this.prbProgress.AccessibleDescription = null;
			this.prbProgress.AccessibleName = null;
			resources.ApplyResources(this.prbProgress, "prbProgress");
			this.prbProgress.BackgroundImage = null;
			this.prbProgress.Font = null;
			this.prbProgress.Name = "prbProgress";
			this.prbProgress.Value = 50;
			// 
			// pnlContent
			// 
			this.pnlContent.AccessibleDescription = null;
			this.pnlContent.AccessibleName = null;
			resources.ApplyResources(this.pnlContent, "pnlContent");
			this.pnlContent.BackgroundImage = null;
			this.pnlContent.Controls.Add(this.lblContent);
			this.pnlContent.Font = null;
			this.pnlContent.Name = "pnlContent";
			// 
			// lblContent
			// 
			this.lblContent.AccessibleDescription = null;
			this.lblContent.AccessibleName = null;
			resources.ApplyResources(this.lblContent, "lblContent");
			this.lblContent.Font = null;
			this.lblContent.MaximumSize = new System.Drawing.Size(414, 0);
			this.lblContent.Name = "lblContent";
			// 
			// pnlInstruction
			// 
			this.pnlInstruction.AccessibleDescription = null;
			this.pnlInstruction.AccessibleName = null;
			resources.ApplyResources(this.pnlInstruction, "pnlInstruction");
			this.pnlInstruction.BackColor = System.Drawing.SystemColors.Window;
			this.pnlInstruction.BackgroundImage = null;
			this.pnlInstruction.Controls.Add(this.lblInstruction);
			this.pnlInstruction.Controls.Add(this.pctIcon);
			this.pnlInstruction.Font = null;
			this.pnlInstruction.Name = "pnlInstruction";
			this.pnlInstruction.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInstruction_Paint);
			// 
			// lblInstruction
			// 
			this.lblInstruction.AccessibleDescription = null;
			this.lblInstruction.AccessibleName = null;
			resources.ApplyResources(this.lblInstruction, "lblInstruction");
			this.lblInstruction.AutoEllipsis = true;
			this.lblInstruction.BackColor = System.Drawing.Color.Transparent;
			this.lblInstruction.MaximumSize = new System.Drawing.Size(371, 0);
			this.lblInstruction.Name = "lblInstruction";
			// 
			// pctIcon
			// 
			this.pctIcon.AccessibleDescription = null;
			this.pctIcon.AccessibleName = null;
			resources.ApplyResources(this.pctIcon, "pctIcon");
			this.pctIcon.BackColor = System.Drawing.Color.Transparent;
			this.pctIcon.BackgroundImage = null;
			this.pctIcon.Font = null;
			this.pctIcon.ImageLocation = null;
			this.pctIcon.Name = "pctIcon";
			this.pctIcon.TabStop = false;
			// 
			// bgwProcessor
			// 
			this.bgwProcessor.WorkerReportsProgress = true;
			this.bgwProcessor.WorkerSupportsCancellation = true;
			this.bgwProcessor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwProcessor_DoWork);
			this.bgwProcessor.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwProcessor_RunWorkerCompleted);
			this.bgwProcessor.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwProcessor_ProgressChanged);
			// 
			// frmProcessingStatus
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.CancelButton = this.btnCancel;
			this.ControlBox = false;
			this.Controls.Add(this.pnlButtons);
			this.Controls.Add(this.pnlInteractionArea);
			this.Controls.Add(this.pnlInstruction);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = null;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmProcessingStatus";
			this.Load += new System.EventHandler(this.frmProcessingStatus_Load);
			this.pnlButtons.ResumeLayout(false);
			this.pnlButtons.PerformLayout();
			this.pnlInteractionArea.ResumeLayout(false);
			this.pnlInteractionArea.PerformLayout();
			this.pnlProgressBar.ResumeLayout(false);
			this.pnlContent.ResumeLayout(false);
			this.pnlContent.PerformLayout();
			this.pnlInstruction.ResumeLayout(false);
			this.pnlInstruction.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pctIcon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel pnlButtons;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel pnlInteractionArea;
		private System.Windows.Forms.Panel pnlProgressBar;
		private System.Windows.Forms.ProgressBar prbProgress;
		private System.Windows.Forms.Panel pnlContent;
		private System.Windows.Forms.LinkLabel lblContent;
		private System.Windows.Forms.Panel pnlInstruction;
		private System.Windows.Forms.Label lblInstruction;
		private System.Windows.Forms.PictureBox pctIcon;
		private System.ComponentModel.BackgroundWorker bgwProcessor;
	}
}