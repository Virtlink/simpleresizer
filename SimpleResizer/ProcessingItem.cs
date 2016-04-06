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
using System.IO;

namespace SimpleResizer
{
	#region Enums
	[Flags]
	public enum ValidationFlags
	{
		/// <summary>
		/// No flags are set.
		/// </summary>
		None = 0x0000,
		/// <summary>
		/// This <see cref="ProcessingItem"/> is a duplicate.
		/// </summary>
		Duplicate = 0x0001,
		/// <summary>
		/// This <see cref="ProcessingItem"/> does not exist (anymore).
		/// </summary>
		NonExistant = 0x0002,
		/// <summary>
		/// The new path to the processed file is too long.
		/// </summary>
		PathTooLong = 0x0004,
		/// <summary>
		/// The new path to the processed file contains invalid
		/// characters or has an invalid format.
		/// </summary>
		PathInvalid = 0x0008,
		/// <summary>
		/// The file to be created already exists.
		/// </summary>
		FileExists = 0x0010,
		/// <summary>
		/// The file to be created is the same as another file to be created.
		/// </summary>
		FileClash = 0x0020,
		/// <summary>
		/// The file to be created is the same as another file to be created,
		/// and this would not be the case when
		/// <see cref="BatchProcessSettings.CreateSubFolders"/> would be
		/// set to <see cref="true"/>.
		/// </summary>
		FileClashWithoutCreateSubFolders = FileClash | 0x0040
	}

	[Flags]
	public enum ProcessingFlags
	{
		None = 0x0000,
		ProcessedSuccess = 0x0001,
		Skipped = 0x0002,
		Exception = 0x0004,
		
	}
	#endregion

