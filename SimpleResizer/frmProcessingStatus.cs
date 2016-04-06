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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using SimpleResizer.Properties;

namespace SimpleResizer
{
	/// <summary>
	/// Shows the status of the process.
	/// </summary>
	public partial class frmProcessingStatus : Form
	{
		#region Fields
		// FIXME: Get these colors from some visual style or something.
		// Don't know if they are defined anywhere in a theme.
		private Color m_fColor_Accept_Start = Color.FromArgb(0x15, 0x76, 0x15);
		private Color m_fColor_Accept_End = Color.FromArgb(0x39, 0x96, 0x3F);
		private Color m_fColor_Accept_Text = Color.FromArgb(0xFF, 0xFF, 0xFF);

		private Color m_fColor_Warning_Start = Color.FromArgb(0xF2, 0xB1, 0x00);
		private Color m_fColor_Warning_End = Color.FromArgb(0xFE, 0xCD, 0x48);
		private Color m_fColor_Warning_Text = Color.FromArgb(0x00, 0x00, 0x00);

		private Color m_fColor_Stop_Start = Color.FromArgb(0xAC, 0x01, 0x00);
		private Color m_fColor_Stop_End = Color.FromArgb(0xE3, 0x01, 0x00);
		private Color m_fColor_Stop_Text = Color.FromArgb(0xFF, 0xFF, 0xFF);

		private Color m_fColor_Blue_Start = Color.FromArgb(0x04, 0x50, 0x82);
		private Color m_fColor_Blue_End = Color.FromArgb(0x1C, 0x78, 0x85);
		private Color m_fColor_Blue_Text = Color.FromArgb(0xFF, 0xFF, 0xFF);

		private Color m_fColor_Gray_Start = Color.FromArgb(0x9D, 0x8F, 0x85);
		private Color m_fColor_Gray_End = Color.FromArgb(0xA4, 0x98, 0x90);
		private Color m_fColor_Gray_Text = Color.FromArgb(0xFF, 0xFF, 0xFF);

		private CurrentProcess _eProcessPrevious = CurrentProcess.None;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="frmProcessingStatus"/> class.
		/// </summary>
		/// <param name="batch">The <see cref="Batch"/> to process.</param>
		public frmProcessingStatus(Batch batch)
		{
			if (batch == null)
				throw new ArgumentNullException("batch");
			m_bBatch = batch;

			InitializeComponent();

			lblInstruction.ForeColor = m_fColor_Blue_Text;
		}
		#endregion

		#region Properties
		private Batch m_bBatch;
		/// <summary>
		/// Gets the <see cref="Batch"/> which will be processed.
		/// </summary>
		/// <value>A <see cref="Batch"/>.</value>
		public Batch Batch
		{
			get { return m_bBatch; }
		}
		#endregion

		#region Methods
		/// <summary>
		/// Starts the processing of the <see cref="Batch"/>.
		/// </summary>
		public void StartProcessing()
		{
			bgwProcessor.RunWorkerAsync(this.Batch);
		}

		/// <summary>
		/// Cancels the processing of the <see cref="Batch"/>.
		/// </summary>
		public void CancelProcessing()
		{
			bgwProcessor.CancelAsync();
		}
		#endregion

		#region Event Overrides
		/// <summary>
		/// Raises the <see cref="E:Resize"/> event.
		/// </summary>
		/// <param name="e">The <see cref="EventArgs"/> instance
		/// containing the event data.</param>
		protected override void OnResize(EventArgs e)
		{
			lblInstruction.MaximumSize = new Size(this.Width - lblInstruction.Left - 6, 0);
			lblContent.MaximumSize = new Size(this.Width - lblContent.Left - pnlInteractionArea.Padding.Left - 6, 0);
			this.Height = pnlButtons.Top + pnlButtons.Height + 2 * SystemInformation.FrameBorderSize.Height + SystemInformation.CaptionHeight;

			base.OnResize(e);
		}
		#endregion

