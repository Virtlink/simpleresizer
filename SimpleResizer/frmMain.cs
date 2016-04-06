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
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using SimpleResizer.Properties;

namespace SimpleResizer
{
	/// <summary>
	/// The main form.
	/// </summary>
	public partial class frmMain : Form
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="frmMain"/> class.
		/// </summary>
		public frmMain()
		{
			InitializeComponent();
			m_xBatch = new Batch();
		}
		#endregion

		#region Properties
		private Batch m_xBatch = null;
		/// <summary>
		/// Gets or sets the currently loaded <see cref="Batch"/>.
		/// </summary>
		public Batch Batch
		{
			get { return m_xBatch; }
			set { m_xBatch = value; }
		}
		#endregion

		#region Methods
		/// <summary>
		/// Sets the listview to the specified <see cref="View"/>.
		/// </summary>
		/// <param name="view">The <see cref="View"/>.</param>
		private void SetView(View view)
		{
			lstItems.BeginUpdate();
			if (lstItems.LargeImageList != imlTile && view == View.Tile)
				lstItems.LargeImageList = imlTile;
			else if (lstItems.LargeImageList != imlNormal && view != View.Tile)
				lstItems.LargeImageList = imlNormal;
			lstItems.View = view;
			lstItems.EndUpdate();
			mnuViewLargeIcons.Checked = (view == View.LargeIcon);
			mnuViewTile.Checked = (view == View.Tile);
			mnuViewDetails.Checked = (view == View.Details);
			mnuViewList.Checked = (view == View.List);
			if (mnuViewLargeIcons.Checked)
				btnView.Image = mnuViewLargeIcons.Image;
			else if (mnuViewTile.Checked)
				btnView.Image = mnuViewTile.Image;
			else if (mnuViewDetails.Checked)
				btnView.Image = mnuViewDetails.Image;
			else
				btnView.Image = mnuViewList.Image;
		}

		/// <summary>
		/// Sets the value of the item counter in the status bar.
		/// </summary>
		public void SetItemCounter()
		{
			lblFileCount.Text = String.Format(Resources.StatusBarItemCount, Batch.BatchFileCount, Batch.BatchFolderCount);
		}

		/// <summary>
		/// Lets the user select files to add.
		/// </summary>
		public void UserAddFiles()
		{
			if (dlgAddFiles.ShowDialog(this) == DialogResult.OK)
			{
				BatchFile[] files = new BatchFile[dlgAddFiles.FileNames.Length];
				// TODO: Sort the files.
				for (int q = 0; q < dlgAddFiles.FileNames.Length; q++)
				{
					files[q] = new BatchFile(new FileInfo(dlgAddFiles.FileNames[q]));
					this.Batch.Add(files[q]);
				}
				AddItemsToList(files);
			}
			SetItemCounter();
		}

		/// <summary>
		/// Lets the user select a folder to add.
		/// </summary>
		public void UserAddFolder()
		{
			if (dlgAddFolder.ShowDialog(this) == DialogResult.OK)
			{
				BatchFolder folder = new BatchFolder(new DirectoryInfo(dlgAddFolder.SelectedPath));
				this.Batch.Add(folder);
				AddItemsToList(new BatchItem[] { folder });
			}
			SetItemCounter();
		}

		/// <summary>
		/// Lets the user remove the currently selected items.
		/// </summary>
		public void UserRemove()
		{
			foreach (ListViewItem item in lstItems.SelectedItems)
			{
				this.Batch.Remove((BatchItem)item.Tag);
				item.Remove();
			}
			SetItemCounter();
		}