	/// <summary>
	/// A file which will be processed.
	/// </summary>
	public class ProcessingItem
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ProcessingItem"/> struct.
		/// </summary>
		/// <param name="associatedFile">The associated <see cref="BatchFile"/>.</param>
		/// <param name="settings">The <see cref="BatchProcessSettings"/>.</param>
		public ProcessingItem(BatchFile associatedFile, BatchProcessSettings settings)
		{
			if (associatedFile == null)
				throw new ArgumentNullException("associatedFile");
			if (settings == null)
				throw new ArgumentNullException("settings");

			m_xItem = associatedFile;
			m_fFile = associatedFile.File;
			m_xSettings = settings;
			m_iIndex = -1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ProcessingItem"/> struct.
		/// </summary>
		/// <param name="associatedFolder">The associated <see cref="BatchFolder"/>.</param>
		/// <param name="settings">The <see cref="BatchProcessSettings"/>.</param>
		/// <param name="file">The <see cref="FileInfo"/> of the
		/// file to process.</param>
		public ProcessingItem(BatchFolder associatedFolder, BatchProcessSettings settings, FileInfo file, int index)
		{
			if (file == null)
				throw new ArgumentNullException("file");
			if (settings == null)
				throw new ArgumentNullException("settings");
			if (index < -1)
				throw new ArgumentOutOfRangeException("index", "Index cannot be lower than -1.");

			m_xItem = associatedFolder;
			m_fFile = file;
			m_xSettings = settings;
			m_iIndex = index;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ProcessingItem"/> struct.
		/// </summary>
		/// <param name="settings">The <see cref="BatchProcessSettings"/>.</param>
		/// <param name="file">The <see cref="FileInfo"/> of the
		/// file to process.</param>
		public ProcessingItem(BatchProcessSettings settings, FileInfo file)
			: this(null, settings, file, -1)
		{ }
		#endregion

		#region Properties
		private BatchItem m_xItem;
		/// <summary>
		/// Gets the <see cref="BatchItem"/> associated
		/// with this item.
		/// </summary>
		/// <value>A <see cref="BatchItem"/>; or <see cref="null"/>
		/// when this item is not associated with any
		/// <see cref="BatchItem"/>.</value>
		/// <remarks>When a <see cref="ProcessingItem"/>
		/// is the counterpart of a <see cref="BatchFile"/>,
		/// then that counterpart is this property's value.
		/// When a <see cref="ProcessingItem"/> results from
		/// the contents of a <see cref="BatchFolder"/> then
		/// this folder is this property's value.</remarks>
		public BatchItem Item
		{
			get { return m_xItem; }
		}

		private FileInfo m_fFile;
		/// <summary>
		/// Gets the file represented by this <see cref="ProcessingItem"/>.
		/// </summary>
		/// <value>A <see cref="FileInfo"/> object.</value>
		public FileInfo File
		{
			get { return m_fFile; }
		}

		private ValidationFlags m_eValidationFlags = ValidationFlags.None;
		/// <summary>
		/// Gets or sets the result of the validation.
		/// </summary>
		/// <value>A bitwise combination of members of
		/// the <see cref="ValidationFlags"/> enumeration.</value>
		public ValidationFlags ValidationFlags
		{
			get { return m_eValidationFlags; }
			set { m_eValidationFlags = value; }
		}

		private ProcessingFlags m_eProcessingFlags = ProcessingFlags.None;
		/// <summary>
		/// Gets or sets the result of the processing.
		/// </summary>
		/// <value>A bitwise combination of members of
		/// the <see cref="ProcessingFlags"/> enumeration.</value>
		public ProcessingFlags ProcessingFlags
		{
			get { return m_eProcessingFlags; }
			set { m_eProcessingFlags = value; }
		}

		private bool m_bIgnore = false;
		/// <summary>
		/// Gets or sets whether to skip this item.
		/// </summary>
		/// <value><see cref="true"/> to skip this item;
		/// otherwise, <see cref="false"/>.</value>
		/// <remarks>Items will be ignored when they are duplicates
		/// of another item to process, or when it would overwrite
		/// a file which the user does not want to overwrite.</remarks>
		public bool Ignore
		{
			get { return m_bIgnore; }
			set { m_bIgnore = value; }
		}

		private BatchProcessSettings m_xSettings;
		/// <summary>
		/// Gets or sets the settings for this item.
		/// </summary>
		/// <value>A <see cref="BatchProcessSettings"/> object.</value>
		public BatchProcessSettings Settings
		{
			get { return m_xSettings; }
		}

		private int m_iIndex;	// = -1;
		/// <summary>
		/// Gets the index of this <see cref="ProcessingItem"/>
		/// in it's current source directory.
		/// </summary>
		/// <value>An index.</value>
		public int Index
		{
			get { return m_iIndex; }
			//set { m_iIndex = value; }
		}

		private string m_sTargetPath = null;
		/// <summary>
		/// Gets or sets the target full path of this item.
		/// </summary>
		/// <value>A valid path.</value>
		public string TargetPath
		{
			get { return m_sTargetPath; }
			set { m_sTargetPath = value; }
		}
		#endregion

		#region Methods
		/// <summary>
		/// Processes the item.
		/// </summary>
		public void Process()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the path to the (non-existant) folder in which the
		/// processed item will be saved.
		/// </summary>
		/// <returns>The path to the (non-existant) folder in which
		/// the processed item will be saved.</returns>
		public string GetTargetFolderPath()
		{ return GetTargetFolderPath(this.Settings.DestinationFolder, this.Settings.CreateSubFolders); }

		/// <summary>
		/// Gets the path to the (non-existant) folder in which the
		/// processed item will be saved.
		/// </summary>
		/// <param name="destinationFolder">The destination folder
		/// for this item; or <see cref="null"/>.</param>
		/// <returns>The path to the (non-existant) folder in which
		/// the processed item will be saved.</returns>
		public string GetTargetFolderPath(DirectoryInfo destinationFolder)
		{ return GetTargetFolderPath(destinationFolder, this.Settings.CreateSubFolders); }

		/// <summary>
		/// Gets the path to the (non-existant) folder in which the
		/// processed item will be saved.
		/// </summary>
		/// <param name="createSubFolders">Whether to create subfolders
		/// for <see cref="BatchFolder"/> objects.</param>
		/// <returns>The path to the (non-existant) folder in which
		/// the processed item will be saved.</returns>
		public string GetTargetFolderPath(bool createSubFolders)
		{ return GetTargetFolderPath(this.Settings.DestinationFolder, createSubFolders); }

		/// <summary>
		/// Gets the path to the (non-existant) folder in which the
		/// processed item will be saved.
		/// </summary>
		/// <param name="destinationFolder">The destination folder
		/// for this item; or <see cref="null"/>.</param>
		/// <param name="createSubFolders">Whether to create subfolders
		/// for <see cref="BatchFolder"/> objects.</param>
		/// <returns>The path to the (non-existant) folder in which
		/// the processed item will be saved.</returns>
		public string GetTargetFolderPath(DirectoryInfo destinationFolder, bool createSubFolders)
		{
			if (!this.File.Exists)
				throw new FileNotFoundException("ProcessingItem's File does not exist.", this.File.FullName);
			if (destinationFolder == null)
				return this.File.Directory.FullName;
			else if (!createSubFolders ||
				this.Item == null ||
				!(this.Item is BatchFolder))
				return destinationFolder.FullName;
			else
			{
				DirectoryInfo di = ((BatchFolder)this.Item).Directory;
				return Path.Combine(
					destinationFolder.FullName,
					ProcessingItem.GetRelativePath(
					di.FullName,
					this.File.Directory.FullName));
			}
		}

		/// <summary>
		/// Gets the path of an absolute path relative to a base path.
		/// </summary>
		/// <param name="basePath">The base path.</param>
		/// <param name="absolutePath">The absolute path which will be relative
		/// to the base path.</param>
		/// <returns>The relative path of <paramref name="absolutePath"/>
		/// relative to <paramref name="basePath"/>.</returns>
		internal static string GetRelativePath(string basePath, string absolutePath)
		{
			string[] absoluteDirectories = absolutePath.Split('\\');
			string[] baseDirectories = basePath.Split('\\');

			//Get the shortest of the two paths
			int length = absoluteDirectories.Length < baseDirectories.Length ? absoluteDirectories.Length : baseDirectories.Length;

			//Use to determine where in the loop we exited
			int lastCommonRoot = -1;
			int index;

			//Find common root
			for (index = 0; index < length; index++)
			{
				if (absoluteDirectories[index] == baseDirectories[index])
					lastCommonRoot = index;
				else
					break;
			}

			//If we didn't find a common prefix then return original path
			if (lastCommonRoot == -1)
				return absolutePath;

			//Build up the relative path
			StringBuilder relativePath = new StringBuilder();

			//Add on the ..
			for (index = lastCommonRoot + 1; index < absoluteDirectories.Length; index++)
				if (absoluteDirectories[index].Length > 0)
					relativePath.Append("..\\");

			//Add on the folders
			for (index = lastCommonRoot + 1; index < baseDirectories.Length - 1; index++)
				relativePath.Append(baseDirectories[index] + "\\");
			relativePath.Append(baseDirectories[baseDirectories.Length - 1]);

			return relativePath.ToString();
		}
		#endregion
	}
}
