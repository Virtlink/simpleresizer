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
using System.Drawing;
using SimpleResizer.Properties;

namespace SimpleResizer
{
	/// <summary>
	/// A folder containing files to process.
	/// </summary>
	public class BatchFolder : BatchItem
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="BatchFolder"/> class.
		/// </summary>
		/// <param name="directory">The directory.</param>
		public BatchFolder(DirectoryInfo directory)
			: base(null)
		{
			if (directory == null)
				throw new ArgumentNullException("directory");

			m_fDirectory = directory;
		}
		#endregion

		#region Properties
		private DirectoryInfo m_fDirectory;
		/// <summary>
		/// Gets the directory represented by this <see cref="BatchFolder"/>.
		/// </summary>
		/// <value>A <see cref="DirectoryInfo"/> object.</value>
		public DirectoryInfo Directory
		{
			get { return m_fDirectory; }
		}

		private bool m_bRecursive = false;
		/// <summary>
		/// Gets or sets whether this <see cref="BatchFolder"/> is processed
		/// recursively.
		/// </summary>
		/// <value><see cref="true"/> to process the <see cref="BatchFolder"/>
		/// recursively; otherwise, <see cref="false"/>.</value>
		public bool Recursive
		{
			get { return m_bRecursive; }
			set { m_bRecursive = value; }
		}

		private string m_sFilePattern = Resources.ImageFilePattern;
		/// <summary>
		/// Gets the filepattern to look for.
		/// </summary>
		/// <value>The filepattern to look for.</value>
		public string FilePattern
		{
			get { return m_sFilePattern; }
		}

		/// <summary>
		/// Gets the <see cref="BatchItemType"/> of this <see cref="BatchItem"/>.
		/// </summary>
		/// <value>A member of the <see cref="BatchItemType"/> enumeration.</value>
		public override BatchItemType ItemType
		{
			get { return BatchItemType.Folder; }
		}

		/// <summary>
		/// Gets the name of this <see cref="BatchItem"/>.
		/// </summary>
		/// <value>The <see cref="BatchItem"/>'s name.</value>
		public override string Name
		{
			get { return this.Directory.Name; }
		}
		#endregion

		#region Methods
		/// <summary>
		/// Returns the <see cref="ProcessingItem"/> objects
		/// from which this <see cref="BatchItem"/> consists.
		/// </summary>
		/// <param name="processor"></param>
		/// <returns>An array of <see cref="ProcessingItem"/>
		/// objects.</returns>
		internal override ProcessingItem[] GetProcessingItems(BatchProcessor processor)
		{
			//List<FileInfo> files;
			////FileInfo[] files;
			//try
			//{
			//    files = this.Directory.GetFiles(FilePattern, (Recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
			//}
			//catch (DirectoryNotFoundException e)
			//{
			//    e.Data["Path"] = Directory.FullName;
			//    throw e;
			//}
			FileInfo[] files = GetFiles(processor, this.Directory, FilePattern, Recursive);

			ProcessingItem[] items = new ProcessingItem[files.Length];
			for(int q = 0; q < items.Length; q++)
			{
				items[q] = new ProcessingItem(this, this.Owner.Settings, files[q], q);
			}

			return items;
		}

		/// <summary>
		/// Gets the files in a single directory, and asks subdirectories
		/// recursively for their files.
		/// </summary>
		/// <param name="processor"></param>
		/// <param name="directory"></param>
		/// <param name="pattern"></param>
		/// <param name="recursive"></param>
		/// <returns></returns>
		private FileInfo[] GetFiles(BatchProcessor processor, DirectoryInfo directory, string pattern, bool recursive)
		{
			string[] exts = pattern.Split(';');
			for(int q = 0; q < exts.Length; q++)
			{
				exts[q] = exts[q].Trim();
			}
			FileInfo[] allFiles = directory.GetFiles("*.*", SearchOption.TopDirectoryOnly);
			List<FileInfo> files = new List<FileInfo>();
			foreach (FileInfo fi in allFiles)
			{
				foreach (string s in exts)
				{
					if (String.Compare(fi.Extension, s.Substring(1), true) == 0)
					{
						files.Add(fi);
						if (processor != null)
							processor.Statistics["Collected"]++;
						break;
					}
				}
			}
			if (processor != null)
			{
				processor.BeginUpdate();
				processor.EndUpdate();
			}
			if (recursive)
			{
				DirectoryInfo[] allDirs = directory.GetDirectories();
				foreach (DirectoryInfo di in allDirs)
				{
					files.AddRange(GetFiles(processor, di, pattern, recursive));
				}
			}
			return files.ToArray();
		}

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public override object Clone()
		{
			return new BatchFolder(this.Directory);
		}
		#endregion
	}
}