		#region Event Handlers
		private void frmProcessingStatus_Load(object sender, EventArgs e)
		{
			StartProcessing();
		}

		private void bgwProcessor_DoWork(object sender, DoWorkEventArgs e)
		{
			Batch batch = (Batch)e.Argument;
			BatchProcessor processor = new BatchProcessor(batch, bgwProcessor, e);
			processor.Process();
		}

		private void bgwProcessor_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// Go to the next step.
			if (e.Error == null && !e.Cancelled && e.Result != null)
			{
				// Everything went normal.
				// TODO: Show a report or something.
				BatchProcessor processor = (BatchProcessor)e.Result;
				MessageBox.Show(this, Resources.MsgProcessFinished, Resources.MsgProcessFinishedTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
			else if (e.Cancelled)
			{
				// Cancelled.
				// TODO: Do something.
				MessageBox.Show(this, Resources.MsgProcessCancelled, Resources.MsgProcessCancelledTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
				this.Close();
			}
			else if (e.Error != null)
			{
				// TODO: Do something with this error.
				throw e.Error;
			}
			else
			{
				// TODO: Do something, since we've got no results.
				MessageBox.Show(this, Resources.MsgProcessError, Resources.MsgProcessErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
				this.Close();
			}
		}

		private void bgwProcessor_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			BatchProcessor processor = (BatchProcessor)e.UserState;
			if (e.ProgressPercentage >= prbProgress.Minimum &&
				e.ProgressPercentage <= prbProgress.Maximum)
				prbProgress.Value = e.ProgressPercentage;
			switch (processor.CurrentProcess)
			{
				case CurrentProcess.Collecting:
					this.Text = Resources.MsgStatusCollectingTitle;
					lblInstruction.Text = String.Format(Resources.MsgStatusCollectingInstr, processor.TotalItems);
					lblContent.Text = String.Format(Resources.MsgStatusCollectingContent, (processor.CurrentItem != null ? processor.CurrentItem.Name : Resources.MsgStatusItemUnknown), processor.CurrentItemIndex + 1, processor.Statistics["Collected"]);
					break;
				case CurrentProcess.Validating:
					this.Text = Resources.MsgStatusValidatingTitle;
					lblInstruction.Text = String.Format(Resources.MsgStatusValidatingInstr, processor.TotalItems);
					lblContent.Text = String.Format(Resources.MsgStatusValidatingContent, processor.CurrentItemIndex + 1, processor.Statistics["DuplicateItems"] + processor.Statistics["NonExistantItems"] + processor.Statistics["ExistingTargetItems"] + processor.Statistics["ClashItems"]);
					break;
				case CurrentProcess.Processing:
					this.Text = Resources.MsgStatusProcessingTitle;
					lblInstruction.Text = String.Format(Resources.MsgStatusProcessingInstr, processor.TotalItems);
					lblContent.Text = String.Format(Resources.MsgStatusProcessingContent, (processor.CurrentItem != null ? processor.CurrentItem.Name : Resources.MsgStatusItemUnknown), processor.CurrentItemIndex + 1, processor.Statistics["Skipped"]);
					break;
				default:
					this.Text = Resources.MsgStatusTitle;
					lblInstruction.Text = String.Format(Resources.MsgStatusInstr, processor.TotalItems);
					lblContent.Text = Resources.MsgStatusContent;
					break;
			}
			if (processor.CurrentProcess != _eProcessPrevious)
			{
				_eProcessPrevious = processor.CurrentProcess;
				OnResize(EventArgs.Empty);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			CancelProcessing();
		}

		private void pnlInstruction_Paint(object sender, PaintEventArgs e)
		{
			LinearGradientBrush gradient = new LinearGradientBrush(
				pnlInstruction.ClientRectangle,
				m_fColor_Blue_Start,
				m_fColor_Blue_End,
				LinearGradientMode.Horizontal);
			e.Graphics.FillRectangle(gradient, pnlInstruction.ClientRectangle);
		}
		#endregion
	}
}