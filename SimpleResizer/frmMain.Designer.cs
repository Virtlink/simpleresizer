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
	partial class frmMain
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.splitSplitter2 = new System.Windows.Forms.SplitContainer();
			this.pctPreview = new System.Windows.Forms.PictureBox();
			this.lblPreviewName = new System.Windows.Forms.Label();
			this.prbPreviewProgress = new System.Windows.Forms.ProgressBar();
			this.grpSave = new System.Windows.Forms.GroupBox();
			this.optNewFilenameAdvanced = new System.Windows.Forms.RadioButton();
			this.optNewFilenameSimple = new System.Windows.Forms.RadioButton();
			this.lblNewFilenameExample = new System.Windows.Forms.Label();
			this.txtNewFilenameEnd = new System.Windows.Forms.TextBox();
			this.txtNewFilenameStart = new System.Windows.Forms.TextBox();
			this.lblLabels15 = new System.Windows.Forms.Label();
			this.chkCreateSubfolders = new System.Windows.Forms.CheckBox();
			this.chkUseSourceFolder = new System.Windows.Forms.CheckBox();
			this.btnExecute = new System.Windows.Forms.Button();
			this.btnBrowseFolder = new System.Windows.Forms.Button();
			this.txtFolder = new System.Windows.Forms.TextBox();
			this.lblLabels13 = new System.Windows.Forms.Label();
			this.btnEditName = new System.Windows.Forms.Button();
			this.txtNewFilename = new System.Windows.Forms.TextBox();
			this.lblLabels12 = new System.Windows.Forms.Label();
			this.grpStamp = new System.Windows.Forms.GroupBox();
			this.pnlStamp = new System.Windows.Forms.Panel();
			this.numVerticalMargin = new System.Windows.Forms.NumericUpDown();
			this.numHorizontalMargin = new System.Windows.Forms.NumericUpDown();
			this.lblLabels5 = new System.Windows.Forms.Label();
			this.trbTransparency = new System.Windows.Forms.TrackBar();
			this.txtStampFile = new System.Windows.Forms.TextBox();
			this.lblLabels11 = new System.Windows.Forms.Label();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.lblLabels10 = new System.Windows.Forms.Label();
			this.lblLabels6 = new System.Windows.Forms.Label();
			this.optSizeToFit = new System.Windows.Forms.RadioButton();
			this.lblLabels9 = new System.Windows.Forms.Label();
			this.optStretchToFit = new System.Windows.Forms.RadioButton();
			this.lblLabels8 = new System.Windows.Forms.Label();
			this.optPosition = new System.Windows.Forms.RadioButton();
			this.pnlPosition = new System.Windows.Forms.Panel();
			this.optBottomRight = new System.Windows.Forms.RadioButton();
			this.optBottom = new System.Windows.Forms.RadioButton();
			this.optBottomLeft = new System.Windows.Forms.RadioButton();
			this.optRight = new System.Windows.Forms.RadioButton();
			this.optCenter = new System.Windows.Forms.RadioButton();
			this.optLeft = new System.Windows.Forms.RadioButton();
			this.optTopRight = new System.Windows.Forms.RadioButton();
			this.optTop = new System.Windows.Forms.RadioButton();
			this.optTopLeft = new System.Windows.Forms.RadioButton();
			this.lblLabels7 = new System.Windows.Forms.Label();
			this.chkUseStamp = new System.Windows.Forms.CheckBox();
			this.grpResize = new System.Windows.Forms.GroupBox();
			this.numHeight = new System.Windows.Forms.NumericUpDown();
			this.numWidth = new System.Windows.Forms.NumericUpDown();
			this.trbQuality = new System.Windows.Forms.TrackBar();
			this.lblLabels4 = new System.Windows.Forms.Label();
			this.lblLabels3 = new System.Windows.Forms.Label();
			this.lblLabels2 = new System.Windows.Forms.Label();
			this.lblLabels1 = new System.Windows.Forms.Label();
			this.splitSplitter1 = new System.Windows.Forms.SplitContainer();
			this.lstItems = new System.Windows.Forms.ListView();
			this.colName = new System.Windows.Forms.ColumnHeader();
			this.colFolder = new System.Windows.Forms.ColumnHeader();
			this.cmnuItems = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuItemsRecursive = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuItemsLine1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuItemsRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.imlNormal = new System.Windows.Forms.ImageList(this.components);
			this.imlSmall = new System.Windows.Forms.ImageList(this.components);
			this.tlbFiles = new System.Windows.Forms.ToolStrip();
			this.btnAddFiles = new System.Windows.Forms.ToolStripButton();
			this.btnAddFolder = new System.Windows.Forms.ToolStripButton();
			this.btnLine1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnRemove = new System.Windows.Forms.ToolStripSplitButton();
			this.cmnuRemove = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuRemoveRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRemoveLine1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuRemoveClearAll = new System.Windows.Forms.ToolStripMenuItem();
			this.btnView = new System.Windows.Forms.ToolStripSplitButton();
			this.cmnuView = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuViewTile = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuViewLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuViewList = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuViewDetails = new System.Windows.Forms.ToolStripMenuItem();
			this.stbStatus = new System.Windows.Forms.StatusStrip();
			this.lblFileCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.mmnuMain = new System.Windows.Forms.MenuStrip();
			this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileNewProject = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileOpenProject = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileSaveProject = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileSaveProjectAs = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileLine1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuProject = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuProjectAddFiles = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuProjectAddFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuProjectLine1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuProjectRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuProjectLine2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuProjectClearAll = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.warningProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.dlgOpenStamp = new System.Windows.Forms.OpenFileDialog();
			this.dlgAddFiles = new System.Windows.Forms.OpenFileDialog();
			this.dlgAddFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.bgWorker = new System.ComponentModel.BackgroundWorker();
			this.imlTile = new System.Windows.Forms.ImageList(this.components);
			this.splitSplitter2.Panel1.SuspendLayout();
			this.splitSplitter2.Panel2.SuspendLayout();
			this.splitSplitter2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pctPreview)).BeginInit();
			this.grpSave.SuspendLayout();
			this.grpStamp.SuspendLayout();
			this.pnlStamp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numVerticalMargin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numHorizontalMargin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trbTransparency)).BeginInit();
			this.pnlPosition.SuspendLayout();
			this.grpResize.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trbQuality)).BeginInit();
			this.splitSplitter1.Panel1.SuspendLayout();
			this.splitSplitter1.Panel2.SuspendLayout();
			this.splitSplitter1.SuspendLayout();
			this.cmnuItems.SuspendLayout();
			this.tlbFiles.SuspendLayout();
			this.cmnuRemove.SuspendLayout();
			this.cmnuView.SuspendLayout();
			this.stbStatus.SuspendLayout();
			this.mmnuMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.warningProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// splitSplitter2
			// 
			this.splitSplitter2.AccessibleDescription = null;
			this.splitSplitter2.AccessibleName = null;
			resources.ApplyResources(this.splitSplitter2, "splitSplitter2");
			this.splitSplitter2.BackgroundImage = null;
			this.warningProvider1.SetError(this.splitSplitter2, resources.GetString("splitSplitter2.Error"));
			this.splitSplitter2.Font = null;
			this.warningProvider1.SetIconAlignment(this.splitSplitter2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitSplitter2.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.splitSplitter2, ((int)(resources.GetObject("splitSplitter2.IconPadding"))));
			this.splitSplitter2.Name = "splitSplitter2";
			// 
			// splitSplitter2.Panel1
			// 
			this.splitSplitter2.Panel1.AccessibleDescription = null;
			this.splitSplitter2.Panel1.AccessibleName = null;
			resources.ApplyResources(this.splitSplitter2.Panel1, "splitSplitter2.Panel1");
			this.splitSplitter2.Panel1.BackColor = System.Drawing.Color.Black;
			this.splitSplitter2.Panel1.BackgroundImage = null;
			this.splitSplitter2.Panel1.Controls.Add(this.pctPreview);
			this.splitSplitter2.Panel1.Controls.Add(this.lblPreviewName);
			this.splitSplitter2.Panel1.Controls.Add(this.prbPreviewProgress);
			this.warningProvider1.SetError(this.splitSplitter2.Panel1, resources.GetString("splitSplitter2.Panel1.Error"));
			this.splitSplitter2.Panel1.Font = null;
			this.warningProvider1.SetIconAlignment(this.splitSplitter2.Panel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitSplitter2.Panel1.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.splitSplitter2.Panel1, ((int)(resources.GetObject("splitSplitter2.Panel1.IconPadding"))));
			// 
			// splitSplitter2.Panel2
			// 
			this.splitSplitter2.Panel2.AccessibleDescription = null;
			this.splitSplitter2.Panel2.AccessibleName = null;
			resources.ApplyResources(this.splitSplitter2.Panel2, "splitSplitter2.Panel2");
			this.splitSplitter2.Panel2.BackgroundImage = null;
			this.splitSplitter2.Panel2.Controls.Add(this.grpSave);
			this.splitSplitter2.Panel2.Controls.Add(this.grpStamp);
			this.splitSplitter2.Panel2.Controls.Add(this.grpResize);
			this.warningProvider1.SetError(this.splitSplitter2.Panel2, resources.GetString("splitSplitter2.Panel2.Error"));
			this.splitSplitter2.Panel2.Font = null;
			this.warningProvider1.SetIconAlignment(this.splitSplitter2.Panel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitSplitter2.Panel2.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.splitSplitter2.Panel2, ((int)(resources.GetObject("splitSplitter2.Panel2.IconPadding"))));
			// 
			// pctPreview
			// 
			this.pctPreview.AccessibleDescription = null;
			this.pctPreview.AccessibleName = null;
			resources.ApplyResources(this.pctPreview, "pctPreview");
			this.pctPreview.BackColor = System.Drawing.Color.Black;
			this.pctPreview.BackgroundImage = null;
			this.warningProvider1.SetError(this.pctPreview, resources.GetString("pctPreview.Error"));
			this.pctPreview.Font = null;
			this.warningProvider1.SetIconAlignment(this.pctPreview, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pctPreview.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.pctPreview, ((int)(resources.GetObject("pctPreview.IconPadding"))));
			this.pctPreview.ImageLocation = null;
			this.pctPreview.Name = "pctPreview";
			this.pctPreview.TabStop = false;
			this.pctPreview.Resize += new System.EventHandler(this.pctPreview_Resize);
			// 
			// lblPreviewName
			// 
			this.lblPreviewName.AccessibleDescription = null;
			this.lblPreviewName.AccessibleName = null;
			resources.ApplyResources(this.lblPreviewName, "lblPreviewName");
			this.warningProvider1.SetError(this.lblPreviewName, resources.GetString("lblPreviewName.Error"));
			this.lblPreviewName.Font = null;
			this.lblPreviewName.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.warningProvider1.SetIconAlignment(this.lblPreviewName, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblPreviewName.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.lblPreviewName, ((int)(resources.GetObject("lblPreviewName.IconPadding"))));
			this.lblPreviewName.Name = "lblPreviewName";
			// 
			// prbPreviewProgress
			// 
			this.prbPreviewProgress.AccessibleDescription = null;
			this.prbPreviewProgress.AccessibleName = null;
			resources.ApplyResources(this.prbPreviewProgress, "prbPreviewProgress");
			this.prbPreviewProgress.BackgroundImage = null;
			this.warningProvider1.SetError(this.prbPreviewProgress, resources.GetString("prbPreviewProgress.Error"));
			this.prbPreviewProgress.Font = null;
			this.warningProvider1.SetIconAlignment(this.prbPreviewProgress, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("prbPreviewProgress.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.prbPreviewProgress, ((int)(resources.GetObject("prbPreviewProgress.IconPadding"))));
			this.prbPreviewProgress.Name = "prbPreviewProgress";
			this.prbPreviewProgress.Value = 50;
			// 
			// grpSave
			// 
			this.grpSave.AccessibleDescription = null;
			this.grpSave.AccessibleName = null;
			resources.ApplyResources(this.grpSave, "grpSave");
			this.grpSave.BackgroundImage = null;
			this.grpSave.Controls.Add(this.optNewFilenameAdvanced);
			this.grpSave.Controls.Add(this.optNewFilenameSimple);
			this.grpSave.Controls.Add(this.lblNewFilenameExample);
			this.grpSave.Controls.Add(this.txtNewFilenameEnd);
			this.grpSave.Controls.Add(this.txtNewFilenameStart);
			this.grpSave.Controls.Add(this.lblLabels15);
			this.grpSave.Controls.Add(this.chkCreateSubfolders);
			this.grpSave.Controls.Add(this.chkUseSourceFolder);
			this.grpSave.Controls.Add(this.btnExecute);
			this.grpSave.Controls.Add(this.btnBrowseFolder);
			this.grpSave.Controls.Add(this.txtFolder);
			this.grpSave.Controls.Add(this.lblLabels13);
			this.grpSave.Controls.Add(this.btnEditName);
			this.grpSave.Controls.Add(this.txtNewFilename);
			this.grpSave.Controls.Add(this.lblLabels12);
			this.warningProvider1.SetError(this.grpSave, resources.GetString("grpSave.Error"));
			this.grpSave.Font = null;
			this.warningProvider1.SetIconAlignment(this.grpSave, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("grpSave.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.grpSave, ((int)(resources.GetObject("grpSave.IconPadding"))));
			this.grpSave.Name = "grpSave";
			this.grpSave.TabStop = false;
			// 
			// optNewFilenameAdvanced
			// 
			this.optNewFilenameAdvanced.AccessibleDescription = null;
			this.optNewFilenameAdvanced.AccessibleName = null;
			resources.ApplyResources(this.optNewFilenameAdvanced, "optNewFilenameAdvanced");
			this.optNewFilenameAdvanced.BackgroundImage = null;
			this.warningProvider1.SetError(this.optNewFilenameAdvanced, resources.GetString("optNewFilenameAdvanced.Error"));
			this.optNewFilenameAdvanced.Font = null;
			this.warningProvider1.SetIconAlignment(this.optNewFilenameAdvanced, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("optNewFilenameAdvanced.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.optNewFilenameAdvanced, ((int)(resources.GetObject("optNewFilenameAdvanced.IconPadding"))));
			this.optNewFilenameAdvanced.Name = "optNewFilenameAdvanced";
			this.optNewFilenameAdvanced.TabStop = true;
			this.optNewFilenameAdvanced.UseVisualStyleBackColor = true;
			this.optNewFilenameAdvanced.CheckedChanged += new System.EventHandler(this.optNewFilenameAdvanced_CheckedChanged);
			// 
			// optNewFilenameSimple
			// 
			this.optNewFilenameSimple.AccessibleDescription = null;
			this.optNewFilenameSimple.AccessibleName = null;
			resources.ApplyResources(this.optNewFilenameSimple, "optNewFilenameSimple");
			this.optNewFilenameSimple.BackgroundImage = null;
			this.warningProvider1.SetError(this.optNewFilenameSimple, resources.GetString("optNewFilenameSimple.Error"));
			this.optNewFilenameSimple.Font = null;
			this.warningProvider1.SetIconAlignment(this.optNewFilenameSimple, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("optNewFilenameSimple.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.optNewFilenameSimple, ((int)(resources.GetObject("optNewFilenameSimple.IconPadding"))));
			this.optNewFilenameSimple.Name = "optNewFilenameSimple";
			this.optNewFilenameSimple.TabStop = true;
			this.optNewFilenameSimple.UseVisualStyleBackColor = true;
			this.optNewFilenameSimple.CheckedChanged += new System.EventHandler(this.optNewFilenameSimple_CheckedChanged);
			// 
			// lblNewFilenameExample
			// 
			this.lblNewFilenameExample.AccessibleDescription = null;
			this.lblNewFilenameExample.AccessibleName = null;
			resources.ApplyResources(this.lblNewFilenameExample, "lblNewFilenameExample");
			this.warningProvider1.SetError(this.lblNewFilenameExample, resources.GetString("lblNewFilenameExample.Error"));
			this.lblNewFilenameExample.Font = null;
			this.warningProvider1.SetIconAlignment(this.lblNewFilenameExample, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblNewFilenameExample.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.lblNewFilenameExample, ((int)(resources.GetObject("lblNewFilenameExample.IconPadding"))));
			this.lblNewFilenameExample.Name = "lblNewFilenameExample";
			// 
			// txtNewFilenameEnd
			// 
			this.txtNewFilenameEnd.AccessibleDescription = null;
			this.txtNewFilenameEnd.AccessibleName = null;
			resources.ApplyResources(this.txtNewFilenameEnd, "txtNewFilenameEnd");
			this.txtNewFilenameEnd.BackgroundImage = null;
			this.warningProvider1.SetError(this.txtNewFilenameEnd, resources.GetString("txtNewFilenameEnd.Error"));
			this.txtNewFilenameEnd.Font = null;
			this.warningProvider1.SetIconAlignment(this.txtNewFilenameEnd, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtNewFilenameEnd.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.txtNewFilenameEnd, ((int)(resources.GetObject("txtNewFilenameEnd.IconPadding"))));
			this.txtNewFilenameEnd.Name = "txtNewFilenameEnd";
			this.txtNewFilenameEnd.TextChanged += new System.EventHandler(this.txtNewFilenameEnd_TextChanged);
			// 
			// txtNewFilenameStart
			// 
			this.txtNewFilenameStart.AccessibleDescription = null;
			this.txtNewFilenameStart.AccessibleName = null;
			resources.ApplyResources(this.txtNewFilenameStart, "txtNewFilenameStart");
			this.txtNewFilenameStart.BackgroundImage = null;
			this.warningProvider1.SetError(this.txtNewFilenameStart, resources.GetString("txtNewFilenameStart.Error"));
			this.txtNewFilenameStart.Font = null;
			this.warningProvider1.SetIconAlignment(this.txtNewFilenameStart, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtNewFilenameStart.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.txtNewFilenameStart, ((int)(resources.GetObject("txtNewFilenameStart.IconPadding"))));
			this.txtNewFilenameStart.Name = "txtNewFilenameStart";
			this.txtNewFilenameStart.TextChanged += new System.EventHandler(this.txtNewFilenameStart_TextChanged);
			// 
			// lblLabels15
			// 
			this.lblLabels15.AccessibleDescription = null;
			this.lblLabels15.AccessibleName = null;
			resources.ApplyResources(this.lblLabels15, "lblLabels15");
			this.warningProvider1.SetError(this.lblLabels15, resources.GetString("lblLabels15.Error"));
			this.lblLabels15.Font = null;
			this.warningProvider1.SetIconAlignment(this.lblLabels15, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblLabels15.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.lblLabels15, ((int)(resources.GetObject("lblLabels15.IconPadding"))));
			this.lblLabels15.Name = "lblLabels15";
			// 
			// chkCreateSubfolders
			// 
			this.chkCreateSubfolders.AccessibleDescription = null;
			this.chkCreateSubfolders.AccessibleName = null;
			resources.ApplyResources(this.chkCreateSubfolders, "chkCreateSubfolders");
			this.chkCreateSubfolders.BackgroundImage = null;
			this.warningProvider1.SetError(this.chkCreateSubfolders, resources.GetString("chkCreateSubfolders.Error"));
			this.chkCreateSubfolders.Font = null;
			this.warningProvider1.SetIconAlignment(this.chkCreateSubfolders, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("chkCreateSubfolders.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.chkCreateSubfolders, ((int)(resources.GetObject("chkCreateSubfolders.IconPadding"))));
			this.chkCreateSubfolders.Name = "chkCreateSubfolders";
			this.chkCreateSubfolders.UseVisualStyleBackColor = true;
			// 
			// chkUseSourceFolder
			// 
			this.chkUseSourceFolder.AccessibleDescription = null;
			this.chkUseSourceFolder.AccessibleName = null;
			resources.ApplyResources(this.chkUseSourceFolder, "chkUseSourceFolder");
			this.chkUseSourceFolder.BackgroundImage = null;
			this.warningProvider1.SetError(this.chkUseSourceFolder, resources.GetString("chkUseSourceFolder.Error"));
			this.chkUseSourceFolder.Font = null;
			this.warningProvider1.SetIconAlignment(this.chkUseSourceFolder, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("chkUseSourceFolder.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.chkUseSourceFolder, ((int)(resources.GetObject("chkUseSourceFolder.IconPadding"))));
			this.chkUseSourceFolder.Name = "chkUseSourceFolder";
			this.chkUseSourceFolder.UseVisualStyleBackColor = true;
			this.chkUseSourceFolder.CheckedChanged += new System.EventHandler(this.chkUseSourceFolder_CheckedChanged);
			// 
			// btnExecute
			// 
			this.btnExecute.AccessibleDescription = null;
			this.btnExecute.AccessibleName = null;
			resources.ApplyResources(this.btnExecute, "btnExecute");
			this.btnExecute.BackgroundImage = null;
			this.warningProvider1.SetError(this.btnExecute, resources.GetString("btnExecute.Error"));
			this.btnExecute.Font = null;
			this.warningProvider1.SetIconAlignment(this.btnExecute, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnExecute.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.btnExecute, ((int)(resources.GetObject("btnExecute.IconPadding"))));
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.UseVisualStyleBackColor = true;
			this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
			// 
			// btnBrowseFolder
			// 
			this.btnBrowseFolder.AccessibleDescription = null;
			this.btnBrowseFolder.AccessibleName = null;
			resources.ApplyResources(this.btnBrowseFolder, "btnBrowseFolder");
			this.btnBrowseFolder.BackgroundImage = null;
			this.warningProvider1.SetError(this.btnBrowseFolder, resources.GetString("btnBrowseFolder.Error"));
			this.btnBrowseFolder.Font = null;
			this.warningProvider1.SetIconAlignment(this.btnBrowseFolder, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnBrowseFolder.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.btnBrowseFolder, ((int)(resources.GetObject("btnBrowseFolder.IconPadding"))));
			this.btnBrowseFolder.Name = "btnBrowseFolder";
			this.btnBrowseFolder.UseVisualStyleBackColor = true;
			this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
			// 
			// txtFolder
			// 
			this.txtFolder.AccessibleDescription = null;
			this.txtFolder.AccessibleName = null;
			resources.ApplyResources(this.txtFolder, "txtFolder");
			this.txtFolder.BackgroundImage = null;
			this.warningProvider1.SetError(this.txtFolder, resources.GetString("txtFolder.Error"));
			this.txtFolder.Font = null;
			this.warningProvider1.SetIconAlignment(this.txtFolder, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtFolder.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.txtFolder, ((int)(resources.GetObject("txtFolder.IconPadding"))));
			this.txtFolder.Name = "txtFolder";
			// 
			// lblLabels13
			// 
			this.lblLabels13.AccessibleDescription = null;
			this.lblLabels13.AccessibleName = null;
			resources.ApplyResources(this.lblLabels13, "lblLabels13");
			this.warningProvider1.SetError(this.lblLabels13, resources.GetString("lblLabels13.Error"));
			this.lblLabels13.Font = null;
			this.warningProvider1.SetIconAlignment(this.lblLabels13, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblLabels13.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.lblLabels13, ((int)(resources.GetObject("lblLabels13.IconPadding"))));
			this.lblLabels13.Name = "lblLabels13";
			// 
			// btnEditName
			// 
			this.btnEditName.AccessibleDescription = null;
			this.btnEditName.AccessibleName = null;
			resources.ApplyResources(this.btnEditName, "btnEditName");
			this.btnEditName.BackgroundImage = null;
			this.warningProvider1.SetError(this.btnEditName, resources.GetString("btnEditName.Error"));
			this.btnEditName.Font = null;
			this.warningProvider1.SetIconAlignment(this.btnEditName, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnEditName.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.btnEditName, ((int)(resources.GetObject("btnEditName.IconPadding"))));
			this.btnEditName.Name = "btnEditName";
			this.btnEditName.UseVisualStyleBackColor = true;
			this.btnEditName.Click += new System.EventHandler(this.btnEditName_Click);
			// 
			// txtNewFilename
			// 
			this.txtNewFilename.AccessibleDescription = null;
			this.txtNewFilename.AccessibleName = null;
			resources.ApplyResources(this.txtNewFilename, "txtNewFilename");
			this.txtNewFilename.BackgroundImage = null;
			this.warningProvider1.SetError(this.txtNewFilename, resources.GetString("txtNewFilename.Error"));
			this.txtNewFilename.Font = null;
			this.warningProvider1.SetIconAlignment(this.txtNewFilename, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtNewFilename.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.txtNewFilename, ((int)(resources.GetObject("txtNewFilename.IconPadding"))));
			this.txtNewFilename.Name = "txtNewFilename";
			// 
			// lblLabels12
			// 
			this.lblLabels12.AccessibleDescription = null;
			this.lblLabels12.AccessibleName = null;
			resources.ApplyResources(this.lblLabels12, "lblLabels12");
			this.warningProvider1.SetError(this.lblLabels12, resources.GetString("lblLabels12.Error"));
			this.lblLabels12.Font = null;
			this.warningProvider1.SetIconAlignment(this.lblLabels12, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblLabels12.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.lblLabels12, ((int)(resources.GetObject("lblLabels12.IconPadding"))));
			this.lblLabels12.Name = "lblLabels12";
			// 
			// grpStamp
			// 
			this.grpStamp.AccessibleDescription = null;
			this.grpStamp.AccessibleName = null;
			resources.ApplyResources(this.grpStamp, "grpStamp");
			this.grpStamp.BackgroundImage = null;
			this.grpStamp.Controls.Add(this.pnlStamp);
			this.grpStamp.Controls.Add(this.chkUseStamp);
			this.warningProvider1.SetError(this.grpStamp, resources.GetString("grpStamp.Error"));
			this.grpStamp.Font = null;
			this.warningProvider1.SetIconAlignment(this.grpStamp, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("grpStamp.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.grpStamp, ((int)(resources.GetObject("grpStamp.IconPadding"))));
			this.grpStamp.Name = "grpStamp";
			this.grpStamp.TabStop = false;
			// 
			// pnlStamp
			// 
			this.pnlStamp.AccessibleDescription = null;
			this.pnlStamp.AccessibleName = null;
			resources.ApplyResources(this.pnlStamp, "pnlStamp");
			this.pnlStamp.BackgroundImage = null;
			this.pnlStamp.Controls.Add(this.numVerticalMargin);
			this.pnlStamp.Controls.Add(this.numHorizontalMargin);
			this.pnlStamp.Controls.Add(this.lblLabels5);
			this.pnlStamp.Controls.Add(this.trbTransparency);
			this.pnlStamp.Controls.Add(this.txtStampFile);
			this.pnlStamp.Controls.Add(this.lblLabels11);
			this.pnlStamp.Controls.Add(this.btnBrowse);
			this.pnlStamp.Controls.Add(this.lblLabels10);
			this.pnlStamp.Controls.Add(this.lblLabels6);
			this.pnlStamp.Controls.Add(this.optSizeToFit);
			this.pnlStamp.Controls.Add(this.lblLabels9);
			this.pnlStamp.Controls.Add(this.optStretchToFit);
			this.pnlStamp.Controls.Add(this.lblLabels8);
			this.pnlStamp.Controls.Add(this.optPosition);
			this.pnlStamp.Controls.Add(this.pnlPosition);
			this.pnlStamp.Controls.Add(this.lblLabels7);
			this.warningProvider1.SetError(this.pnlStamp, resources.GetString("pnlStamp.Error"));
			this.pnlStamp.Font = null;
			this.warningProvider1.SetIconAlignment(this.pnlStamp, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pnlStamp.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.pnlStamp, ((int)(resources.GetObject("pnlStamp.IconPadding"))));
			this.pnlStamp.Name = "pnlStamp";
			// 
			// numVerticalMargin
			// 
			this.numVerticalMargin.AccessibleDescription = null;
			this.numVerticalMargin.AccessibleName = null;
			resources.ApplyResources(this.numVerticalMargin, "numVerticalMargin");
			this.warningProvider1.SetError(this.numVerticalMargin, resources.GetString("numVerticalMargin.Error"));
			this.numVerticalMargin.Font = null;
			this.warningProvider1.SetIconAlignment(this.numVerticalMargin, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("numVerticalMargin.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.numVerticalMargin, ((int)(resources.GetObject("numVerticalMargin.IconPadding"))));
			this.numVerticalMargin.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
			this.numVerticalMargin.Minimum = new decimal(new int[] {
            4096,
            0,
            0,
            -2147483648});
			this.numVerticalMargin.Name = "numVerticalMargin";
			this.numVerticalMargin.Leave += new System.EventHandler(this.numVerticalMargin_Leave);
			this.numVerticalMargin.Validating += new System.ComponentModel.CancelEventHandler(this.numVerticalMargin_Validating);
			// 
			// numHorizontalMargin
			// 
			this.numHorizontalMargin.AccessibleDescription = null;
			this.numHorizontalMargin.AccessibleName = null;
			resources.ApplyResources(this.numHorizontalMargin, "numHorizontalMargin");
			this.warningProvider1.SetError(this.numHorizontalMargin, resources.GetString("numHorizontalMargin.Error"));
			this.numHorizontalMargin.Font = null;
			this.warningProvider1.SetIconAlignment(this.numHorizontalMargin, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("numHorizontalMargin.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.numHorizontalMargin, ((int)(resources.GetObject("numHorizontalMargin.IconPadding"))));
			this.numHorizontalMargin.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
			this.numHorizontalMargin.Minimum = new decimal(new int[] {
            4096,
            0,
            0,
            -2147483648});
			this.numHorizontalMargin.Name = "numHorizontalMargin";
			this.numHorizontalMargin.Leave += new System.EventHandler(this.numHorizontalMargin_Leave);
			this.numHorizontalMargin.Validating += new System.ComponentModel.CancelEventHandler(this.numHorizontalMargin_Validating);
			// 
			// lblLabels5
			// 
			this.lblLabels5.AccessibleDescription = null;
			this.lblLabels5.AccessibleName = null;
			resources.ApplyResources(this.lblLabels5, "lblLabels5");
			this.warningProvider1.SetError(this.lblLabels5, resources.GetString("lblLabels5.Error"));
			this.lblLabels5.Font = null;
			this.warningProvider1.SetIconAlignment(this.lblLabels5, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblLabels5.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.lblLabels5, ((int)(resources.GetObject("lblLabels5.IconPadding"))));
			this.lblLabels5.Name = "lblLabels5";
			// 
			// trbTransparency
			// 
			this.trbTransparency.AccessibleDescription = null;
			this.trbTransparency.AccessibleName = null;
			resources.ApplyResources(this.trbTransparency, "trbTransparency");
			this.trbTransparency.BackgroundImage = null;
			this.warningProvider1.SetError(this.trbTransparency, resources.GetString("trbTransparency.Error"));
			this.trbTransparency.Font = null;
			this.warningProvider1.SetIconAlignment(this.trbTransparency, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("trbTransparency.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.trbTransparency, ((int)(resources.GetObject("trbTransparency.IconPadding"))));
			this.trbTransparency.Maximum = 100;
			this.trbTransparency.Name = "trbTransparency";
			this.trbTransparency.TickFrequency = 10;
			this.trbTransparency.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.trbTransparency.Leave += new System.EventHandler(this.trbTransparency_Leave);
			this.trbTransparency.Validating += new System.ComponentModel.CancelEventHandler(this.trbTransparency_Validating);
			// 
			// txtStampFile
			// 
			this.txtStampFile.AccessibleDescription = null;
			this.txtStampFile.AccessibleName = null;
			resources.ApplyResources(this.txtStampFile, "txtStampFile");
			this.txtStampFile.BackgroundImage = null;
			this.warningProvider1.SetError(this.txtStampFile, resources.GetString("txtStampFile.Error"));
			this.txtStampFile.Font = null;
			this.warningProvider1.SetIconAlignment(this.txtStampFile, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtStampFile.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.txtStampFile, ((int)(resources.GetObject("txtStampFile.IconPadding"))));
			this.txtStampFile.Name = "txtStampFile";
			// 
			// lblLabels11
			// 
			this.lblLabels11.AccessibleDescription = null;
			this.lblLabels11.AccessibleName = null;
			resources.ApplyResources(this.lblLabels11, "lblLabels11");
			this.warningProvider1.SetError(this.lblLabels11, resources.GetString("lblLabels11.Error"));
			this.lblLabels11.Font = null;
			this.warningProvider1.SetIconAlignment(this.lblLabels11, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblLabels11.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.lblLabels11, ((int)(resources.GetObject("lblLabels11.IconPadding"))));
			this.lblLabels11.Name = "lblLabels11";
			// 
			// btnBrowse
			// 
			this.btnBrowse.AccessibleDescription = null;
			this.btnBrowse.AccessibleName = null;
			resources.ApplyResources(this.btnBrowse, "btnBrowse");
			this.btnBrowse.BackgroundImage = null;
			this.warningProvider1.SetError(this.btnBrowse, resources.GetString("btnBrowse.Error"));
			this.btnBrowse.Font = null;
			this.warningProvider1.SetIconAlignment(this.btnBrowse, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnBrowse.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.btnBrowse, ((int)(resources.GetObject("btnBrowse.IconPadding"))));
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// lblLabels10
			// 
			this.lblLabels10.AccessibleDescription = null;
			this.lblLabels10.AccessibleName = null;
			resources.ApplyResources(this.lblLabels10, "lblLabels10");
			this.warningProvider1.SetError(this.lblLabels10, resources.GetString("lblLabels10.Error"));
			this.lblLabels10.Font = null;
			this.warningProvider1.SetIconAlignment(this.lblLabels10, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblLabels10.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.lblLabels10, ((int)(resources.GetObject("lblLabels10.IconPadding"))));
			this.lblLabels10.Name = "lblLabels10";
			// 
			// lblLabels6
			// 
			this.lblLabels6.AccessibleDescription = null;
			this.lblLabels6.AccessibleName = null;
			resources.ApplyResources(this.lblLabels6, "lblLabels6");
			this.warningProvider1.SetError(this.lblLabels6, resources.GetString("lblLabels6.Error"));
			this.lblLabels6.Font = null;
			this.warningProvider1.SetIconAlignment(this.lblLabels6, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblLabels6.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.lblLabels6, ((int)(resources.GetObject("lblLabels6.IconPadding"))));
			this.lblLabels6.Name = "lblLabels6";
			// 
			// optSizeToFit
			// 
			this.optSizeToFit.AccessibleDescription = null;
			this.optSizeToFit.AccessibleName = null;
			resources.ApplyResources(this.optSizeToFit, "optSizeToFit");
			this.optSizeToFit.BackgroundImage = null;
			this.warningProvider1.SetError(this.optSizeToFit, resources.GetString("optSizeToFit.Error"));
			this.optSizeToFit.Font = null;
			this.warningProvider1.SetIconAlignment(this.optSizeToFit, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("optSizeToFit.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.optSizeToFit, ((int)(resources.GetObject("optSizeToFit.IconPadding"))));
			this.optSizeToFit.Name = "optSizeToFit";
			this.optSizeToFit.UseVisualStyleBackColor = true;
			this.optSizeToFit.CheckedChanged += new System.EventHandler(this.optSizeToFit_CheckedChanged);
			// 
			// lblLabels9
			// 
			this.lblLabels9.AccessibleDescription = null;
			this.lblLabels9.AccessibleName = null;
			resources.ApplyResources(this.lblLabels9, "lblLabels9");
			this.warningProvider1.SetError(this.lblLabels9, resources.GetString("lblLabels9.Error"));
			this.lblLabels9.Font = null;
			this.warningProvider1.SetIconAlignment(this.lblLabels9, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblLabels9.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.lblLabels9, ((int)(resources.GetObject("lblLabels9.IconPadding"))));
			this.lblLabels9.Name = "lblLabels9";
			// 
			// optStretchToFit
			// 
			this.optStretchToFit.AccessibleDescription = null;
			this.optStretchToFit.AccessibleName = null;
			resources.ApplyResources(this.optStretchToFit, "optStretchToFit");
			this.optStretchToFit.BackgroundImage = null;
			this.warningProvider1.SetError(this.optStretchToFit, resources.GetString("optStretchToFit.Error"));
			this.optStretchToFit.Font = null;
			this.warningProvider1.SetIconAlignment(this.optStretchToFit, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("optStretchToFit.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.optStretchToFit, ((int)(resources.GetObject("optStretchToFit.IconPadding"))));
			this.optStretchToFit.Name = "optStretchToFit";
			this.optStretchToFit.UseVisualStyleBackColor = true;
			this.optStretchToFit.CheckedChanged += new System.EventHandler(this.optStretchToFit_CheckedChanged);
			// 
			// lblLabels8
			// 
			this.lblLabels8.AccessibleDescription = null;
			this.lblLabels8.AccessibleName = null;
			resources.ApplyResources(this.lblLabels8, "lblLabels8");
			this.warningProvider1.SetError(this.lblLabels8, resources.GetString("lblLabels8.Error"));
			this.lblLabels8.Font = null;
			this.warningProvider1.SetIconAlignment(this.lblLabels8, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblLabels8.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.lblLabels8, ((int)(resources.GetObject("lblLabels8.IconPadding"))));
			this.lblLabels8.Name = "lblLabels8";
			// 
			// optPosition
			// 
			this.optPosition.AccessibleDescription = null;
			this.optPosition.AccessibleName = null;
			resources.ApplyResources(this.optPosition, "optPosition");
			this.optPosition.BackgroundImage = null;
			this.optPosition.Checked = true;
			this.warningProvider1.SetError(this.optPosition, resources.GetString("optPosition.Error"));
			this.optPosition.Font = null;
			this.warningProvider1.SetIconAlignment(this.optPosition, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("optPosition.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.optPosition, ((int)(resources.GetObject("optPosition.IconPadding"))));
			this.optPosition.Name = "optPosition";
			this.optPosition.TabStop = true;
			this.optPosition.UseVisualStyleBackColor = true;
			this.optPosition.CheckedChanged += new System.EventHandler(this.optPosition_CheckedChanged);
			// 
			// pnlPosition
			// 
			this.pnlPosition.AccessibleDescription = null;
			this.pnlPosition.AccessibleName = null;
			resources.ApplyResources(this.pnlPosition, "pnlPosition");
			this.pnlPosition.BackgroundImage = null;
			this.pnlPosition.Controls.Add(this.optBottomRight);
			this.pnlPosition.Controls.Add(this.optBottom);
			this.pnlPosition.Controls.Add(this.optBottomLeft);
			this.pnlPosition.Controls.Add(this.optRight);
			this.pnlPosition.Controls.Add(this.optCenter);
			this.pnlPosition.Controls.Add(this.optLeft);
			this.pnlPosition.Controls.Add(this.optTopRight);
			this.pnlPosition.Controls.Add(this.optTop);
			this.pnlPosition.Controls.Add(this.optTopLeft);
			this.warningProvider1.SetError(this.pnlPosition, resources.GetString("pnlPosition.Error"));
			this.pnlPosition.Font = null;
			this.warningProvider1.SetIconAlignment(this.pnlPosition, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pnlPosition.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.pnlPosition, ((int)(resources.GetObject("pnlPosition.IconPadding"))));
			this.pnlPosition.Name = "pnlPosition";
			// 
			// optBottomRight
			// 
			this.optBottomRight.AccessibleDescription = null;
			this.optBottomRight.AccessibleName = null;
			resources.ApplyResources(this.optBottomRight, "optBottomRight");
			this.optBottomRight.BackgroundImage = null;
			this.optBottomRight.Checked = true;
			this.warningProvider1.SetError(this.optBottomRight, resources.GetString("optBottomRight.Error"));
			this.optBottomRight.Font = null;
			this.warningProvider1.SetIconAlignment(this.optBottomRight, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("optBottomRight.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.optBottomRight, ((int)(resources.GetObject("optBottomRight.IconPadding"))));
			this.optBottomRight.Name = "optBottomRight";
			this.optBottomRight.TabStop = true;
			this.optBottomRight.UseVisualStyleBackColor = true;
			this.optBottomRight.CheckedChanged += new System.EventHandler(this.optBottomRight_CheckedChanged);
			// 
			// optBottom
			// 
			this.optBottom.AccessibleDescription = null;
			this.optBottom.AccessibleName = null;
			resources.ApplyResources(this.optBottom, "optBottom");
			this.optBottom.BackgroundImage = null;
			this.warningProvider1.SetError(this.optBottom, resources.GetString("optBottom.Error"));
			this.optBottom.Font = null;
			this.warningProvider1.SetIconAlignment(this.optBottom, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("optBottom.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.optBottom, ((int)(resources.GetObject("optBottom.IconPadding"))));
			this.optBottom.Name = "optBottom";
			this.optBottom.UseVisualStyleBackColor = true;
			this.optBottom.CheckedChanged += new System.EventHandler(this.optBottom_CheckedChanged);
			// 
			// optBottomLeft
			// 
			this.optBottomLeft.AccessibleDescription = null;
			this.optBottomLeft.AccessibleName = null;
			resources.ApplyResources(this.optBottomLeft, "optBottomLeft");
			this.optBottomLeft.BackgroundImage = null;
			this.warningProvider1.SetError(this.optBottomLeft, resources.GetString("optBottomLeft.Error"));
			this.optBottomLeft.Font = null;
			this.warningProvider1.SetIconAlignment(this.optBottomLeft, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("optBottomLeft.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.optBottomLeft, ((int)(resources.GetObject("optBottomLeft.IconPadding"))));
			this.optBottomLeft.Name = "optBottomLeft";
			this.optBottomLeft.UseVisualStyleBackColor = true;
			this.optBottomLeft.CheckedChanged += new System.EventHandler(this.optBottomLeft_CheckedChanged);
			// 
			// optRight
			// 
			this.optRight.AccessibleDescription = null;
			this.optRight.AccessibleName = null;
			resources.ApplyResources(this.optRight, "optRight");
			this.optRight.BackgroundImage = null;
			this.warningProvider1.SetError(this.optRight, resources.GetString("optRight.Error"));
			this.optRight.Font = null;
			this.warningProvider1.SetIconAlignment(this.optRight, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("optRight.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.optRight, ((int)(resources.GetObject("optRight.IconPadding"))));
			this.optRight.Name = "optRight";
			this.optRight.UseVisualStyleBackColor = true;
			this.optRight.CheckedChanged += new System.EventHandler(this.optRight_CheckedChanged);
			// 
			// optCenter
			// 
			this.optCenter.AccessibleDescription = null;
			this.optCenter.AccessibleName = null;
			resources.ApplyResources(this.optCenter, "optCenter");
			this.optCenter.BackgroundImage = null;
			this.warningProvider1.SetError(this.optCenter, resources.GetString("optCenter.Error"));
			this.optCenter.Font = null;
			this.warningProvider1.SetIconAlignment(this.optCenter, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("optCenter.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.optCenter, ((int)(resources.GetObject("optCenter.IconPadding"))));
			this.optCenter.Name = "optCenter";
			this.optCenter.UseVisualStyleBackColor = true;
			this.optCenter.CheckedChanged += new System.EventHandler(this.optCenter_CheckedChanged);
			// 
			// optLeft
			// 
			this.optLeft.AccessibleDescription = null;
			this.optLeft.AccessibleName = null;
			resources.ApplyResources(this.optLeft, "optLeft");
			this.optLeft.BackgroundImage = null;
			this.warningProvider1.SetError(this.optLeft, resources.GetString("optLeft.Error"));
			this.optLeft.Font = null;
			this.warningProvider1.SetIconAlignment(this.optLeft, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("optLeft.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.optLeft, ((int)(resources.GetObject("optLeft.IconPadding"))));
			this.optLeft.Name = "optLeft";
			this.optLeft.UseVisualStyleBackColor = true;
			this.optLeft.CheckedChanged += new System.EventHandler(this.optLeft_CheckedChanged);
			// 
			// optTopRight
			// 
			this.optTopRight.AccessibleDescription = null;
			this.optTopRight.AccessibleName = null;
			resources.ApplyResources(this.optTopRight, "optTopRight");
			this.optTopRight.BackgroundImage = null;
			this.warningProvider1.SetError(this.optTopRight, resources.GetString("optTopRight.Error"));
			this.optTopRight.Font = null;
			this.warningProvider1.SetIconAlignment(this.optTopRight, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("optTopRight.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.optTopRight, ((int)(resources.GetObject("optTopRight.IconPadding"))));
			this.optTopRight.Name = "optTopRight";
			this.optTopRight.UseVisualStyleBackColor = true;
			this.optTopRight.CheckedChanged += new System.EventHandler(this.optTopRight_CheckedChanged);
			// 
			// optTop
			// 
			this.optTop.AccessibleDescription = null;
			this.optTop.AccessibleName = null;
			resources.ApplyResources(this.optTop, "optTop");
			this.optTop.BackgroundImage = null;
			this.warningProvider1.SetError(this.optTop, resources.GetString("optTop.Error"));
			this.optTop.Font = null;
			this.warningProvider1.SetIconAlignment(this.optTop, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("optTop.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.optTop, ((int)(resources.GetObject("optTop.IconPadding"))));
			this.optTop.Name = "optTop";
			this.optTop.UseVisualStyleBackColor = true;
			this.optTop.CheckedChanged += new System.EventHandler(this.optTop_CheckedChanged);
			// 
			// optTopLeft
			// 
			this.optTopLeft.AccessibleDescription = null;
			this.optTopLeft.AccessibleName = null;
			resources.ApplyResources(this.optTopLeft, "optTopLeft");
			this.optTopLeft.BackgroundImage = null;
			this.warningProvider1.SetError(this.optTopLeft, resources.GetString("optTopLeft.Error"));
			this.optTopLeft.Font = null;
			this.warningProvider1.SetIconAlignment(this.optTopLeft, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("optTopLeft.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.optTopLeft, ((int)(resources.GetObject("optTopLeft.IconPadding"))));
			this.optTopLeft.Name = "optTopLeft";
			this.optTopLeft.UseVisualStyleBackColor = true;
			this.optTopLeft.CheckedChanged += new System.EventHandler(this.optTopLeft_CheckedChanged);
			// 
			// lblLabels7
			// 
			this.lblLabels7.AccessibleDescription = null;
			this.lblLabels7.AccessibleName = null;
			resources.ApplyResources(this.lblLabels7, "lblLabels7");
			this.warningProvider1.SetError(this.lblLabels7, resources.GetString("lblLabels7.Error"));
			this.lblLabels7.Font = null;
			this.warningProvider1.SetIconAlignment(this.lblLabels7, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblLabels7.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.lblLabels7, ((int)(resources.GetObject("lblLabels7.IconPadding"))));
			this.lblLabels7.Name = "lblLabels7";
			// 
			// chkUseStamp
			// 
			this.chkUseStamp.AccessibleDescription = null;
			this.chkUseStamp.AccessibleName = null;
			resources.ApplyResources(this.chkUseStamp, "chkUseStamp");
			this.chkUseStamp.BackgroundImage = null;
			this.chkUseStamp.Checked = true;
			this.chkUseStamp.CheckState = System.Windows.Forms.CheckState.Checked;
			this.warningProvider1.SetError(this.chkUseStamp, resources.GetString("chkUseStamp.Error"));
			this.chkUseStamp.Font = null;
			this.warningProvider1.SetIconAlignment(this.chkUseStamp, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("chkUseStamp.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.chkUseStamp, ((int)(resources.GetObject("chkUseStamp.IconPadding"))));
			this.chkUseStamp.Name = "chkUseStamp";
			this.chkUseStamp.UseVisualStyleBackColor = true;
			this.chkUseStamp.CheckedChanged += new System.EventHandler(this.chkUseStamp_CheckedChanged);
			// 
			// grpResize
			// 
			this.grpResize.AccessibleDescription = null;
			this.grpResize.AccessibleName = null;
			resources.ApplyResources(this.grpResize, "grpResize");
			this.grpResize.BackgroundImage = null;
			this.grpResize.Controls.Add(this.numHeight);
			this.grpResize.Controls.Add(this.numWidth);
			this.grpResize.Controls.Add(this.trbQuality);
			this.grpResize.Controls.Add(this.lblLabels4);
			this.grpResize.Controls.Add(this.lblLabels3);
			this.grpResize.Controls.Add(this.lblLabels2);
			this.grpResize.Controls.Add(this.lblLabels1);
			this.warningProvider1.SetError(this.grpResize, resources.GetString("grpResize.Error"));
			this.grpResize.Font = null;
			this.warningProvider1.SetIconAlignment(this.grpResize, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("grpResize.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.grpResize, ((int)(resources.GetObject("grpResize.IconPadding"))));
			this.grpResize.Name = "grpResize";
			this.grpResize.TabStop = false;
			// 
			// numHeight
			// 
			this.numHeight.AccessibleDescription = null;
			this.numHeight.AccessibleName = null;
			resources.ApplyResources(this.numHeight, "numHeight");
			this.warningProvider1.SetError(this.numHeight, resources.GetString("numHeight.Error"));
			this.numHeight.Font = null;
			this.warningProvider1.SetIconAlignment(this.numHeight, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("numHeight.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.numHeight, ((int)(resources.GetObject("numHeight.IconPadding"))));
			this.numHeight.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
			this.numHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numHeight.Name = "numHeight";
			this.numHeight.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.numHeight.Leave += new System.EventHandler(this.numHeight_Leave);
			this.numHeight.Validating += new System.ComponentModel.CancelEventHandler(this.numHeight_Validating);
			// 
			// numWidth
			// 
			this.numWidth.AccessibleDescription = null;
			this.numWidth.AccessibleName = null;
			resources.ApplyResources(this.numWidth, "numWidth");
			this.warningProvider1.SetError(this.numWidth, resources.GetString("numWidth.Error"));
			this.numWidth.Font = null;
			this.warningProvider1.SetIconAlignment(this.numWidth, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("numWidth.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.numWidth, ((int)(resources.GetObject("numWidth.IconPadding"))));
			this.numWidth.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
			this.numWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numWidth.Name = "numWidth";
			this.numWidth.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.numWidth.Leave += new System.EventHandler(this.numWidth_Leave);
			this.numWidth.Validating += new System.ComponentModel.CancelEventHandler(this.numWidth_Validating);
			// 
			// trbQuality
			// 
			this.trbQuality.AccessibleDescription = null;
			this.trbQuality.AccessibleName = null;
			resources.ApplyResources(this.trbQuality, "trbQuality");
			this.trbQuality.BackgroundImage = null;
			this.warningProvider1.SetError(this.trbQuality, resources.GetString("trbQuality.Error"));
			this.trbQuality.Font = null;
			this.warningProvider1.SetIconAlignment(this.trbQuality, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("trbQuality.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.trbQuality, ((int)(resources.GetObject("trbQuality.IconPadding"))));
			this.trbQuality.Maximum = 100;
			this.trbQuality.Minimum = 1;
			this.trbQuality.Name = "trbQuality";
			this.trbQuality.TickFrequency = 10;
			this.trbQuality.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.trbQuality.Value = 90;
			this.trbQuality.Validating += new System.ComponentModel.CancelEventHandler(this.trbQuality_Validating);
			// 
			// lblLabels4
			// 
			this.lblLabels4.AccessibleDescription = null;
			this.lblLabels4.AccessibleName = null;
			resources.ApplyResources(this.lblLabels4, "lblLabels4");
			this.warningProvider1.SetError(this.lblLabels4, resources.GetString("lblLabels4.Error"));
			this.lblLabels4.Font = null;
			this.warningProvider1.SetIconAlignment(this.lblLabels4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblLabels4.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.lblLabels4, ((int)(resources.GetObject("lblLabels4.IconPadding"))));
			this.lblLabels4.Name = "lblLabels4";
			// 
			// lblLabels3
			// 
			this.lblLabels3.AccessibleDescription = null;
			this.lblLabels3.AccessibleName = null;
			resources.ApplyResources(this.lblLabels3, "lblLabels3");
			this.warningProvider1.SetError(this.lblLabels3, resources.GetString("lblLabels3.Error"));
			this.lblLabels3.Font = null;
			this.warningProvider1.SetIconAlignment(this.lblLabels3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblLabels3.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.lblLabels3, ((int)(resources.GetObject("lblLabels3.IconPadding"))));
			this.lblLabels3.Name = "lblLabels3";
			// 
			// lblLabels2
			// 
			this.lblLabels2.AccessibleDescription = null;
			this.lblLabels2.AccessibleName = null;
			resources.ApplyResources(this.lblLabels2, "lblLabels2");
			this.warningProvider1.SetError(this.lblLabels2, resources.GetString("lblLabels2.Error"));
			this.lblLabels2.Font = null;
			this.warningProvider1.SetIconAlignment(this.lblLabels2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblLabels2.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.lblLabels2, ((int)(resources.GetObject("lblLabels2.IconPadding"))));
			this.lblLabels2.Name = "lblLabels2";
			// 
			// lblLabels1
			// 
			this.lblLabels1.AccessibleDescription = null;
			this.lblLabels1.AccessibleName = null;
			resources.ApplyResources(this.lblLabels1, "lblLabels1");
			this.warningProvider1.SetError(this.lblLabels1, resources.GetString("lblLabels1.Error"));
			this.lblLabels1.Font = null;
			this.warningProvider1.SetIconAlignment(this.lblLabels1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblLabels1.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.lblLabels1, ((int)(resources.GetObject("lblLabels1.IconPadding"))));
			this.lblLabels1.Name = "lblLabels1";
			// 
			// splitSplitter1
			// 
			this.splitSplitter1.AccessibleDescription = null;
			this.splitSplitter1.AccessibleName = null;
			resources.ApplyResources(this.splitSplitter1, "splitSplitter1");
			this.splitSplitter1.BackgroundImage = null;
			this.warningProvider1.SetError(this.splitSplitter1, resources.GetString("splitSplitter1.Error"));
			this.splitSplitter1.Font = null;
			this.warningProvider1.SetIconAlignment(this.splitSplitter1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitSplitter1.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.splitSplitter1, ((int)(resources.GetObject("splitSplitter1.IconPadding"))));
			this.splitSplitter1.Name = "splitSplitter1";
			// 
			// splitSplitter1.Panel1
			// 
			this.splitSplitter1.Panel1.AccessibleDescription = null;
			this.splitSplitter1.Panel1.AccessibleName = null;
			resources.ApplyResources(this.splitSplitter1.Panel1, "splitSplitter1.Panel1");
			this.splitSplitter1.Panel1.BackgroundImage = null;
			this.splitSplitter1.Panel1.Controls.Add(this.lstItems);
			this.splitSplitter1.Panel1.Controls.Add(this.tlbFiles);
			this.warningProvider1.SetError(this.splitSplitter1.Panel1, resources.GetString("splitSplitter1.Panel1.Error"));
			this.splitSplitter1.Panel1.Font = null;
			this.warningProvider1.SetIconAlignment(this.splitSplitter1.Panel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitSplitter1.Panel1.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.splitSplitter1.Panel1, ((int)(resources.GetObject("splitSplitter1.Panel1.IconPadding"))));
			// 
			// splitSplitter1.Panel2
			// 
			this.splitSplitter1.Panel2.AccessibleDescription = null;
			this.splitSplitter1.Panel2.AccessibleName = null;
			resources.ApplyResources(this.splitSplitter1.Panel2, "splitSplitter1.Panel2");
			this.splitSplitter1.Panel2.BackgroundImage = null;
			this.splitSplitter1.Panel2.Controls.Add(this.splitSplitter2);
			this.warningProvider1.SetError(this.splitSplitter1.Panel2, resources.GetString("splitSplitter1.Panel2.Error"));
			this.splitSplitter1.Panel2.Font = null;
			this.warningProvider1.SetIconAlignment(this.splitSplitter1.Panel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitSplitter1.Panel2.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.splitSplitter1.Panel2, ((int)(resources.GetObject("splitSplitter1.Panel2.IconPadding"))));
			// 
			// lstItems
			// 
			this.lstItems.AccessibleDescription = null;
			this.lstItems.AccessibleName = null;
			resources.ApplyResources(this.lstItems, "lstItems");
			this.lstItems.BackgroundImage = null;
			this.lstItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colFolder});
			this.lstItems.ContextMenuStrip = this.cmnuItems;
			this.warningProvider1.SetError(this.lstItems, resources.GetString("lstItems.Error"));
			this.lstItems.Font = null;
			this.lstItems.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("lstItems.Groups"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("lstItems.Groups1")))});
			this.warningProvider1.SetIconAlignment(this.lstItems, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lstItems.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.lstItems, ((int)(resources.GetObject("lstItems.IconPadding"))));
			this.lstItems.LargeImageList = this.imlNormal;
			this.lstItems.Name = "lstItems";
			this.lstItems.SmallImageList = this.imlSmall;
			this.lstItems.UseCompatibleStateImageBehavior = false;
			this.lstItems.View = System.Windows.Forms.View.Details;
			this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
			// 
			// colName
			// 
			resources.ApplyResources(this.colName, "colName");
			// 
			// colFolder
			// 
			resources.ApplyResources(this.colFolder, "colFolder");
			// 
			// cmnuItems
			// 
			this.cmnuItems.AccessibleDescription = null;
			this.cmnuItems.AccessibleName = null;
			resources.ApplyResources(this.cmnuItems, "cmnuItems");
			this.cmnuItems.BackgroundImage = null;
			this.warningProvider1.SetError(this.cmnuItems, resources.GetString("cmnuItems.Error"));
			this.cmnuItems.Font = null;
			this.warningProvider1.SetIconAlignment(this.cmnuItems, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cmnuItems.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.cmnuItems, ((int)(resources.GetObject("cmnuItems.IconPadding"))));
			this.cmnuItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemsRecursive,
            this.mnuItemsLine1,
            this.mnuItemsRemove});
			this.cmnuItems.Name = "cmnuItems";
			this.cmnuItems.Opening += new System.ComponentModel.CancelEventHandler(this.cmnuItems_Opening);
			// 
			// mnuItemsRecursive
			// 
			this.mnuItemsRecursive.AccessibleDescription = null;
			this.mnuItemsRecursive.AccessibleName = null;
			resources.ApplyResources(this.mnuItemsRecursive, "mnuItemsRecursive");
			this.mnuItemsRecursive.BackgroundImage = null;
			this.mnuItemsRecursive.Name = "mnuItemsRecursive";
			this.mnuItemsRecursive.ShortcutKeyDisplayString = null;
			this.mnuItemsRecursive.Click += new System.EventHandler(this.mnuItemsRecursive_Click);
			// 
			// mnuItemsLine1
			// 
			this.mnuItemsLine1.AccessibleDescription = null;
			this.mnuItemsLine1.AccessibleName = null;
			resources.ApplyResources(this.mnuItemsLine1, "mnuItemsLine1");
			this.mnuItemsLine1.Name = "mnuItemsLine1";
			// 
			// mnuItemsRemove
			// 
			this.mnuItemsRemove.AccessibleDescription = null;
			this.mnuItemsRemove.AccessibleName = null;
			resources.ApplyResources(this.mnuItemsRemove, "mnuItemsRemove");
			this.mnuItemsRemove.BackgroundImage = null;
			this.mnuItemsRemove.Name = "mnuItemsRemove";
			this.mnuItemsRemove.ShortcutKeyDisplayString = null;
			this.mnuItemsRemove.Click += new System.EventHandler(this.mnuItemsRemove_Click_1);
			// 
			// imlNormal
			// 
			this.imlNormal.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlNormal.ImageStream")));
			this.imlNormal.TransparentColor = System.Drawing.Color.Transparent;
			this.imlNormal.Images.SetKeyName(0, "Folder - Open");
			this.imlNormal.Images.SetKeyName(1, "Folder - Special");
			this.imlNormal.Images.SetKeyName(2, "Folder - Zip");
			this.imlNormal.Images.SetKeyName(3, "Image - JPEG");
			this.imlNormal.Images.SetKeyName(4, "Image - PNG");
			this.imlNormal.Images.SetKeyName(5, "Image - BMP");
			this.imlNormal.Images.SetKeyName(6, "Image - GIF");
			this.imlNormal.Images.SetKeyName(7, "Image - Other");
			// 
			// imlSmall
			// 
			this.imlSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSmall.ImageStream")));
			this.imlSmall.TransparentColor = System.Drawing.Color.Transparent;
			this.imlSmall.Images.SetKeyName(0, "Folder - Open");
			this.imlSmall.Images.SetKeyName(1, "Folder - Special");
			this.imlSmall.Images.SetKeyName(2, "Folder - Zip");
			this.imlSmall.Images.SetKeyName(3, "Image - JPEG");
			this.imlSmall.Images.SetKeyName(4, "Image - PNG");
			this.imlSmall.Images.SetKeyName(5, "Image - BMP");
			this.imlSmall.Images.SetKeyName(6, "Image - GIF");
			this.imlSmall.Images.SetKeyName(7, "Image - Other");
			// 
			// tlbFiles
			// 
			this.tlbFiles.AccessibleDescription = null;
			this.tlbFiles.AccessibleName = null;
			resources.ApplyResources(this.tlbFiles, "tlbFiles");
			this.tlbFiles.BackgroundImage = null;
			this.warningProvider1.SetError(this.tlbFiles, resources.GetString("tlbFiles.Error"));
			this.tlbFiles.Font = null;
			this.tlbFiles.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.warningProvider1.SetIconAlignment(this.tlbFiles, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tlbFiles.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.tlbFiles, ((int)(resources.GetObject("tlbFiles.IconPadding"))));
			this.tlbFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddFiles,
            this.btnAddFolder,
            this.btnLine1,
            this.btnRemove,
            this.btnView});
			this.tlbFiles.Name = "tlbFiles";
			// 
			// btnAddFiles
			// 
			this.btnAddFiles.AccessibleDescription = null;
			this.btnAddFiles.AccessibleName = null;
			resources.ApplyResources(this.btnAddFiles, "btnAddFiles");
			this.btnAddFiles.BackgroundImage = null;
			this.btnAddFiles.Name = "btnAddFiles";
			this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
			// 
			// btnAddFolder
			// 
			this.btnAddFolder.AccessibleDescription = null;
			this.btnAddFolder.AccessibleName = null;
			resources.ApplyResources(this.btnAddFolder, "btnAddFolder");
			this.btnAddFolder.BackgroundImage = null;
			this.btnAddFolder.Name = "btnAddFolder";
			this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
			// 
			// btnLine1
			// 
			this.btnLine1.AccessibleDescription = null;
			this.btnLine1.AccessibleName = null;
			resources.ApplyResources(this.btnLine1, "btnLine1");
			this.btnLine1.Name = "btnLine1";
			// 
			// btnRemove
			// 
			this.btnRemove.AccessibleDescription = null;
			this.btnRemove.AccessibleName = null;
			resources.ApplyResources(this.btnRemove, "btnRemove");
			this.btnRemove.BackgroundImage = null;
			this.btnRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnRemove.DropDown = this.cmnuRemove;
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.ButtonClick += new System.EventHandler(this.btnRemove_ButtonClick);
			// 
			// cmnuRemove
			// 
			this.cmnuRemove.AccessibleDescription = null;
			this.cmnuRemove.AccessibleName = null;
			resources.ApplyResources(this.cmnuRemove, "cmnuRemove");
			this.cmnuRemove.BackgroundImage = null;
			this.warningProvider1.SetError(this.cmnuRemove, resources.GetString("cmnuRemove.Error"));
			this.cmnuRemove.Font = null;
			this.warningProvider1.SetIconAlignment(this.cmnuRemove, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cmnuRemove.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.cmnuRemove, ((int)(resources.GetObject("cmnuRemove.IconPadding"))));
			this.cmnuRemove.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRemoveRemove,
            this.mnuRemoveLine1,
            this.mnuRemoveClearAll});
			this.cmnuRemove.Name = "cmnuRemove";
			this.cmnuRemove.OwnerItem = this.btnRemove;
			// 
			// mnuRemoveRemove
			// 
			this.mnuRemoveRemove.AccessibleDescription = null;
			this.mnuRemoveRemove.AccessibleName = null;
			resources.ApplyResources(this.mnuRemoveRemove, "mnuRemoveRemove");
			this.mnuRemoveRemove.BackgroundImage = null;
			this.mnuRemoveRemove.Name = "mnuRemoveRemove";
			this.mnuRemoveRemove.ShortcutKeyDisplayString = null;
			this.mnuRemoveRemove.Click += new System.EventHandler(this.mnuRemoveRemove_Click);
			// 
			// mnuRemoveLine1
			// 
			this.mnuRemoveLine1.AccessibleDescription = null;
			this.mnuRemoveLine1.AccessibleName = null;
			resources.ApplyResources(this.mnuRemoveLine1, "mnuRemoveLine1");
			this.mnuRemoveLine1.Name = "mnuRemoveLine1";
			// 
			// mnuRemoveClearAll
			// 
			this.mnuRemoveClearAll.AccessibleDescription = null;
			this.mnuRemoveClearAll.AccessibleName = null;
			resources.ApplyResources(this.mnuRemoveClearAll, "mnuRemoveClearAll");
			this.mnuRemoveClearAll.BackgroundImage = null;
			this.mnuRemoveClearAll.Name = "mnuRemoveClearAll";
			this.mnuRemoveClearAll.ShortcutKeyDisplayString = null;
			this.mnuRemoveClearAll.Click += new System.EventHandler(this.mnuRemoveClearAll_Click);
			// 
			// btnView
			// 
			this.btnView.AccessibleDescription = null;
			this.btnView.AccessibleName = null;
			this.btnView.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			resources.ApplyResources(this.btnView, "btnView");
			this.btnView.BackgroundImage = null;
			this.btnView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnView.DropDown = this.cmnuView;
			this.btnView.Name = "btnView";
			this.btnView.ButtonClick += new System.EventHandler(this.btnView_ButtonClick);
			// 
			// cmnuView
			// 
			this.cmnuView.AccessibleDescription = null;
			this.cmnuView.AccessibleName = null;
			resources.ApplyResources(this.cmnuView, "cmnuView");
			this.cmnuView.BackgroundImage = null;
			this.warningProvider1.SetError(this.cmnuView, resources.GetString("cmnuView.Error"));
			this.cmnuView.Font = null;
			this.warningProvider1.SetIconAlignment(this.cmnuView, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cmnuView.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.cmnuView, ((int)(resources.GetObject("cmnuView.IconPadding"))));
			this.cmnuView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewTile,
            this.mnuViewLargeIcons,
            this.mnuViewList,
            this.mnuViewDetails});
			this.cmnuView.Name = "cmnuView";
			this.cmnuView.OwnerItem = this.btnView;
			// 
			// mnuViewTile
			// 
			this.mnuViewTile.AccessibleDescription = null;
			this.mnuViewTile.AccessibleName = null;
			resources.ApplyResources(this.mnuViewTile, "mnuViewTile");
			this.mnuViewTile.BackgroundImage = null;
			this.mnuViewTile.Name = "mnuViewTile";
			this.mnuViewTile.ShortcutKeyDisplayString = null;
			this.mnuViewTile.Click += new System.EventHandler(this.mnuViewTile_Click);
			// 
			// mnuViewLargeIcons
			// 
			this.mnuViewLargeIcons.AccessibleDescription = null;
			this.mnuViewLargeIcons.AccessibleName = null;
			resources.ApplyResources(this.mnuViewLargeIcons, "mnuViewLargeIcons");
			this.mnuViewLargeIcons.BackgroundImage = null;
			this.mnuViewLargeIcons.Name = "mnuViewLargeIcons";
			this.mnuViewLargeIcons.ShortcutKeyDisplayString = null;
			this.mnuViewLargeIcons.Click += new System.EventHandler(this.mnuViewLargeIcons_Click);
			// 
			// mnuViewList
			// 
			this.mnuViewList.AccessibleDescription = null;
			this.mnuViewList.AccessibleName = null;
			resources.ApplyResources(this.mnuViewList, "mnuViewList");
			this.mnuViewList.BackgroundImage = null;
			this.mnuViewList.Name = "mnuViewList";
			this.mnuViewList.ShortcutKeyDisplayString = null;
			this.mnuViewList.Click += new System.EventHandler(this.mnuViewList_Click);
			// 
			// mnuViewDetails
			// 
			this.mnuViewDetails.AccessibleDescription = null;
			this.mnuViewDetails.AccessibleName = null;
			resources.ApplyResources(this.mnuViewDetails, "mnuViewDetails");
			this.mnuViewDetails.BackgroundImage = null;
			this.mnuViewDetails.Name = "mnuViewDetails";
			this.mnuViewDetails.ShortcutKeyDisplayString = null;
			this.mnuViewDetails.Click += new System.EventHandler(this.mnuViewDetails_Click);
			// 
			// stbStatus
			// 
			this.stbStatus.AccessibleDescription = null;
			this.stbStatus.AccessibleName = null;
			resources.ApplyResources(this.stbStatus, "stbStatus");
			this.stbStatus.BackgroundImage = null;
			this.warningProvider1.SetError(this.stbStatus, resources.GetString("stbStatus.Error"));
			this.stbStatus.Font = null;
			this.warningProvider1.SetIconAlignment(this.stbStatus, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("stbStatus.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.stbStatus, ((int)(resources.GetObject("stbStatus.IconPadding"))));
			this.stbStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFileCount});
			this.stbStatus.Name = "stbStatus";
			// 
			// lblFileCount
			// 
			this.lblFileCount.AccessibleDescription = null;
			this.lblFileCount.AccessibleName = null;
			resources.ApplyResources(this.lblFileCount, "lblFileCount");
			this.lblFileCount.BackgroundImage = null;
			this.lblFileCount.Name = "lblFileCount";
			// 
			// mmnuMain
			// 
			this.mmnuMain.AccessibleDescription = null;
			this.mmnuMain.AccessibleName = null;
			resources.ApplyResources(this.mmnuMain, "mmnuMain");
			this.mmnuMain.BackgroundImage = null;
			this.warningProvider1.SetError(this.mmnuMain, resources.GetString("mmnuMain.Error"));
			this.mmnuMain.Font = null;
			this.warningProvider1.SetIconAlignment(this.mmnuMain, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("mmnuMain.IconAlignment"))));
			this.warningProvider1.SetIconPadding(this.mmnuMain, ((int)(resources.GetObject("mmnuMain.IconPadding"))));
			this.mmnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuProject,
            this.mnuHelp});
			this.mmnuMain.Name = "mmnuMain";
			// 
			// mnuFile
			// 
			this.mnuFile.AccessibleDescription = null;
			this.mnuFile.AccessibleName = null;
			resources.ApplyResources(this.mnuFile, "mnuFile");
			this.mnuFile.BackgroundImage = null;
			this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNewProject,
            this.mnuFileOpenProject,
            this.mnuFileSaveProject,
            this.mnuFileSaveProjectAs,
            this.mnuFileLine1,
            this.mnuFileExit});
			this.mnuFile.Name = "mnuFile";
			this.mnuFile.ShortcutKeyDisplayString = null;
			// 
			// mnuFileNewProject
			// 
			this.mnuFileNewProject.AccessibleDescription = null;
			this.mnuFileNewProject.AccessibleName = null;
			resources.ApplyResources(this.mnuFileNewProject, "mnuFileNewProject");
			this.mnuFileNewProject.BackgroundImage = null;
			this.mnuFileNewProject.Name = "mnuFileNewProject";
			this.mnuFileNewProject.ShortcutKeyDisplayString = null;
			// 
			// mnuFileOpenProject
			// 
			this.mnuFileOpenProject.AccessibleDescription = null;
			this.mnuFileOpenProject.AccessibleName = null;
			resources.ApplyResources(this.mnuFileOpenProject, "mnuFileOpenProject");
			this.mnuFileOpenProject.BackgroundImage = null;
			this.mnuFileOpenProject.Name = "mnuFileOpenProject";
			this.mnuFileOpenProject.ShortcutKeyDisplayString = null;
			// 
			// mnuFileSaveProject
			// 
			this.mnuFileSaveProject.AccessibleDescription = null;
			this.mnuFileSaveProject.AccessibleName = null;
			resources.ApplyResources(this.mnuFileSaveProject, "mnuFileSaveProject");
			this.mnuFileSaveProject.BackgroundImage = null;
			this.mnuFileSaveProject.Name = "mnuFileSaveProject";
			this.mnuFileSaveProject.ShortcutKeyDisplayString = null;
			// 
			// mnuFileSaveProjectAs
			// 
			this.mnuFileSaveProjectAs.AccessibleDescription = null;
			this.mnuFileSaveProjectAs.AccessibleName = null;
			resources.ApplyResources(this.mnuFileSaveProjectAs, "mnuFileSaveProjectAs");
			this.mnuFileSaveProjectAs.BackgroundImage = null;
			this.mnuFileSaveProjectAs.Name = "mnuFileSaveProjectAs";
			this.mnuFileSaveProjectAs.ShortcutKeyDisplayString = null;
			// 
			// mnuFileLine1
			// 
			this.mnuFileLine1.AccessibleDescription = null;
			this.mnuFileLine1.AccessibleName = null;
			resources.ApplyResources(this.mnuFileLine1, "mnuFileLine1");
			this.mnuFileLine1.Name = "mnuFileLine1";
			// 
			// mnuFileExit
			// 
			this.mnuFileExit.AccessibleDescription = null;
			this.mnuFileExit.AccessibleName = null;
			resources.ApplyResources(this.mnuFileExit, "mnuFileExit");
			this.mnuFileExit.BackgroundImage = null;
			this.mnuFileExit.Name = "mnuFileExit";
			this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
			// 
			// mnuProject
			// 
			this.mnuProject.AccessibleDescription = null;
			this.mnuProject.AccessibleName = null;
			resources.ApplyResources(this.mnuProject, "mnuProject");
			this.mnuProject.BackgroundImage = null;
			this.mnuProject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProjectAddFiles,
            this.mnuProjectAddFolder,
            this.mnuProjectLine1,
            this.mnuProjectRemove,
            this.mnuProjectLine2,
            this.mnuProjectClearAll});
			this.mnuProject.Name = "mnuProject";
			this.mnuProject.ShortcutKeyDisplayString = null;
			// 
			// mnuProjectAddFiles
			// 
			this.mnuProjectAddFiles.AccessibleDescription = null;
			this.mnuProjectAddFiles.AccessibleName = null;
			resources.ApplyResources(this.mnuProjectAddFiles, "mnuProjectAddFiles");
			this.mnuProjectAddFiles.BackgroundImage = null;
			this.mnuProjectAddFiles.Name = "mnuProjectAddFiles";
			this.mnuProjectAddFiles.ShortcutKeyDisplayString = null;
			this.mnuProjectAddFiles.Click += new System.EventHandler(this.mnuProjectAddFiles_Click);
			// 
			// mnuProjectAddFolder
			// 
			this.mnuProjectAddFolder.AccessibleDescription = null;
			this.mnuProjectAddFolder.AccessibleName = null;
			resources.ApplyResources(this.mnuProjectAddFolder, "mnuProjectAddFolder");
			this.mnuProjectAddFolder.BackgroundImage = null;
			this.mnuProjectAddFolder.Name = "mnuProjectAddFolder";
			this.mnuProjectAddFolder.ShortcutKeyDisplayString = null;
			this.mnuProjectAddFolder.Click += new System.EventHandler(this.mnuProjectAddFolder_Click);
			// 
			// mnuProjectLine1
			// 
			this.mnuProjectLine1.AccessibleDescription = null;
			this.mnuProjectLine1.AccessibleName = null;
			resources.ApplyResources(this.mnuProjectLine1, "mnuProjectLine1");
			this.mnuProjectLine1.Name = "mnuProjectLine1";
			// 
			// mnuProjectRemove
			// 
			this.mnuProjectRemove.AccessibleDescription = null;
			this.mnuProjectRemove.AccessibleName = null;
			resources.ApplyResources(this.mnuProjectRemove, "mnuProjectRemove");
			this.mnuProjectRemove.BackgroundImage = null;
			this.mnuProjectRemove.Name = "mnuProjectRemove";
			this.mnuProjectRemove.ShortcutKeyDisplayString = null;
			this.mnuProjectRemove.Click += new System.EventHandler(this.mnuProjectRemove_Click);
			// 
			// mnuProjectLine2
			// 
			this.mnuProjectLine2.AccessibleDescription = null;
			this.mnuProjectLine2.AccessibleName = null;
			resources.ApplyResources(this.mnuProjectLine2, "mnuProjectLine2");
			this.mnuProjectLine2.Name = "mnuProjectLine2";
			// 
			// mnuProjectClearAll
			// 
			this.mnuProjectClearAll.AccessibleDescription = null;
			this.mnuProjectClearAll.AccessibleName = null;
			resources.ApplyResources(this.mnuProjectClearAll, "mnuProjectClearAll");
			this.mnuProjectClearAll.BackgroundImage = null;
			this.mnuProjectClearAll.Name = "mnuProjectClearAll";
			this.mnuProjectClearAll.ShortcutKeyDisplayString = null;
			this.mnuProjectClearAll.Click += new System.EventHandler(this.mnuProjectClearAll_Click);
			// 
			// mnuHelp
			// 
			this.mnuHelp.AccessibleDescription = null;
			this.mnuHelp.AccessibleName = null;
			resources.ApplyResources(this.mnuHelp, "mnuHelp");
			this.mnuHelp.BackgroundImage = null;
			this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpAbout});
			this.mnuHelp.Name = "mnuHelp";
			this.mnuHelp.ShortcutKeyDisplayString = null;
			// 
			// mnuHelpAbout
			// 
			this.mnuHelpAbout.AccessibleDescription = null;
			this.mnuHelpAbout.AccessibleName = null;
			resources.ApplyResources(this.mnuHelpAbout, "mnuHelpAbout");
			this.mnuHelpAbout.BackgroundImage = null;
			this.mnuHelpAbout.Name = "mnuHelpAbout";
			this.mnuHelpAbout.ShortcutKeyDisplayString = null;
			this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
			// 
			// warningProvider1
			// 
			this.warningProvider1.ContainerControl = this;
			resources.ApplyResources(this.warningProvider1, "warningProvider1");
			// 
			// dlgFolder
			// 
			resources.ApplyResources(this.dlgFolder, "dlgFolder");
			// 
			// dlgOpenStamp
			// 
			this.dlgOpenStamp.DefaultExt = "png";
			resources.ApplyResources(this.dlgOpenStamp, "dlgOpenStamp");
			// 
			// dlgAddFiles
			// 
			this.dlgAddFiles.DefaultExt = "jpg";
			resources.ApplyResources(this.dlgAddFiles, "dlgAddFiles");
			this.dlgAddFiles.Multiselect = true;
			// 
			// dlgAddFolder
			// 
			resources.ApplyResources(this.dlgAddFolder, "dlgAddFolder");
			this.dlgAddFolder.ShowNewFolderButton = false;
			// 
			// bgWorker
			// 
			this.bgWorker.WorkerReportsProgress = true;
			this.bgWorker.WorkerSupportsCancellation = true;
			this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
			this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
			this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
			// 
			// imlTile
			// 
			this.imlTile.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTile.ImageStream")));
			this.imlTile.TransparentColor = System.Drawing.Color.Transparent;
			this.imlTile.Images.SetKeyName(0, "Folder - Open");
			this.imlTile.Images.SetKeyName(1, "Folder - Special");
			this.imlTile.Images.SetKeyName(2, "Folder - Zip");
			this.imlTile.Images.SetKeyName(3, "Image - JPEG");
			this.imlTile.Images.SetKeyName(4, "Image - PNG");
			this.imlTile.Images.SetKeyName(5, "Image - BMP");
			this.imlTile.Images.SetKeyName(6, "Image - GIF");
			this.imlTile.Images.SetKeyName(7, "Image - Other");
			// 
			// frmMain
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.Controls.Add(this.splitSplitter1);
			this.Controls.Add(this.stbStatus);
			this.Controls.Add(this.mmnuMain);
			this.Font = null;
			this.MainMenuStrip = this.mmnuMain;
			this.Name = "frmMain";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.splitSplitter2.Panel1.ResumeLayout(false);
			this.splitSplitter2.Panel2.ResumeLayout(false);
			this.splitSplitter2.Panel2.PerformLayout();
			this.splitSplitter2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pctPreview)).EndInit();
			this.grpSave.ResumeLayout(false);
			this.grpSave.PerformLayout();
			this.grpStamp.ResumeLayout(false);
			this.grpStamp.PerformLayout();
			this.pnlStamp.ResumeLayout(false);
			this.pnlStamp.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numVerticalMargin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numHorizontalMargin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trbTransparency)).EndInit();
			this.pnlPosition.ResumeLayout(false);
			this.grpResize.ResumeLayout(false);
			this.grpResize.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trbQuality)).EndInit();
			this.splitSplitter1.Panel1.ResumeLayout(false);
			this.splitSplitter1.Panel1.PerformLayout();
			this.splitSplitter1.Panel2.ResumeLayout(false);
			this.splitSplitter1.ResumeLayout(false);
			this.cmnuItems.ResumeLayout(false);
			this.tlbFiles.ResumeLayout(false);
			this.tlbFiles.PerformLayout();
			this.cmnuRemove.ResumeLayout(false);
			this.cmnuView.ResumeLayout(false);
			this.stbStatus.ResumeLayout(false);
			this.stbStatus.PerformLayout();
			this.mmnuMain.ResumeLayout(false);
			this.mmnuMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.warningProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitSplitter1;
		private System.Windows.Forms.StatusStrip stbStatus;
		private System.Windows.Forms.ToolStrip tlbFiles;
		private System.Windows.Forms.ToolStripButton btnAddFiles;
		private System.Windows.Forms.ToolStripButton btnAddFolder;
		private System.Windows.Forms.ToolStripSeparator btnLine1;
		private System.Windows.Forms.SplitContainer splitSplitter2;
		private System.Windows.Forms.PictureBox pctPreview;
		private System.Windows.Forms.ToolStripStatusLabel lblFileCount;
		private System.Windows.Forms.GroupBox grpResize;
		private System.Windows.Forms.Label lblLabels3;
		private System.Windows.Forms.Label lblLabels2;
		private System.Windows.Forms.Label lblLabels1;
		private System.Windows.Forms.TrackBar trbQuality;
		private System.Windows.Forms.Label lblLabels4;
		private System.Windows.Forms.GroupBox grpStamp;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.TextBox txtStampFile;
		private System.Windows.Forms.Label lblLabels5;
		private System.Windows.Forms.CheckBox chkUseStamp;
		private System.Windows.Forms.Label lblLabels6;
		private System.Windows.Forms.RadioButton optSizeToFit;
		private System.Windows.Forms.RadioButton optPosition;
		private System.Windows.Forms.RadioButton optStretchToFit;
		private System.Windows.Forms.Panel pnlPosition;
		private System.Windows.Forms.RadioButton optBottomRight;
		private System.Windows.Forms.RadioButton optBottom;
		private System.Windows.Forms.RadioButton optBottomLeft;
		private System.Windows.Forms.RadioButton optRight;
		private System.Windows.Forms.RadioButton optCenter;
		private System.Windows.Forms.RadioButton optLeft;
		private System.Windows.Forms.RadioButton optTopRight;
		private System.Windows.Forms.RadioButton optTop;
		private System.Windows.Forms.RadioButton optTopLeft;
		private System.Windows.Forms.Label lblLabels7;
		private System.Windows.Forms.Label lblLabels10;
		private System.Windows.Forms.Label lblLabels9;
		private System.Windows.Forms.Label lblLabels8;
		private System.Windows.Forms.TrackBar trbTransparency;
		private System.Windows.Forms.Label lblLabels11;
		private System.Windows.Forms.GroupBox grpSave;
		private System.Windows.Forms.Label lblLabels12;
		private System.Windows.Forms.TextBox txtNewFilename;
		private System.Windows.Forms.Button btnEditName;
		private System.Windows.Forms.Button btnBrowseFolder;
		private System.Windows.Forms.TextBox txtFolder;
		private System.Windows.Forms.Label lblLabels13;
		private System.Windows.Forms.Button btnExecute;
		private System.Windows.Forms.ErrorProvider warningProvider1;
		private System.Windows.Forms.CheckBox chkUseSourceFolder;
		private System.Windows.Forms.CheckBox chkCreateSubfolders;
		private System.Windows.Forms.Panel pnlStamp;
		private System.Windows.Forms.FolderBrowserDialog dlgFolder;
		private System.Windows.Forms.OpenFileDialog dlgOpenStamp;
		private System.Windows.Forms.OpenFileDialog dlgAddFiles;
		private System.Windows.Forms.FolderBrowserDialog dlgAddFolder;
		private System.Windows.Forms.ProgressBar prbPreviewProgress;
		private System.ComponentModel.BackgroundWorker bgWorker;
		private System.Windows.Forms.NumericUpDown numVerticalMargin;
		private System.Windows.Forms.NumericUpDown numHorizontalMargin;
		private System.Windows.Forms.NumericUpDown numHeight;
		private System.Windows.Forms.NumericUpDown numWidth;
		private System.Windows.Forms.ToolStripSplitButton btnRemove;
		private System.Windows.Forms.MenuStrip mmnuMain;
		private System.Windows.Forms.ToolStripMenuItem mnuFile;
		private System.Windows.Forms.ToolStripMenuItem mnuFileNewProject;
		private System.Windows.Forms.ToolStripMenuItem mnuFileOpenProject;
		private System.Windows.Forms.ToolStripMenuItem mnuFileSaveProject;
		private System.Windows.Forms.ToolStripMenuItem mnuFileSaveProjectAs;
		private System.Windows.Forms.ToolStripSeparator mnuFileLine1;
		private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
		private System.Windows.Forms.ToolStripMenuItem mnuHelp;
		private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
		private System.Windows.Forms.ToolStripMenuItem mnuProject;
		private System.Windows.Forms.ToolStripMenuItem mnuProjectAddFiles;
		private System.Windows.Forms.ToolStripMenuItem mnuProjectAddFolder;
		private System.Windows.Forms.ToolStripSeparator mnuProjectLine1;
		private System.Windows.Forms.ToolStripMenuItem mnuProjectRemove;
		private System.Windows.Forms.ToolStripSeparator mnuProjectLine2;
		private System.Windows.Forms.ToolStripMenuItem mnuProjectClearAll;
		private System.Windows.Forms.ListView lstItems;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.ColumnHeader colFolder;
		private System.Windows.Forms.ContextMenuStrip cmnuItems;
		private System.Windows.Forms.ToolStripMenuItem mnuItemsRecursive;
		private System.Windows.Forms.ToolStripSeparator mnuItemsLine1;
		private System.Windows.Forms.ToolStripMenuItem mnuItemsRemove;
		private System.Windows.Forms.ContextMenuStrip cmnuRemove;
		private System.Windows.Forms.ToolStripMenuItem mnuRemoveRemove;
		private System.Windows.Forms.ToolStripSeparator mnuRemoveLine1;
		private System.Windows.Forms.ToolStripMenuItem mnuRemoveClearAll;
		private System.Windows.Forms.ImageList imlSmall;
		private System.Windows.Forms.ImageList imlNormal;
		private System.Windows.Forms.ImageList imlTile;
		private System.Windows.Forms.ToolStripSplitButton btnView;
		private System.Windows.Forms.ContextMenuStrip cmnuView;
		private System.Windows.Forms.ToolStripMenuItem mnuViewTile;
		private System.Windows.Forms.ToolStripMenuItem mnuViewLargeIcons;
		private System.Windows.Forms.ToolStripMenuItem mnuViewList;
		private System.Windows.Forms.ToolStripMenuItem mnuViewDetails;
		private System.Windows.Forms.Label lblPreviewName;
		private System.Windows.Forms.RadioButton optNewFilenameSimple;
		private System.Windows.Forms.Label lblNewFilenameExample;
		private System.Windows.Forms.TextBox txtNewFilenameEnd;
		private System.Windows.Forms.TextBox txtNewFilenameStart;
		private System.Windows.Forms.Label lblLabels15;
		private System.Windows.Forms.RadioButton optNewFilenameAdvanced;
	}
}

