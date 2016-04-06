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

namespace SimpleResizer
{
	/// <summary>
	/// A file to be processed.
	/// </summary>
	public class BatchFile : BatchItem
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="BatchFile"/> class.
		/// </summary>
		/// <param name="file">The file.</param>
		public BatchFile(FileInfo file)
			: base(null)
		{
			if (file == null)
				throw new ArgumentNullException("file");

			m_fFile = file;
		}
		#endregion

		#region Properties
		private FileInfo m_fFile;
		/// <summary>
		/// Gets the file represented by this <see cref="BatchFolder"/>.
		/// </summary>
		/// <value>A <see cref="FileInfo"/> object.</value>
		public FileInfo File
		{
			get { return m_fFile; }
		}

		/// <summary>
		/// Gets the <see cref="BatchItemType"/> of this <see cref="BatchItem"/>.
		/// </summary>
		/// <value>A member of the <see cref="BatchItemType"/> enumeration.</value>
		public override BatchItemType ItemType
		{
			get { return BatchItemType.File; }
		}

		/// <summary>
		/// Gets the name of this <see cref="BatchItem"/>.
		/// </summary>
		/// <value>The <see cref="BatchItem"/>'s name.</value>
		public override string Name
		{
			get { return this.File.Name; }
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
			if (processor != null)
				processor.Statistics["Collected"]++;
			return new ProcessingItem[] { new ProcessingItem(this, this.Owner.Settings) };
		}

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public override object Clone()
		{
			return new BatchFile(this.File);
		}
		#endregion
	}
}
