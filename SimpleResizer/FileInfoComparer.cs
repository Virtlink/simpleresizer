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
using System.Collections;
using System.IO;
using System.ComponentModel;

namespace SimpleResizer
{
	#region Enums
	public enum FileInfoCompareProperty
	{
		Filename
	}
	#endregion
	
	/// <summary>
	/// Compares <see cref="FileInfo"/> objects.
	/// </summary>
	public class FileInfoComparer : IComparer<FileInfo>
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="FileInfoComparer"/> class.
		/// </summary>
		public FileInfoComparer(FileInfoCompareProperty compareProperty, bool inverse)
		{
			if (!Enum.IsDefined(typeof(FileInfoCompareProperty), compareProperty))
				throw new InvalidEnumArgumentException("compareProperty", (int)compareProperty, typeof(FileInfoCompareProperty));
			m_eCompareProperty = compareProperty;
			m_bInverse = inverse;
		}
		#endregion

		#region Properties
		private FileInfoCompareProperty m_eCompareProperty;
		/// <summary>
		/// Gets the <see cref="FileInfoCompareProperty"/> on which to compare.
		/// </summary>
		/// <value>A member of the <see cref="FileInfoCompareProperty"/> enumeration.</value>
		public FileInfoCompareProperty CompareProperty
		{
			get { return m_eCompareProperty; }
		}

		private bool m_bInverse;
		/// <summary>
		/// Gets or sets whether to inverse the sort.
		/// </summary>
		/// <value><see cref="true"/> to inverse the sort;
		/// otherwise, <see cref="false"/>.</value>
		public bool Inverse
		{
			get { return m_bInverse; }
		}
		#endregion

		#region Methods
		public int Compare(FileInfo x, FileInfo y)
		{
			FileInfo a, b;
			if (m_bInverse)
			{ a = y; b = x; }
			else
			{ a = x; b = y; }
			
			switch (m_eCompareProperty)
			{
				case FileInfoCompareProperty.Filename:
					return a.Name.CompareTo(b.Name);
				default:
					return a.ToString().CompareTo(b.ToString());
			}
		}
		#endregion
	}
}