		/// <summary>
		/// Lets the user clear the project.
		/// </summary>
		public void UserClearAll()
		{
			if (MessageBox.Show(this, Resources.MsgProjectClearAll, Resources.MsgProjectClearAllTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
				return;
			lstItems.Items.Clear();
			this.Batch.Clear();
			SetItemCounter();
			Preview();
		}

		/// <summary>
		/// Loads the settings previously saved when this application
		/// was closed.
		/// </summary>
		private void LoadSettings()
		{
			// Load settings.
			this.Location = Settings.Default.MainFormLocation;
			this.Size = Settings.Default.MainFormSize;
			this.WindowState = Settings.Default.MainFormState;

			numWidth.Value = Settings.Default.BatchMaxWidth;
			numHeight.Value = Settings.Default.BatchMaxHeight;
			trbQuality.Value = Settings.Default.BatchQuality;
			chkUseStamp.Checked = Settings.Default.BatchUseStamp;
			txtStampFile.Text = Settings.Default.BatchStampFile;
			switch (Settings.Default.BatchStampPlacement)
			{
				case (int)StampPlacement.Scale:
					optSizeToFit.Checked = true; break;
				case (int)StampPlacement.Stretch:
					optStretchToFit.Checked = true; break;
				case (int)StampPlacement.TopLeft:
					optTopLeft.Checked = true; break;
				case (int)StampPlacement.Top:
					optTop.Checked = true; break;
				case (int)StampPlacement.TopRight:
					optTopRight.Checked = true; break;
				case (int)StampPlacement.Left:
					optLeft.Checked = true; break;
				case (int)StampPlacement.Center:
					optCenter.Checked = true; break;
				case (int)StampPlacement.Right:
					optRight.Checked = true; break;
				case (int)StampPlacement.BottomLeft:
					optBottomLeft.Checked = true; break;
				case (int)StampPlacement.Bottom:
					optBottom.Checked = true; break;
				case (int)StampPlacement.BottomRight:
					optBottomRight.Checked = true; break;
				default:
					goto case (int)StampPlacement.Scale;
			}
			numHorizontalMargin.Value = Settings.Default.BatchStampHMargin;
			numVerticalMargin.Value = Settings.Default.BatchStampVMargin;
			trbTransparency.Value = Settings.Default.BatchTransparency;
			chkUseSourceFolder.Checked = Settings.Default.BatchUseSourceFolder;
			chkCreateSubfolders.Checked = Settings.Default.BatchCreateSubFolders;
			txtFolder.Text = Settings.Default.BatchDestFolder;
			dlgAddFiles.InitialDirectory = Settings.Default.MainFormLastAddedFilesDirectory;
			dlgAddFolder.SelectedPath = Settings.Default.MainFormLastAddedDirectory;
			txtNewFilenameStart.Text = Settings.Default.MainFormNewFilenameStart;
			txtNewFilenameEnd.Text = Settings.Default.MainFormNewFilenameEnd;
			txtNewFilename.Text = Settings.Default.BatchNewFilenamePattern;
			SetNewFilenameSimple(Settings.Default.MainFormNewFilenameSimple);
			optNewFilenameSimple.Checked = Settings.Default.MainFormNewFilenameSimple;
			optNewFilenameAdvanced.Checked = !Settings.Default.MainFormNewFilenameSimple;
			SetView(Settings.Default.MainFormListView);
		}

		/// <summary>
		/// Executes the batch.
		/// </summary>
		private void ProcessBatch()
		{
			if (chkUseStamp.Checked &&
				(txtStampFile.Text.Trim().Length == 0 || !File.Exists(txtStampFile.Text)))
			{
				MessageBox.Show(this, String.Format(Resources.MsgProjectStampNotFound, (txtStampFile.Text.Trim().Length == 0 ? "" : Path.GetFileName(txtStampFile.Text)), txtStampFile.Text),
					Resources.MsgProjectStampNotFoundTitle, MessageBoxButtons.OK,
					MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}
			if (!chkUseSourceFolder.Checked &&
				(txtFolder.Text.Trim().Length == 0 || !Directory.Exists(txtFolder.Text)))
			{
				MessageBox.Show(this, String.Format(Resources.MsgProjectDestFolderNotFound, txtFolder.Text),
					Resources.MsgProjectDestFolderNotFoundTitle, MessageBoxButtons.OK,
					MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}
			if (!ValidFilenamePattern(txtNewFilename.Text))
			{
				MessageBox.Show(this, String.Format(Resources.MsgProjectNewFilenamePatternInvalid, txtNewFilename.Text),
					Resources.MsgProjectNewFilenamePatternInvalidTitle, MessageBoxButtons.OK,
					MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}
			if (!GivesMultipleFilenamePattern(txtNewFilename.Text))
			{
				MessageBox.Show(this, String.Format(Resources.MsgProjectNewFilenamePatternYieldsSingleFilename, txtNewFilename.Text),
					Resources.MsgProjectNewFilenamePatternYieldsSingleFilenameTitle, MessageBoxButtons.OK,
					MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}

			SetBatchProcessSettings();
			frmProcessingStatus status = new frmProcessingStatus(this.Batch);
			status.ShowDialog(this);
		}

		/// <summary>
		/// Gets whether the given filename pattern gives multiple
		/// filenames or always the same filename. The parent-folder
		/// fields, the local counter fields and the extension fields
		/// are ignored.
		/// </summary>
		/// <param name="pattern">The pattern.</param>
		/// <returns><see cref="true"/> when this pattern gives multiple
		/// filenames; otherwise, <see cref="false"/>.</returns>
		private bool GivesMultipleFilenamePattern(string pattern)
		{
			return pattern.Contains("%n") || pattern.Contains("%c");
		}

		/// <summary>
		/// Gets whether the given filename pattern is valid
		/// (i.e. does not contain any invalid fields).
		/// </summary>
		/// <param name="pattern">The pattern.</param>
		/// <returns><see cref="true"/> when this pattern is valid;
		/// otherwise, <see cref="false"/>.</returns>
		private bool ValidFilenamePattern(string pattern)
		{
			StringBuilder sb = new StringBuilder(pattern);

			// %n	Bestandsnaam
			sb.Replace("%n", string.Empty);
			// %e	Extentie
			sb.Replace("%e", string.Empty);

			//// %f	Parent mapnaam
			//sb.Replace("%f", String.Empty);

			// %c#	Globale teller (# = aantal cijfers, 0 = zoveel als nodig)
			sb.Replace("%c0", string.Empty);
			for (int q = 1; q <= 9; q++)
			{ sb.Replace("%c" + q.ToString(), string.Empty); }
			sb.Replace("%c", string.Empty);
			

			// %i#	Lokale teller (per map) (# = aantal cijfers, 0 = zoveel als nodig)
			sb.Replace("%i0", string.Empty);
			for (int q = 1; q <= 9; q++)
			{ sb.Replace("%i" + q.ToString(), string.Empty); }
			sb.Replace("%i", string.Empty);

			sb.Replace("%%", string.Empty);

			// Any %-signs left in this filename pattern indicate
			// an invalid field.
			return !sb.ToString().Contains("%");
		}

		/// <summary>
		/// Shows a preview image of the currently selected file.
		/// </summary>
		private void Preview()
		{
			if (lstItems.SelectedItems.Count == 1 && lstItems.SelectedItems[0].Tag is BatchFile)
			{
				pctPreview.SizeMode = PictureBoxSizeMode.Zoom;
				PreviewFile((BatchItem)lstItems.SelectedItems[0].Tag);
			}
			else if (lstItems.SelectedItems.Count == 1)
			{
				pctPreview.SizeMode = PictureBoxSizeMode.CenterImage;
				lblPreviewName.Text = string.Empty;
				//lblPreviewName.Text = ((BatchFolder)lstItems.SelectedItems[0].Tag).Name;
				pctPreview.Image = Resources.FolderOpenBig;
			}
			else if (lstItems.SelectedItems.Count > 1)
			{
				pctPreview.SizeMode = PictureBoxSizeMode.CenterImage;
				lblPreviewName.Text = string.Empty;
				pctPreview.Image = Resources.MultiFilesBig;
			}
			else
			{
				lblPreviewName.Text = string.Empty;
				pctPreview.Image = null;
			}
		}

		/// <summary>
		/// Sets a preview image for a single <see cref="BatchItem"/>.
		/// </summary>
		/// <param name="item">The <see cref="BatchItem"/>.</param>
		private void PreviewFile(BatchItem item)
		{
			if (bgWorker.IsBusy)
			{ bgWorker.CancelAsync(); }
			while (bgWorker.IsBusy)
			{ Application.DoEvents(); }
			//prbPreviewProgress.Visible = false;
			SetBatchProcessSettings();
			if (item != null)
			{
				//prbPreviewProgress.Visible = true;
				lblPreviewName.Text = Resources.MainFormPreviewWait;
				bgWorker.RunWorkerAsync(item);
			}
		}

		/// <summary>
		/// Sets the user selected settings on the <see cref="Batch"/> object.
		/// </summary>
		private void SetBatchProcessSettings()
		{
			BatchProcessSettings s = this.Batch.Settings;
			s.MaxWidth = (int)numWidth.Value;
			s.MaxHeight = (int)numHeight.Value;
			s.Quality = trbQuality.Value;
			s.NewFilenamePattern = txtNewFilename.Text;
			if (chkUseSourceFolder.Checked)
				s.DestinationFolder = null;
			else
			{
				try { s.DestinationFolder = new DirectoryInfo(txtFolder.Text); }
				catch { s.DestinationFolder = null; }
				s.CreateSubFolders = chkCreateSubfolders.Checked;
			}
			if (chkUseStamp.Checked)
			{
				try { s.StampFile = new FileInfo(txtStampFile.Text); }
				catch { s.StampFile = null; }
				if (s.StampFile != null)
				{
					if (optSizeToFit.Checked) s.StampPlacement = StampPlacement.Scale;
					else if (optStretchToFit.Checked) s.StampPlacement = StampPlacement.Stretch;
					else if (optTopLeft.Checked) s.StampPlacement = StampPlacement.TopLeft;
					else if (optTop.Checked) s.StampPlacement = StampPlacement.Top;
					else if (optTopRight.Checked) s.StampPlacement = StampPlacement.TopRight;
					else if (optLeft.Checked) s.StampPlacement = StampPlacement.Left;
					else if (optCenter.Checked) s.StampPlacement = StampPlacement.Center;
					else if (optRight.Checked) s.StampPlacement = StampPlacement.Right;
					else if (optBottomLeft.Checked) s.StampPlacement = StampPlacement.BottomLeft;
					else if (optBottom.Checked) s.StampPlacement = StampPlacement.Bottom;
					else if (optBottomRight.Checked) s.StampPlacement = StampPlacement.BottomRight;
					s.HorizontalDistance = (int)numHorizontalMargin.Value;
					s.VerticalDistance = (int)numVerticalMargin.Value;
					s.StampTransparency = ((float)trbTransparency.Value) / 100f;
				}
			}
			else
				s.StampFile = null;
		}

		/// <summary>
		/// Adds the specified <see cref="BatchItem"/> objects
		/// to the list.
		/// </summary>
		/// <param name="items">The <see cref="BatchItem"/> objects
		/// to add.</param>
		public void AddItemsToList(BatchItem[] items)
		{
			lstItems.BeginUpdate();
			foreach (BatchItem itm in items)
			{
				ListViewItem lvi = null;
				if (itm is BatchFile)
				{
					lvi = new ListViewItem(itm.Name, lstItems.Groups["files"]);
					lvi.Tag = itm;
					switch (Path.GetExtension(itm.Name).ToLower())
					{
						case ".jpg":
						case ".jpeg":
							lvi.ImageIndex = 3;
							break;
						case ".png":
							lvi.ImageIndex = 4;
							break;
						case ".bmp":
							lvi.ImageIndex = 5;
							break;
						case ".gif":
							lvi.ImageIndex = 6;
							break;
						default:
							lvi.ImageIndex = 7;
							break;
					}
					//lvi.SubItems.Add(this.Batch.IndexOf(itm).ToString());
					lvi.SubItems.Add(((BatchFile)itm).File.DirectoryName);
				}
				else if (itm is BatchFolder)
				{
					lvi = new ListViewItem(itm.Name, lstItems.Groups["folders"]);
					lvi.Tag = itm;
					lvi.ImageIndex = 0;
					//lvi.SubItems.Add(this.Batch.IndexOf(itm).ToString());
					if (((BatchFolder)itm).Directory.Parent != null)
						lvi.SubItems.Add(((BatchFolder)itm).Directory.Parent.FullName);
					else
						lvi.SubItems.Add(string.Empty);
				}
				if (lvi != null)
					lstItems.Items.Add(lvi);
				else
					throw new InvalidOperationException("Unknown type: " + itm.GetType().FullName);
			}
			lstItems.EndUpdate();
		}

		private void SetNewFilenameSimple(bool simple)
		{
			//if (optNewFilenameSimple.Checked != simple)
			//    optNewFilenameSimple.Checked = simple;
			//if (optNewFilenameAdvanced.Checked != !simple)
			//    optNewFilenameAdvanced.Checked = !simple;
			txtNewFilenameStart.Enabled = simple;
			txtNewFilenameEnd.Enabled = simple;
			lblLabels15.Enabled = simple;
			//lblNewFilenameExample.Visible = simple;
			txtNewFilename.Enabled = !simple;
			btnEditName.Enabled = !simple;
			if (optNewFilenameSimple.Checked)
				txtNewFilenameStart_TextChanged(this, EventArgs.Empty);
		}
		#endregion

		#region Event Handlers
		/// <summary>
		/// Handles the Load event of the frmMain control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void frmMain_Load(object sender, EventArgs e)
		{
			Version v = new Version(Application.ProductVersion);
			Text = String.Format(Resources.MainFormTitle, Application.CompanyName, Application.ProductName, v.Major, v.Minor, v.Build, v.Revision);
			LoadSettings();
			SetItemCounter();
		}

		/// <summary>
		/// Handles the Resize event of the pctPreview control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void pctPreview_Resize(object sender, EventArgs e)
		{
			prbPreviewProgress.Location = new Point(
				(pctPreview.ClientRectangle.Width - prbPreviewProgress.Width) / 2,
				(pctPreview.ClientRectangle.Height - prbPreviewProgress.Height) / 2);
		}

		/// <summary>
		/// Handles the Click event of the btnExecute control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnExecute_Click(object sender, EventArgs e)
		{ ProcessBatch(); }

		/// <summary>
		/// Handles the DoWork event of the bgWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
		private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			BatchItem item = (BatchItem)e.Argument;

			BatchProcessor processor = new BatchProcessor(item, bgWorker, e);
			PreviewResult preview = processor.Preview();

			if (preview.PreviewImage == null)
			{ e.Cancel = true; return; }
			e.Result = preview;
		}

		/// <summary>
		/// Handles the ProgressChanged event of the bgWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.ProgressChangedEventArgs"/> instance containing the event data.</param>
		private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{ }
		//{ prbPreviewProgress.Value = e.ProgressPercentage; }

		/// <summary>
		/// Handles the RunWorkerCompleted event of the bgWorker control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
		private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//prbPreviewProgress.Visible = false;
			if (e.Cancelled)
			{
				pctPreview.Image = null;
				lblPreviewName.Text = string.Empty;
			}
			else
			{
				PreviewResult result = (PreviewResult)e.Result;
				if (result.PreviewImage != null)
					pctPreview.Image = result.PreviewImage;
				lblPreviewName.Text = string.Empty;
				//if (result.NewFilename != null)
				//    lblPreviewName.Text = Path.GetFileName(result.NewFilename);
			}
		}

		#region Interaction
		private void mnuProjectAddFiles_Click(object sender, EventArgs e)
		{ UserAddFiles(); }

		private void mnuProjectAddFolder_Click(object sender, EventArgs e)
		{ UserAddFolder(); }

		private void mnuProjectRemove_Click(object sender, EventArgs e)
		{ UserRemove(); }

		private void mnuProjectClearAll_Click(object sender, EventArgs e)
		{ UserClearAll(); }

		private void mnuClearAll_Click(object sender, EventArgs e)
		{ UserClearAll(); }

		private void mnuRemoveItems_Click(object sender, EventArgs e)
		{ UserRemove(); }

		private void btnAddFiles_Click(object sender, EventArgs e)
		{ UserAddFiles(); }

		private void btnAddFolder_Click(object sender, EventArgs e)
		{ UserAddFolder(); }

		private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
		{ Preview(); }

		private void btnRemove_ButtonClick(object sender, EventArgs e)
		{ UserRemove(); }

		private void mnuFileExit_Click(object sender, EventArgs e)
		{ this.Close(); }

		private void mnuItemsRemove_Click(object sender, EventArgs e)
		{ UserRemove(); }

		private void mnuRemoveRemove_Click(object sender, EventArgs e)
		{ UserRemove(); }

		private void mnuRemoveClearAll_Click(object sender, EventArgs e)
		{ UserClearAll(); }

		private void mnuItemsRemove_Click_1(object sender, EventArgs e)
		{ UserRemove(); }

		private void btnView_ButtonClick(object sender, EventArgs e)
		{
			switch (lstItems.View)
			{
				case View.LargeIcon:
					SetView(View.Tile);
					break;
				case View.Tile:
					SetView(View.Details);
					break;
				case View.Details:
					SetView(View.List);
					break;
				default:
					SetView(View.LargeIcon);
					break;
			}
		}

		private void mnuViewTile_Click(object sender, EventArgs e)
		{ SetView(View.Tile); }

		private void mnuViewLargeIcons_Click(object sender, EventArgs e)
		{ SetView(View.LargeIcon); }

		private void mnuViewList_Click(object sender, EventArgs e)
		{ SetView(View.List); }

		private void mnuViewDetails_Click(object sender, EventArgs e)
		{ SetView(View.Details); }

		private void optNewFilenameSimple_CheckedChanged(object sender, EventArgs e)
		{
			SetNewFilenameSimple(optNewFilenameSimple.Checked);
		}

		private void optNewFilenameAdvanced_CheckedChanged(object sender, EventArgs e)
		{
			SetNewFilenameSimple(!optNewFilenameAdvanced.Checked);
		}

		private void txtNewFilenameStart_TextChanged(object sender, EventArgs e)
		{
			txtNewFilename.Text = txtNewFilenameStart.Text + "%n" + txtNewFilenameEnd.Text + ".%e";
		}

		private void txtNewFilenameEnd_TextChanged(object sender, EventArgs e)
		{
			txtNewFilename.Text = txtNewFilenameStart.Text + "%n" + txtNewFilenameEnd.Text + ".%e";
		}

		private void mnuItemsRecursive_Click(object sender, EventArgs e)
		{
			switch (mnuItemsRecursive.CheckState)
			{
				case CheckState.Checked:
					foreach (ListViewItem itm in lstItems.SelectedItems)
					{
						if (itm.Tag is BatchFolder)
							((BatchFolder)itm.Tag).Recursive = false;
					}
					mnuItemsRecursive.Checked = false;
					break;
				case CheckState.Unchecked:
					foreach (ListViewItem itm in lstItems.SelectedItems)
					{
						if (itm.Tag is BatchFolder)
							((BatchFolder)itm.Tag).Recursive = true;
					}
					mnuItemsRecursive.Checked = true;
					break;
				case CheckState.Indeterminate:
					goto case CheckState.Checked;
			}
		}

		private void cmnuItems_Opening(object sender, CancelEventArgs e)
		{
			CheckState? state = null;
			foreach (ListViewItem itm in lstItems.SelectedItems)
			{
				if (itm.Tag is BatchFolder)
				{
					if (!state.HasValue)
						state = (((BatchFolder)itm.Tag).Recursive ? CheckState.Checked : CheckState.Unchecked);
					else if (((BatchFolder)itm.Tag).Recursive != (state.Value == CheckState.Checked ? true : false))
					{
						state = CheckState.Indeterminate;
						break;
					}
				}
			}
			if (state.HasValue)
			{
				mnuItemsRecursive.CheckState = state.Value;
				mnuItemsRecursive.Visible = true;
				mnuItemsLine1.Visible = true;
			}
			else
			{
				mnuItemsRecursive.Visible = false;
				mnuItemsLine1.Visible = false;
			}
		}

		private void chkUseStamp_CheckedChanged(object sender, EventArgs e)
		{ pnlStamp.Enabled = chkUseStamp.Checked; Preview(); }

		private void optSizeToFit_CheckedChanged(object sender, EventArgs e)
		{ PositionCheckedChanged(); }
		private void optStretchToFit_CheckedChanged(object sender, EventArgs e)
		{ PositionCheckedChanged(); }
		private void optPosition_CheckedChanged(object sender, EventArgs e)
		{ PositionCheckedChanged(); }
		private void PositionCheckedChanged()
		{
			pnlPosition.Enabled = optPosition.Checked;
			numHorizontalMargin.Enabled = optPosition.Checked;
			numVerticalMargin.Enabled = optPosition.Checked;
			lblLabels7.Enabled = optPosition.Checked;
			lblLabels8.Enabled = optPosition.Checked;
			lblLabels9.Enabled = optPosition.Checked;
			lblLabels10.Enabled = optPosition.Checked;
			Preview();
		}

		private void chkUseSourceFolder_CheckedChanged(object sender, EventArgs e)
		{
			chkCreateSubfolders.Enabled = !chkUseSourceFolder.Checked;
			txtFolder.Enabled = !chkUseSourceFolder.Checked;
			btnBrowseFolder.Enabled = !chkUseSourceFolder.Checked;
		}

		private void btnBrowseFolder_Click(object sender, EventArgs e)
		{
			if (dlgFolder.ShowDialog(this) == DialogResult.OK)
			{ txtFolder.Text = dlgFolder.SelectedPath; }
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			if (dlgOpenStamp.ShowDialog(this) == DialogResult.OK)
			{ txtStampFile.Text = dlgOpenStamp.FileName; Preview(); }
		}

		private void btnEditName_Click(object sender, EventArgs e)
		{
			frmCustomFilenameEditor cfe = new frmCustomFilenameEditor();
			cfe.Pattern = txtNewFilename.Text;
			if (cfe.ShowDialog(this) == DialogResult.OK)
			{ txtNewFilename.Text = cfe.Pattern; }
		}

		private void numWidth_Leave(object sender, EventArgs e)
		{ Preview(); }
		private void numHeight_Leave(object sender, EventArgs e)
		{ Preview(); }
		private void numHorizontalMargin_Leave(object sender, EventArgs e)
		{ Preview(); }
		private void numVerticalMargin_Leave(object sender, EventArgs e)
		{ Preview(); }
		private void trbTransparency_Leave(object sender, EventArgs e)
		{ Preview(); }

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Store settings.
			Settings.Default.MainFormState = this.WindowState;
			if (this.WindowState == FormWindowState.Normal)
			{
				Settings.Default.MainFormSize = this.Size;
				Settings.Default.MainFormLocation = this.Location;
			}
			else
			{
				Settings.Default.MainFormSize = this.RestoreBounds.Size;
				Settings.Default.MainFormLocation = this.RestoreBounds.Location;
			}

			Settings.Default.BatchMaxWidth = (int)numWidth.Value;
			Settings.Default.BatchMaxHeight = (int)numHeight.Value;
			Settings.Default.BatchQuality = trbQuality.Value;
			Settings.Default.BatchUseStamp = chkUseStamp.Checked;
			Settings.Default.BatchStampFile = txtStampFile.Text;
			if (optSizeToFit.Checked) Settings.Default.BatchStampPlacement = (int)StampPlacement.Scale;
			else if (optStretchToFit.Checked) Settings.Default.BatchStampPlacement = (int)StampPlacement.Stretch;
			else if (optTopLeft.Checked) Settings.Default.BatchStampPlacement = (int)StampPlacement.TopLeft;
			else if (optTop.Checked) Settings.Default.BatchStampPlacement = (int)StampPlacement.Top;
			else if (optTopRight.Checked) Settings.Default.BatchStampPlacement = (int)StampPlacement.TopRight;
			else if (optLeft.Checked) Settings.Default.BatchStampPlacement = (int)StampPlacement.Left;
			else if (optCenter.Checked) Settings.Default.BatchStampPlacement = (int)StampPlacement.Center;
			else if (optRight.Checked) Settings.Default.BatchStampPlacement = (int)StampPlacement.Right;
			else if (optBottomLeft.Checked) Settings.Default.BatchStampPlacement = (int)StampPlacement.BottomLeft;
			else if (optBottom.Checked) Settings.Default.BatchStampPlacement = (int)StampPlacement.Bottom;
			else if (optBottomRight.Checked) Settings.Default.BatchStampPlacement = (int)StampPlacement.BottomRight;
			Settings.Default.BatchStampHMargin = (int)numHorizontalMargin.Value;
			Settings.Default.BatchStampVMargin = (int)numVerticalMargin.Value;
			Settings.Default.BatchTransparency = trbTransparency.Value;
			Settings.Default.BatchUseSourceFolder = chkUseSourceFolder.Checked;
			Settings.Default.BatchDestFolder = txtFolder.Text;
			Settings.Default.BatchCreateSubFolders = chkCreateSubfolders.Checked;
			try
			{
				if (dlgAddFolder.SelectedPath.Length > 0)
					Settings.Default.MainFormLastAddedDirectory = dlgAddFolder.SelectedPath;
				if (dlgAddFiles.FileName.Length > 0)
					Settings.Default.MainFormLastAddedFilesDirectory = Path.GetDirectoryName(dlgAddFiles.FileName);
			}
			catch
			{ /* Do nothing */ }
			Settings.Default.MainFormListView = lstItems.View;
			Settings.Default.MainFormNewFilenameStart = txtNewFilenameStart.Text;
			Settings.Default.MainFormNewFilenameEnd = txtNewFilenameEnd.Text;
			Settings.Default.BatchNewFilenamePattern = txtNewFilename.Text;
			Settings.Default.MainFormNewFilenameSimple = optNewFilenameSimple.Checked;

			Settings.Default.Save();
		}

		#region Position
		private void optTopLeft_CheckedChanged(object sender, EventArgs e)
		{
			lblLabels7.Visible = true;
			lblLabels8.Visible = true;
			numHorizontalMargin.Visible = true;
			lblLabels9.Visible = true;
			lblLabels10.Visible = true;
			numVerticalMargin.Visible = true;

			lblLabels7.Text = Resources.MainFormMarginLeft;
			lblLabels9.Text = Resources.MainFormMarginTop;
			Preview();
		}

		private void optTop_CheckedChanged(object sender, EventArgs e)
		{
			lblLabels7.Visible = false;
			lblLabels8.Visible = false;
			numHorizontalMargin.Visible = false;
			lblLabels9.Visible = true;
			lblLabels10.Visible = true;
			numVerticalMargin.Visible = true;

			lblLabels9.Text = Resources.MainFormMarginTop;
			Preview();
		}

		private void optTopRight_CheckedChanged(object sender, EventArgs e)
		{
			lblLabels7.Visible = true;
			lblLabels8.Visible = true;
			numHorizontalMargin.Visible = true;
			lblLabels9.Visible = true;
			lblLabels10.Visible = true;
			numVerticalMargin.Visible = true;

			lblLabels7.Text = Resources.MainFormMarginRight;
			lblLabels9.Text = Resources.MainFormMarginTop;
			Preview();
		}

		private void optLeft_CheckedChanged(object sender, EventArgs e)
		{
			lblLabels7.Visible = true;
			lblLabels8.Visible = true;
			numHorizontalMargin.Visible = true;
			lblLabels9.Visible = false;
			lblLabels10.Visible = false;
			numVerticalMargin.Visible = false;

			lblLabels7.Text = Resources.MainFormMarginLeft;
			Preview();
		}

		private void optCenter_CheckedChanged(object sender, EventArgs e)
		{
			lblLabels7.Visible = false;
			lblLabels8.Visible = false;
			numHorizontalMargin.Visible = false;
			lblLabels9.Visible = false;
			lblLabels10.Visible = false;
			numVerticalMargin.Visible = false;
			Preview();
		}

		private void optRight_CheckedChanged(object sender, EventArgs e)
		{
			lblLabels7.Visible = true;
			lblLabels8.Visible = true;
			numHorizontalMargin.Visible = true;
			lblLabels9.Visible = false;
			lblLabels10.Visible = false;
			numVerticalMargin.Visible = false;

			lblLabels7.Text = Resources.MainFormMarginRight;
			Preview();
		}

		private void optBottomLeft_CheckedChanged(object sender, EventArgs e)
		{
			lblLabels7.Visible = true;
			lblLabels8.Visible = true;
			numHorizontalMargin.Visible = true;
			lblLabels9.Visible = true;
			lblLabels10.Visible = true;
			numVerticalMargin.Visible = true;

			lblLabels7.Text = Resources.MainFormMarginLeft;
			lblLabels9.Text = Resources.MainFormMarginBottom;
			Preview();
		}

		private void optBottom_CheckedChanged(object sender, EventArgs e)
		{
			lblLabels7.Visible = false;
			lblLabels8.Visible = false;
			numHorizontalMargin.Visible = false;
			lblLabels9.Visible = true;
			lblLabels10.Visible = true;
			numVerticalMargin.Visible = true;

			lblLabels9.Text = Resources.MainFormMarginBottom;
			Preview();
		}

		private void optBottomRight_CheckedChanged(object sender, EventArgs e)
		{
			lblLabels7.Visible = true;
			lblLabels8.Visible = true;
			numHorizontalMargin.Visible = true;
			lblLabels9.Visible = true;
			lblLabels10.Visible = true;
			numVerticalMargin.Visible = true;

			lblLabels7.Text = Resources.MainFormMarginRight;
			lblLabels9.Text = Resources.MainFormMarginBottom;
			Preview();
		}
		#endregion

		#region Menu: File
		#endregion

		#region Menu: Help
		/// <summary>
		/// Handles the Click event of the mnuHelpAbout control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void mnuHelpAbout_Click(object sender, EventArgs e)
		{
			frmAbout about = new frmAbout();
			about.ShowDialog(this);
		}
		#endregion
		#endregion

		#region Validation
		private void numWidth_Validating(object sender, CancelEventArgs e)
		{
			if (numWidth.Value == 1)
				warningProvider1.SetError(numWidth, String.Format(Resources.MainFormValidateWidthSmallSingle, numWidth.Value));
			else if (numWidth.Value < 32)
				warningProvider1.SetError(numWidth, String.Format(Resources.MainFormValidateWidthSmallMultiple, numWidth.Value));
			else if (numWidth.Value > 4096)
				warningProvider1.SetError(numWidth, String.Format(Resources.MainFormValidateWidthBigMultiple, numWidth.Value));
			else
				warningProvider1.SetError(numWidth, string.Empty);	// Removes the warning icon.
		}

		private void numHeight_Validating(object sender, CancelEventArgs e)
		{
			if (numHeight.Value == 1)
				warningProvider1.SetError(numHeight, String.Format(Resources.MainFormValidateHeightSmallSingle, numHeight.Value));
			else if (numHeight.Value < 32)
				warningProvider1.SetError(numHeight, String.Format(Resources.MainFormValidateHeightSmallMultiple, numHeight.Value));
			else if (numHeight.Value > 4096)
				warningProvider1.SetError(numHeight, String.Format(Resources.MainFormValidateHeightBigMultiple, numHeight.Value));
			else
				warningProvider1.SetError(numHeight, string.Empty);	// Removes the warning icon.
		}

		private void trbQuality_Validating(object sender, CancelEventArgs e)
		{
			if (trbQuality.Value < 20)
				warningProvider1.SetError(trbQuality, String.Format(Resources.MainFormValidateQualityLow, trbQuality.Value));
			else
				warningProvider1.SetError(trbQuality, string.Empty);	// Removes the warning icon.
		}

		private void trbTransparency_Validating(object sender, CancelEventArgs e)
		{
			if (trbTransparency.Value > 90)
				warningProvider1.SetError(trbTransparency, String.Format(Resources.MainFormValidateStampTransparencyHigh, trbTransparency.Value));
			else
				warningProvider1.SetError(trbTransparency, string.Empty);	// Removes the warning icon.
		}

		private void numHorizontalMargin_Validating(object sender, CancelEventArgs e)
		{
			if (numHorizontalMargin.Value < 0)
			{
				warningProvider1.SetError(numHorizontalMargin, String.Format(Resources.MainFormValidateMarginHLow, numHorizontalMargin.Value));
			}
			else if (numHorizontalMargin.Value >= numWidth.Value)
				warningProvider1.SetError(numHorizontalMargin, String.Format(Resources.MainFormValidateMarginHHigh, numHorizontalMargin.Value));
			else
				warningProvider1.SetError(numHorizontalMargin, string.Empty);	// Removes the warning icon.
		}

		private void numVerticalMargin_Validating(object sender, CancelEventArgs e)
		{
			if (numVerticalMargin.Value < 0)
			{
				warningProvider1.SetError(numVerticalMargin, String.Format(Resources.MainFormValidateMarginVLow, numVerticalMargin.Value));
			}
			else if (numVerticalMargin.Value >= numHeight.Value)
				warningProvider1.SetError(numVerticalMargin, String.Format(Resources.MainFormValidateMarginVHigh, numVerticalMargin.Value));
			else
				warningProvider1.SetError(numVerticalMargin, string.Empty);	// Removes the warning icon.
		}
		#endregion
		#endregion
	}
}