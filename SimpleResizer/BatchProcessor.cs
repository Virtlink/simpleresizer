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
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using SimpleResizer.Properties;

namespace SimpleResizer
{
	#region Enums
	/// <summary>
	/// Specifies the current
	/// </summary>
	public enum CurrentProcess
	{
		/// <summary>
		/// No process is currenly active.
		/// </summary>
		None = 0,
		/// <summary>
		/// Items are being collected.
		/// </summary>
		Collecting = 1,
		/// <summary>
		/// Items are being validated.
		/// </summary>
		Validating = 2,
		/// <summary>
		/// Items are being processed.
		/// </summary>
		Processing = 3
	}
	#endregion

	/// <summary>
	/// Handles the processing of the <see cref="Batch"/>.
	/// </summary>
	public class BatchProcessor
	{
		#region Fields
		/// <summary>
		/// The depth of updates, set using the <see cref="BeginUpdate"/>
		/// and <see cref="EndUpdate"/> methods.
		/// </summary>
		private int _iUpdateLevel = 0;

		/// <summary>
		/// The items to be processed.
		/// </summary>
		protected ProcessingItem[] ProcessingItems;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="BatchProcessor"/>
		/// class.
		/// </summary>
		/// <param name="batch">The <see cref="Batch"/> to process.</param>
		public BatchProcessor(Batch batch)
			: this(batch, null, null)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="BatchProcessor"/>
		/// class.
		/// </summary>
		/// <param name="batch">The <see cref="Batch"/> to process.</param>
		/// <param name="worker">The <see cref="BackgroundWorker"/> used.</param>
		/// <param name="workerArgs">The <see cref="DoWorkEventArgs"/> used.</param>
		public BatchProcessor(Batch batch, BackgroundWorker worker, DoWorkEventArgs workerArgs)
		{
			if (batch == null)
				throw new ArgumentNullException("batch");

			m_xBatch = batch;
			m_fWorker = worker;
			m_fWorkerArgs = workerArgs;

			m_cStatistics = new Dictionary<string, int>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BatchProcessor"/>
		/// class.
		/// </summary>
		/// <param name="item">The <see cref="BatchItem"/> to process.</param>
		/// <param name="worker">The <see cref="BackgroundWorker"/> used.</param>
		/// <param name="workerArgs">The <see cref="DoWorkEventArgs"/> used.</param>
		public BatchProcessor(BatchItem item, BackgroundWorker worker, DoWorkEventArgs workerArgs)
		{
			m_xBatch = null;
			m_fWorker = worker;
			m_fWorkerArgs = workerArgs;

			m_xCurrentItem = item;
			m_iTotalItems = 1;

			m_cStatistics = new Dictionary<string, int>();
		}
		#endregion

		#region Properties
		private Batch m_xBatch;
		/// <summary>
		/// Gets the <see cref="Batch"/> to process.
		/// </summary>
		/// <value>A <see cref="Batch"/>; or <see cref="null"/>.</value>
		public Batch Batch
		{
			get { return m_xBatch; }
		}

		private BackgroundWorker m_fWorker = null;
		/// <summary>
		/// Gets the <see cref="BackgroundWorker"/> used.
		/// </summary>
		/// <value>A <see cref="BackgroundWorker"/>;
		/// or <see cref="null"/>.</value>
		public BackgroundWorker Worker
		{
			get { return m_fWorker; }
		}

		private DoWorkEventArgs m_fWorkerArgs = null;
		/// <summary>
		/// Gets the <see cref="DoWorkEventArgs"/> used.
		/// </summary>
		/// <value>A <see cref="DoWorkEventArgs"/>;
		/// or <see cref="null"/>.</value>
		public DoWorkEventArgs WorkerArgs
		{
			get { return m_fWorkerArgs; }
		}

		private CurrentProcess m_eCurrentProcess;
		/// <summary>
		/// Gets the current process of this <see cref="BatchProcessor"/>.
		/// </summary>
		/// <value>A member of the <see cref="CurrentProcess"/>
		/// enumeration.</value>
		public CurrentProcess CurrentProcess
		{
			get { return m_eCurrentProcess; }
			protected set
			{
				if (m_eCurrentProcess != value)
				{
					m_eCurrentProcess = value;
					m_iCurrentItemIndex = 0;
					m_iCurrentStepIndex = 0;
					ReportProgress();
				}
			}
		}

		private BatchItem m_xCurrentItem;
		/// <summary>
		/// Gets the <see cref="BatchItem"/> currently
		/// being processed.
		/// </summary>
		/// <value>The <see cref="BatchItem"/> currently
		/// being processed.</value>
		public BatchItem CurrentItem
		{
			get { return m_xCurrentItem; }
			protected set
			{
				m_xCurrentItem = value;
				ReportProgress();
			}
		}

		private int m_iCurrentStepIndex = 0;
		/// <summary>
		/// Gets the currently executed step for the current item.
		/// </summary>
		/// <value>The currently executed step for the current item,
		/// which is a zero-based index.</value>
		public int CurrentStepIndex
		{
			get { return m_iCurrentStepIndex; }
			protected set
			{
				m_iCurrentStepIndex = value;
				ReportProgress();
			}
		}

		private int m_iTotalSteps = 0;
		/// <summary>
		/// Gets the total steps to be executed for the current item.
		/// </summary>
		/// <value>The total steps to be executed for the current item.</value>
		public int TotalSteps
		{
			get { return m_iTotalSteps; }
			protected set
			{
				m_iTotalSteps = value;
				ReportProgress();
			}
		}

		private int m_iCurrentItemIndex = 0;
		/// <summary>
		/// Gets the currently processed item.
		/// </summary>
		/// <value>The currently processed item,
		/// which is a zero-based index.</value>
		public int CurrentItemIndex
		{
			get { return m_iCurrentItemIndex; }
			protected set
			{
				m_iCurrentItemIndex = value;
				ReportProgress();
			}
		}

		private int m_iTotalItems = 0;
		/// <summary>
		/// Gets the total items to be processed.
		/// </summary>
		/// <value>The total items to be processed.</value>
		public int TotalItems
		{
			get { return m_iTotalItems; }
			protected set
			{
				m_iTotalItems = value;
				ReportProgress();
			}
		}

		private Dictionary<string, int> m_cStatistics;
		/// <summary>
		/// Gets a dictionary containing the statistics of this operation.
		/// </summary>
		/// <value>A <see cref="Dictionary{TKey, TValue}"/> with
		/// <see cref="String"/> keys and <see cref="Int32"/> values.</value>
		public Dictionary<string, int> Statistics
		{
			get { return m_cStatistics; }
		}
		#endregion

		#region Methods
		/// <summary>
		/// Processes the items.
		/// </summary>
		/// <returns>Whether this process was succesfull.</returns>
		public bool Process()
		{ PreviewResult result; return Process(false, false, -1, out result); }

		/// <summary>
		/// Processes the items.
		/// </summary>
		/// <param name="notValidate"><see cref="true"/> when the
		/// items should not be validated; otherwise,
		/// <see cref="false"/>.</param>
		/// <param name="notSave"><see cref="true"/> when the
		/// resulting images should not be saved; otherwise,
		/// <see cref="false"/>.</param>
		/// <param name="indexToReturn">The index of the
		/// <see cref="BatchItem"/> from which a preview must be returned;
		/// or -1.</param>
		/// <param name="preview">The requested <see cref="PreviewResult"/>.</param>
		/// <returns>Whether this process was succesfull.</returns>
		public bool Process(bool notValidate, bool notSave, int indexToReturn, out PreviewResult preview)
		{
			bool result;

			// 1) Collect the items.
			result = CollectItems();
			if (!result)
			{
				preview = PreviewResult.Empty;
				WorkerArgs.Cancel = true;
				return false;
			}

			// 2) Validate the items.
			result = ValidateItems(notValidate);
			if (!result)
			{
				preview = PreviewResult.Empty;
				WorkerArgs.Cancel = true;
				return false;
			}

			// Solve the problems found.
			result = SolveProblems();
			if (!result)
			{
				preview = PreviewResult.Empty;
				WorkerArgs.Cancel = true;
				return false;
			}

			// 3) Process the items
			Image image;
			result = ProcessItems(notSave, indexToReturn, out image);
			if (!result)
			{
				preview = PreviewResult.Empty;
				WorkerArgs.Cancel = true;
				return false;
			}

			if (indexToReturn >= 0 && indexToReturn < ProcessingItems.Length)
				preview = new PreviewResult(image, ProcessingItems[indexToReturn].TargetPath);
			else
				preview = PreviewResult.Empty;
			WorkerArgs.Result = this;
			return true;
		}

		/// <summary>
		/// Asks the user whether he or she wants to continue,
		/// and what to do about the solvable problems.
		/// </summary>
		/// <returns><see cref="true"/> when the problems have been solved;
		/// otherwise, <see cref="false"/> when the operation is cancelled.</returns>
		protected bool SolveProblems()
		{
			if (Statistics["DuplicateItems"] > 0 || Statistics["NonExistantItems"] > 0 || (Statistics["ClashItems"] - Statistics["ClashItemsWithoutCSF"]) > 0)
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(Resources.MsgProblemSolverIntro);
				if (Statistics["DuplicateItems"] > 0)
				{
					sb.Append("\r\n- ");
					if (Statistics["DuplicateItems"] == 1)
						sb.Append(Resources.MsgProblemSolverDupSingle);
					else
						sb.Append(String.Format(Resources.MsgProblemSolverDupMultiple, Statistics["DuplicateItems"]));
				}
				if (Statistics["NonExistantItems"] > 0)
				{
					if (Statistics["DuplicateItems"] > 0)
						sb.Append(";");
					sb.Append("\r\n- ");

					if (Statistics["NonExistantItems"] == 1)
						sb.Append(Resources.MsgProblemSolverNonExtSingle);
					else
						sb.Append(String.Format(Resources.MsgProblemSolverNonExtMultiple, Statistics["NonExistantItems"]));
				}
				int onlyClash = Statistics["ClashItems"] - Statistics["ClashItemsWithoutCSF"];
				if (onlyClash > 0)
				{
					if (Statistics["DuplicateItems"] > 0 || Statistics["NonExistantItems"] > 0)
						sb.Append(";");
					sb.Append("\r\n- ");

					if (onlyClash == 1)
						sb.Append(Resources.MsgProblemSolverClashSingle);
					else
						sb.Append(String.Format(Resources.MsgProblemSolverClashMultiple, onlyClash));
				}
				sb.Append(".\r\n\r\n");
				sb.Append(Resources.MsgProblemSolverOutro);
				if (MessageBox.Show(sb.ToString(), Resources.MsgProblemSolverTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
					return false;
			}

			bool skipExisting = false;
			if (Statistics["ExistingTargetItems"] > 0)
			{
				string msg;
				if (Statistics["ExistingTargetItems"] == 1)
					msg = Resources.MsgProblemSolverDestExistsSingle;
				else
					msg = String.Format(Resources.MsgProblemSolverDestExistsMultiple, Statistics["ExistingTargetItems"]);
				DialogResult result = MessageBox.Show(msg, Resources.MsgProblemSolverDestExistsTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
				if (result == DialogResult.Cancel)
					return false;
				else if (result == DialogResult.No)
					skipExisting = true;
			}

			bool skipClash = false;
			if (Statistics["ClashItemsWithoutCSF"] > 0)
			{
				string msg;
				if (Statistics["ClashItemsWithoutCSF"] == 1)
					msg = Resources.MsgProblemSolverClashCSFSingle;
				else
					msg = String.Format(Resources.MsgProblemSolverClashCSFMultiple, Statistics["ClashItemsWithoutCSF"]);
				
				DialogResult result = MessageBox.Show(msg, Resources.MsgProblemSolverClashCSFTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
				if (result == DialogResult.Cancel)
					return false;
				else if (result == DialogResult.No)
					skipClash = true;
			}

			if (!skipClash && this.ProcessingItems.Length > 0)
				// They all use the same BatchProcessSettings object,
				// so setting CreateSubFolders on the first one is good enough.
				this.ProcessingItems[0].Settings.CreateSubFolders = true;
			for (int q = 0; q < ProcessingItems.Length; q++)
			{
				ProcessingItem itm = ProcessingItems[q];
				if ((itm.ValidationFlags & ValidationFlags.Duplicate) != 0 ||
					((itm.ValidationFlags & ValidationFlags.FileClash) != 0 &&
					(itm.ValidationFlags & ValidationFlags.FileClashWithoutCreateSubFolders) == 0) ||
					(itm.ValidationFlags & ValidationFlags.NonExistant) != 0)
					itm.Ignore = true;
				if (skipExisting && (itm.ValidationFlags & ValidationFlags.FileExists) != 0)
					itm.Ignore = true;
				if (skipClash && (itm.ValidationFlags & ValidationFlags.FileClashWithoutCreateSubFolders) != 0)
					itm.Ignore = true;
				else if ((itm.ValidationFlags & ValidationFlags.FileClashWithoutCreateSubFolders) != 0)
					itm.TargetPath = GetTargetFullPath(itm, q, itm.Index);		//, true);
			}

			return true;
		}

		/// <summary>
		/// Returns the <see cref="PreviewResult"/> of the first item
		/// in this <see cref="BatchProcessor"/>.
		/// </summary>
		/// <returns>The <see cref="PreviewResult"/> of the first item
		/// in this <see cref="BatchProcessor"/>.</returns>
		public PreviewResult Preview()
		{
			PreviewResult result;
			Process(true, true, 0, out result);
			return result;
		}

		/// <summary>
		/// Checks whether the process has been cancelled.
		/// </summary>
		/// <returns><see cref="true"/> when the process has been
		/// cancelled; otherwise, <see cref="false"/>.</returns>
		/// <remarks>Immediately after this method returns <see cref="true"/>,
		/// the calling code should dispose any resources and return.</remarks>
		protected bool CheckCancel()
		{
			if (Worker != null && Worker.CancellationPending)
			{
				if (WorkerArgs != null)
					WorkerArgs.Cancel = true;
				return true;
			}
			return false;
		}

		/// <summary>
		/// Signifies the beginning of an update of multiple properties.
		/// </summary>
		internal void BeginUpdate()
		{ _iUpdateLevel++; }

		/// <summary>
		/// Signifies the end of an update of multiple properties.
		/// </summary>
		internal void EndUpdate()
		{
			if (_iUpdateLevel > 0)
				_iUpdateLevel--;
			if (_iUpdateLevel == 0)
				ReportProgress();
		}

		/// <summary>
		/// Reports the progress of the action.
		/// </summary>
		protected virtual void ReportProgress()
		{
			if (_iUpdateLevel > 0)
				return;
			int progress = (int)((100f / ((float)TotalItems)) * (((float)CurrentItemIndex) + (((float)CurrentStepIndex) / ((float)TotalSteps))));
			Worker.ReportProgress(progress, this);
		}

		/// <summary>
		/// Collects the <see cref="ProcessingItem"/> objects
		/// from which <see cref="Batch"/> consists.
		/// </summary>
		/// <returns><see cref="true"/> when this process went succesfull;
		/// otherwise, <see cref="false"/>.</returns>
		protected bool CollectItems()
		{
			if (Batch == null)
				return CollectSingleItem();
			else
				return CollectBatchItems();
		}

		/// <summary>
		/// Collects the <see cref="ProcessingItem"/> objects
		/// from which <see cref="Batch"/> consists.
		/// </summary>
		/// <returns><see cref="true"/> when this process went succesfull;
		/// otherwise, <see cref="false"/>.</returns>
		protected virtual bool CollectBatchItems()
		{
			BeginUpdate();
			CurrentProcess = CurrentProcess.Collecting;
			TotalItems = Batch.Count;
			CurrentItemIndex = 0;
			TotalSteps = 1;
			CurrentStepIndex = 0;
			Statistics.Clear();
			Statistics.Add("Collected", 0);
			EndUpdate();

			List<ProcessingItem> procItems = new List<ProcessingItem>();
			for (int q = 0; q < Batch.Count; q++)
			{
				if (CheckCancel())
				{
					ProcessingItems = procItems.ToArray();
					return false;
				}
				BeginUpdate();
				CurrentItem = Batch[q];
				CurrentItemIndex = q;
				EndUpdate();

				procItems.AddRange(Batch[q].GetProcessingItems(this));
				Statistics["Collected"] = procItems.Count;
			}

			ProcessingItems = procItems.ToArray();
			return true;
		}

		/// <summary>
		/// Collects the <see cref="ProcessingItem"/> objects
		/// from the <see cref="CurrentItem"/>.
		/// </summary>
		/// <returns><see cref="true"/> when this process went succesfull;
		/// otherwise, <see cref="false"/>.</returns>
		protected virtual bool CollectSingleItem()
		{
			BeginUpdate();
			CurrentProcess = CurrentProcess.Collecting;
			TotalItems = 1;
			CurrentItemIndex = 0;
			TotalSteps = 1;
			CurrentStepIndex = 0;
			Statistics.Clear();
			Statistics.Add("Collected", 0);
			EndUpdate();

			List<ProcessingItem> procItems = new List<ProcessingItem>();
			if (CheckCancel())
			{
				ProcessingItems = procItems.ToArray();
				return false;
			}

			procItems.AddRange(CurrentItem.GetProcessingItems(this));
			Statistics["Collected"] = 1;

			ProcessingItems = procItems.ToArray();
			return true;
		}

		/// <summary>
		/// Validates the <see cref="ProcessingItem"/> objects
		/// from which <see cref="Batch"/> consists.
		/// </summary>
		/// <param name="notValidate">When <see cref="true"/>; the
		/// items are not validated.</param>
		/// <returns><see cref="true"/> when this process went succesfull;
		/// otherwise, <see cref="false"/>.</returns>
		protected virtual bool ValidateItems(bool notValidate)
		{
			BeginUpdate();
			CurrentProcess = CurrentProcess.Validating;
			TotalItems = ProcessingItems.Length;
			CurrentItemIndex = 0;
			TotalSteps = 6;
			CurrentStepIndex = 0;
			// The number of items with are duplicate.
			Statistics.Add("DuplicateItems", 0);
			// The number of items whose source file does not exist.
			Statistics.Add("NonExistantItems", 0);
			// The number of items whose target file already exists.
			Statistics.Add("ExistingTargetItems", 0);
			// The number of items whose target file clashes with another
			// item's target file, inclusing those from clashItemsWithoutCSB.
			Statistics.Add("ClashItems", 0);
			// The number of items whose target file clashes which another
			// item's target file, and which would be solved when
			// BatchProcessSettings.CreateSubFolders is set to true.
			Statistics.Add("ClashItemsWithoutCSF", 0);
			EndUpdate();

			for (int q = 0; q < ProcessingItems.Length; q++)
			{
				if (CheckCancel()) return false;
				BeginUpdate();
				CurrentItem = ProcessingItems[q].Item;
				CurrentItemIndex = q;
				CurrentStepIndex = 0;
				EndUpdate();

				// Get the new path for this item.
				ProcessingItems[q].TargetPath = GetTargetFullPath(
					ProcessingItems[q],
					q,
					ProcessingItems[q].Index);

				if (!notValidate)
				{
					CurrentStepIndex = 0;
					// 1) Check whether file exists.
					if (!ProcessingItems[q].File.Exists)
					{
						ProcessingItems[q].ValidationFlags |= ValidationFlags.NonExistant;
						// Non existant items are automatically ignored.
						ProcessingItems[q].Ignore = true;
						Statistics["NonExistantItems"]++;
					}

					CurrentStepIndex = 1;
					// TODO: 2) Check whether the new path is valid (length, characters, format).

					CurrentStepIndex = 2;
					// 3) Check whether a file with the new filename already exists.
					if (File.Exists(ProcessingItems[q].TargetPath))
					{
						ProcessingItems[q].ValidationFlags |= ValidationFlags.FileExists;
						Statistics["ExistingTargetItems"]++;
					}

					CurrentStepIndex = 3;
					CurrentStepIndex = 4;
					// 4) Duplicates. 5) Clash.
					for (int r = 0; r < q; r++)
					{
						// Check for duplicates.
						if (String.Compare(ProcessingItems[q].File.FullName, ProcessingItems[r].File.FullName, true) == 0)
						{
							ProcessingItems[q].ValidationFlags |= ValidationFlags.Duplicate;
							// Duplicate items are automatically ignored.
							ProcessingItems[q].Ignore = true;
							Statistics["DuplicateItems"]++;
							// When the item is duplicate, it is ignored.
							// So no need to continue checking against other items.
							break;
						}

						// Check whether this file clashes with another file to
						// be created.
						if (ProcessingItems[r].TargetPath != null &&
							ProcessingItems[r].TargetPath.ToLower() == ProcessingItems[q].TargetPath.ToLower())
						{
							if (ProcessingItems[q].Settings.CreateSubFolders == false)
							{
								// Check whether this problem would be solved when
								// BatchProcessSettings.CreateSubFolder
								// is set to true.
								if (GetTargetFullPath(ProcessingItems[q], q, ProcessingItems[q].Index, true).ToLower()
									!= GetTargetFullPath(ProcessingItems[r], r, ProcessingItems[r].Index, true).ToLower())
								{
									ProcessingItems[q].ValidationFlags |= ValidationFlags.FileClashWithoutCreateSubFolders;
									Statistics["ClashItemsWithoutCSF"]++;
								}
							}
							ProcessingItems[q].ValidationFlags |= ValidationFlags.FileClash;
							Statistics["ClashItems"]++;
							// When the item clashes, it may be ignored.
							// So no need to continue checking against other items.
							break;
						}
					}

					CurrentStepIndex = 5;
					// TODO: 6) Check whether the target directory can be written to.
				}
			}

			return true;
		}

		/// <summary>
		/// Returns the full path to the target file of the
		/// specified <see cref="ProcessingItem"/>.
		/// </summary>
		/// <param name="item">The <see cref="ProcessingItem"/>
		/// whose target full path must be determined.</param>
		/// <param name="globalCount">The global counter. This
		/// equals the zero-based index of this item in the array of
		/// <see cref="ProcessingItem"/> objects generated from
		/// the <see cref="Batch"/>.</param>
		/// <returns>The full path to the target file of <paramref name="item"/>.</returns>
		protected string GetTargetFullPath(ProcessingItem item, int globalCount)
		{ return GetTargetFullPath(item, globalCount, 0, item.Settings.DestinationFolder, item.Settings.CreateSubFolders); }

		/// <summary>
		/// Returns the full path to the target file of the
		/// specified <see cref="ProcessingItem"/>.
		/// </summary>
		/// <param name="item">The <see cref="ProcessingItem"/>
		/// whose target full path must be determined.</param>
		/// <param name="globalCount">The global counter. This
		/// equals the zero-based index of this item in the array of
		/// <see cref="ProcessingItem"/> objects generated from
		/// the <see cref="Batch"/>.</param>
		/// <param name="localCount">The local counter. This
		/// equals the zero-based index of this item in it's
		/// owning <see cref="BatchFolder"/>. For a <see cref="BatchFile"/>,
		/// this is 0.</param>
		/// <returns>The full path to the target file of <paramref name="item"/>.</returns>
		protected string GetTargetFullPath(ProcessingItem item, int globalCount, int localCount)
		{ return GetTargetFullPath(item, globalCount, localCount, item.Settings.DestinationFolder, item.Settings.CreateSubFolders); }

		/// <summary>
		/// Returns the full path to the target file of the
		/// specified <see cref="ProcessingItem"/>.
		/// </summary>
		/// <param name="item">The <see cref="ProcessingItem"/>
		/// whose target full path must be determined.</param>
		/// <param name="globalCount">The global counter. This
		/// equals the zero-based index of this item in the array of
		/// <see cref="ProcessingItem"/> objects generated from
		/// the <see cref="Batch"/>.</param>
		/// <param name="localCount">The local counter. This
		/// equals the zero-based index of this item in it's
		/// owning <see cref="BatchFolder"/>. For a <see cref="BatchFile"/>,
		/// this is 0.</param>
		/// <param name="defaultDestinationFolder">The default
		/// destination <see cref="FolderInfo"/>; or <see cref="null"/>.</param>
		/// <returns>The full path to the target file of <paramref name="item"/>.</returns>
		protected string GetTargetFullPath(ProcessingItem item, int globalCount, int localCount, DirectoryInfo defaultDestinationFolder)
		{ return GetTargetFullPath(item, globalCount, localCount, defaultDestinationFolder, item.Settings.CreateSubFolders); }

		/// <summary>
		/// Returns the full path to the target file of the
		/// specified <see cref="ProcessingItem"/>.
		/// </summary>
		/// <param name="item">The <see cref="ProcessingItem"/>
		/// whose target full path must be determined.</param>
		/// <param name="globalCount">The global counter. This
		/// equals the zero-based index of this item in the array of
		/// <see cref="ProcessingItem"/> objects generated from
		/// the <see cref="Batch"/>.</param>
		/// <param name="localCount">The local counter. This
		/// equals the zero-based index of this item in it's
		/// owning <see cref="BatchFolder"/>. For a <see cref="BatchFile"/>,
		/// this is 0.</param>
		/// <param name="createSubFolders">Whether to create subfolders
		/// in the destination folder.</param>
		/// <returns>The full path to the target file of <paramref name="item"/>.</returns>
		protected string GetTargetFullPath(ProcessingItem item, int globalCount, int localCount, bool createSubFolders)
		{ return GetTargetFullPath(item, globalCount, localCount, item.Settings.DestinationFolder, createSubFolders); }

		/// <summary>
		/// Returns the full path to the target file of the
		/// specified <see cref="ProcessingItem"/>.
		/// </summary>
		/// <param name="item">The <see cref="ProcessingItem"/>
		/// whose target full path must be determined.</param>
		/// <param name="globalCount">The global counter. This
		/// equals the zero-based index of this item in the array of
		/// <see cref="ProcessingItem"/> objects generated from
		/// the <see cref="Batch"/>.</param>
		/// <param name="localCount">The local counter. This
		/// equals the zero-based index of this item in it's
		/// owning <see cref="BatchFolder"/>. For a <see cref="BatchFile"/>,
		/// this is 0.</param>
		/// <param name="defaultDestinationFolder">The default
		/// destination <see cref="FolderInfo"/>; or <see cref="null"/>.</param>
		/// <param name="createSubFolders">Whether to create subfolders
		/// in the destination folder.</param>
		/// <returns>The full path to the target file of <paramref name="item"/>.</returns>
		protected virtual string GetTargetFullPath(ProcessingItem item, int globalCount, int localCount, DirectoryInfo defaultDestinationFolder, bool createSubFolders)
		{
			StringBuilder sb = new StringBuilder(item.Settings.NewFilenamePattern);
			
			// %n	Bestandsnaam
			sb.Replace("%n", Path.GetFileNameWithoutExtension(item.File.Name));
			// %e	Extentie
			if (Path.GetExtension(item.File.Name).Length > 0)
				sb.Replace("%e", Path.GetExtension(item.File.Name).Substring(1));
			else
				sb.Replace("%e", string.Empty);

			//// %f	Parent mapnaam
			//if (item.Item != null && item.Item is BatchFolder)
			//    sb.Replace("%f", ((BatchFolder)item.Item).Directory.Name);
			//else
			//    sb.Replace("%f", String.Empty);

			// %c#	Globale teller (# = aantal cijfers, 0 = zoveel als nodig)
			if (globalCount >= 0)
			{
				// Add 1 to globalCount, because our users start counting at 1.
				sb.Replace("%c0", (globalCount + 1).ToString());
				for (int q = 1; q <= 9; q++)
				{ sb.Replace("%c" + q.ToString(), GetCounter(globalCount + 1, q)); }
				sb.Replace("%c", (globalCount + 1).ToString());
			}
			else
			{
				for (int q = 0; q <= 9; q++)
				{ sb.Replace("%c" + q.ToString(), String.Empty); }
				sb.Replace("%c", String.Empty);
			}

			// %i#	Lokale teller (per map) (# = aantal cijfers, 0 = zoveel als nodig)
			if (localCount >= 0)
			{
				// Add 1 to localCount, because our users start counting at 1.
				sb.Replace("%i0", (localCount + 1).ToString());
				for (int q = 1; q <= 9; q++)
				{ sb.Replace("%i" + q.ToString(), GetCounter(localCount + 1, q)); }
				sb.Replace("%i", (localCount + 1).ToString());
			}
			else
			{
				for (int q = 0; q <= 9; q++)
				{ sb.Replace("%i" + q.ToString(), String.Empty); }
				sb.Replace("%i", String.Empty);
			}

			sb.Replace("%%", "%");

			string basePath = item.GetTargetFolderPath(defaultDestinationFolder, createSubFolders);
			return Path.Combine(basePath, sb.ToString());
		}

		/// <summary>
		/// Returns the left-padded string of a counter.
		/// </summary>
		/// <param name="counter">The counter value.</param>
		/// <param name="length">The length of the counter's string.</param>
		/// <returns>The counter's string, left-padded with zeros.</returns>
		protected string GetCounter(int counter, int length)
		{
			StringBuilder sb = new StringBuilder();
			string c = counter.ToString();
			for (int q = 0; q < length - c.Length; q++)
			{ sb.Append("0"); }
			sb.Append(c);
			return sb.ToString();
		}

		/// <summary>
		/// Processes the <see cref="ProcessingItem"/> objects
		/// from which <see cref="Batch"/> consists.
		/// </summary>
		/// <param name="notSave">When <see cref="true"/>, the resulting
		/// <see cref="Image"/> is not saved.</param>
		/// <param name="indexToReturn">The index of the <see cref="BatchItem"/>
		/// whose <see cref="Image"/> must be returned.</param>
		/// <param name="image">The <see cref="Image"/> to return.</param>
		/// <returns><see cref="true"/> when this process went succesfull;
		/// otherwise, <see cref="false"/>.</returns>
		protected virtual bool ProcessItems(bool notSave, int indexToReturn, out Image image)
		{
			image = null;
			BeginUpdate();
			CurrentProcess = CurrentProcess.Processing;
			TotalItems = ProcessingItems.Length;
			CurrentItemIndex = 0;
			TotalSteps = 2;
			CurrentStepIndex = 0;
			Statistics.Clear();
			Statistics.Add("Skipped", 0);
			EndUpdate();

			for (int q = 0; q < ProcessingItems.Length; q++)
			{
				if (CheckCancel()) return false;
				BeginUpdate();
				CurrentItem = ProcessingItems[q].Item;
				CurrentItemIndex = q;
				CurrentStepIndex = 0;
				EndUpdate();

				// Skip through the collection real quick when possible.
				if (notSave && (indexToReturn < 0 || image != null || (this.Batch != null && ProcessingItems[q].Item != this.Batch[indexToReturn])))
					continue;

				if (ProcessingItems[q].Ignore)
				{
					ProcessingItems[q].ProcessingFlags |= ProcessingFlags.Skipped;
					Statistics["Skipped"]++;
					CurrentStepIndex = TotalSteps;
					continue;
				}

				CurrentStepIndex = 0;
				// 1) Create the image.
				Image img = CreateImage(ProcessingItems[q].File, ProcessingItems[q].Settings);	//, bgExecutioner, progressParts * q, progressParts * (q + 1), report);
				if (img == null)
				{ return false; }	// TODO: Report an error.

				// Return the image when nescessary.
				if (image == null && indexToReturn >= 0 && (this.Batch == null || ProcessingItems[q].Item == this.Batch[indexToReturn]))
					image = img;

				CurrentStepIndex = 1;
				// 2) Save the image.
				if (!notSave)
				{
					EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, ProcessingItems[q].Settings.Quality);
					ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
					EncoderParameters encoderParams = new EncoderParameters(1);
					encoderParams.Param[0] = qualityParam;

					if (!File.Exists(ProcessingItems[q].TargetPath) ||
						(ProcessingItems[q].ValidationFlags & ValidationFlags.FileExists) != 0)
					{
						// Overwrite when file exists and validation flags is
						// set to FileExists, which means that the item is not
						// ignored (Ignore == false) and the system knows that
						// this file exists.
						if (!Directory.Exists(Path.GetDirectoryName(ProcessingItems[q].TargetPath)))
							Directory.CreateDirectory(Path.GetDirectoryName(ProcessingItems[q].TargetPath));
						img.Save(ProcessingItems[q].TargetPath, jpegCodec, encoderParams);
					}
					else
					{
						ProcessingItems[q].ProcessingFlags |= ProcessingFlags.Skipped;
						Statistics["Skipped"]++;
					}
				}
			}

			return true;
		}

		/// <summary>
		/// Creates an <see cref="Image"/> from the specified file,
		/// with the specified settings.
		/// </summary>
		/// <param name="file">The <see cref="FileInfo"/> of the image's
		/// source file.</param>
		/// <param name="settings">The <see cref="BatchProcessSettings"/>
		/// used for this operation.</param>
		/// <returns>The created <see cref="Image"/>; or <see cref="null"/>
		/// when an error occured.</returns>
		protected virtual Image CreateImage(FileInfo file, BatchProcessSettings settings)		//, BackgroundWorker worker, float progressStart, float progressEnd, ProgressReport report)
		{
			if (file == null || !file.Exists)
				return null;

			// Load the image.
			Image img;
			try
			{
				img = Image.FromFile(file.FullName);
			}
			catch	// TODO: Catch exceptions.
			{ return null; }
			// FIXME: With VERY large files (or corrupted files), you may get an
			// OutOfMemoryException here. Had it, once, with autoexec.bat?!?

			// Resize the image.
			Size s1 = CalculateSize(img.Width, img.Height, settings.MaxWidth, settings.MaxHeight, false);
			Bitmap bmp = new Bitmap(s1.Width, s1.Height);
			Graphics g = Graphics.FromImage(bmp);
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
			img.Dispose();

			// Draw the stamp.
			if (settings.StampFile != null && settings.StampFile.Exists)
			{
				ImageAttributes ia = GetTransparencyMatrix(1f - settings.StampTransparency);
				Image stampImg = Image.FromFile(settings.StampFile.FullName);
				switch (settings.StampPlacement)
				{
					case StampPlacement.Scale:
						Size s2 = CalculateSize(stampImg.Width, stampImg.Height, s1.Width, s1.Height, true);
						g.DrawImage(stampImg, new Rectangle(
							(bmp.Width - s2.Width) / 2,
							(bmp.Height - s2.Height) / 2,
							s2.Width, s2.Height),
							0, 0, stampImg.Width, stampImg.Height,
							GraphicsUnit.Pixel, ia);
						break;
					case StampPlacement.Stretch:
						g.DrawImage(stampImg, new Rectangle(
							0, 0,
							bmp.Width, bmp.Height),
							0, 0, stampImg.Width, stampImg.Height,
							GraphicsUnit.Pixel, ia);
						break;
					case StampPlacement.TopLeft:
						g.DrawImage(stampImg, new Rectangle(
							settings.HorizontalDistance,
							settings.VerticalDistance,
							stampImg.Width, stampImg.Height),
							0, 0, stampImg.Width, stampImg.Height,
							GraphicsUnit.Pixel, ia);
						break;
					case StampPlacement.Top:
						g.DrawImage(stampImg, new Rectangle(
							(bmp.Width - stampImg.Width) / 2,
							settings.VerticalDistance,
							stampImg.Width, stampImg.Height),
							0, 0, stampImg.Width, stampImg.Height,
							GraphicsUnit.Pixel, ia);
						break;
					case StampPlacement.TopRight:
						g.DrawImage(stampImg, new Rectangle(
							bmp.Width - settings.HorizontalDistance - stampImg.Width,
							settings.VerticalDistance,
							stampImg.Width, stampImg.Height),
							0, 0, stampImg.Width, stampImg.Height,
							GraphicsUnit.Pixel, ia);
						break;
					case StampPlacement.Left:
						g.DrawImage(stampImg, new Rectangle(
							settings.HorizontalDistance,
							(bmp.Height - stampImg.Height) / 2,
							stampImg.Width, stampImg.Height),
							0, 0, stampImg.Width, stampImg.Height,
							GraphicsUnit.Pixel, ia);
						break;
					case StampPlacement.Center:
						g.DrawImage(stampImg, new Rectangle(
							(bmp.Width - stampImg.Width) / 2,
							(bmp.Height - stampImg.Height) / 2,
							stampImg.Width, stampImg.Height),
							0, 0, stampImg.Width, stampImg.Height,
							GraphicsUnit.Pixel, ia);
						break;
					case StampPlacement.Right:
						g.DrawImage(stampImg, new Rectangle(
							bmp.Width - settings.HorizontalDistance - stampImg.Width,
							(bmp.Height - stampImg.Height) / 2,
							stampImg.Width, stampImg.Height),
							0, 0, stampImg.Width, stampImg.Height,
							GraphicsUnit.Pixel, ia);
						break;
					case StampPlacement.BottomLeft:
						g.DrawImage(stampImg, new Rectangle(
							settings.HorizontalDistance,
							bmp.Height - settings.VerticalDistance - stampImg.Height,
							stampImg.Width, stampImg.Height),
							0, 0, stampImg.Width, stampImg.Height,
							GraphicsUnit.Pixel, ia);
						break;
					case StampPlacement.Bottom:
						g.DrawImage(stampImg, new Rectangle(
							(bmp.Width - stampImg.Width) / 2,
							bmp.Height - settings.VerticalDistance - stampImg.Height,
							stampImg.Width, stampImg.Height),
							0, 0, stampImg.Width, stampImg.Height,
							GraphicsUnit.Pixel, ia);
						break;
					case StampPlacement.BottomRight:
						g.DrawImage(stampImg, new Rectangle(
							bmp.Width - settings.HorizontalDistance - stampImg.Width,
							bmp.Height - settings.VerticalDistance - stampImg.Height,
							stampImg.Width, stampImg.Height),
							0, 0, stampImg.Width, stampImg.Height,
							GraphicsUnit.Pixel, ia);
						break;
					default:
						goto case StampPlacement.Scale;
				}
				stampImg.Dispose();
			}

			// Finish.
			g.Dispose();
			return bmp;
		}

		/// <summary>
		/// Returns the transparency matrix used for the transparency of
		/// the stamp.
		/// </summary>
		/// <param name="opacity">The opacity, between 0.0 and 1.0,
		/// where 0.0 is transparant and 1.0 is opaque.</param>
		/// <returns>An <see cref="ImageAttributes"/> object.</returns>
		protected ImageAttributes GetTransparencyMatrix(float opacity)
		{
			float[][] ptsArray = { 
				new float[] {1, 0, 0, 0, 0},
				new float[] {0, 1, 0, 0, 0},
				new float[] {0, 0, 1, 0, 0},
				new float[] {0, 0, 0, opacity, 0}, 
				new float[] {0, 0, 0, 0, 1}};
			ColorMatrix cm = new ColorMatrix(ptsArray);
			ImageAttributes ia = new ImageAttributes();
			ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
			return ia;
		}

		/// <summary>
		/// Calculates the new size of an object with a specified size,
		/// which must fit in a space of a specified size.
		/// </summary>
		/// <param name="width">The width of the object.</param>
		/// <param name="height">The height of the object.</param>
		/// <param name="newWidth">The width of the space.</param>
		/// <param name="newHeight">The height of the space.</param>
		/// <param name="allowLarger">When <see cref="true"/>, the object is allowed
		/// to size beyond it's original size.</param>
		/// <returns>The new <see cref="Size"/> of the object.</returns>
		protected Size CalculateSize(int width, int height, int newWidth, int newHeight, bool allowLarger)
		{
			float dX = (float)newWidth / (float)width;
			if (!allowLarger && dX > 1f) dX = 1f;
			float dY = (float)newHeight / (float)height;
			if (!allowLarger && dY > 1f) dY = 1f;
			float d = Math.Min(dX, dY);
			return new Size((int)(width * d), (int)(height * d));
		}

		/// <summary>
		/// Returns the image codec with the specified MIME type.
		/// </summary>
		/// <param name="mimeType">The MIME type to look for.</param>
		/// <returns>The <see cref="ImageCodecInfo"/> of the codec if
		/// found; otherwise, <see cref="null"/>.</returns>
		protected ImageCodecInfo GetEncoderInfo(string mimeType)
		{
			// Get image codecs for all image formats.
			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

			// Find the correct image codec.
			for (int i = 0; i < codecs.Length; i++)
				if (codecs[i].MimeType == mimeType)
					return codecs[i];
			return null;
		}
		#endregion
	}
}
