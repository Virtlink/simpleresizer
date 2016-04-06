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
using System.ComponentModel;

namespace SimpleResizer
{
	#region Enums
	/// <summary>
	/// Specifies how and where the stamp is placed.
	/// </summary>
	public enum StampPlacement
	{
		/// <summary>
		/// The stamp is scaled to fit the size of the image.
		/// </summary>
		Scale,
		/// <summary>
		/// The stamp is stretched to the size of the image.
		/// </summary>
		Stretch,
		/// <summary>
		/// The stamp is put in the top-left corner of the image.
		/// </summary>
		TopLeft,
		/// <summary>
		/// The stamp is put at the top of the image.
		/// </summary>
		Top,
		/// <summary>
		/// The stamp is put in the top-right corner of the image.
		/// </summary>
		TopRight,
		/// <summary>
		/// The stamp is put at the left side of the image.
		/// </summary>
		Left,
		/// <summary>
		/// The stamp is put in the center of the image.
		/// </summary>
		Center,
		/// <summary>
		/// The stamp is put at the right side of the image.
		/// </summary>
		Right,
		/// <summary>
		/// The stamp is put in the bottom-left corner of the image.
		/// </summary>
		BottomLeft,
		/// <summary>
		/// The stamp is put at the bottom of the image.
		/// </summary>
		Bottom,
		/// <summary>
		/// The stamp is put in the bottom-right corner of the image.
		/// </summary>
		BottomRight
	}
	#endregion
	/// <summary>
	/// The settings used for the batch processing job.
	/// </summary>
	public class BatchProcessSettings
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="BatchProcessSettings"/>
		/// class.
		/// </summary>
		public BatchProcessSettings()
		{
		}
		#endregion

		#region Properties
		private int m_iMaxWidth = 500;
		/// <summary>
		/// Gets or sets the maximum width of the image.
		/// </summary>
		/// <value>The maximum width of the image.</value>
		public int MaxWidth
		{
			get { return m_iMaxWidth; }
			set
			{
				if (value < 1) throw new ArgumentOutOfRangeException("value");
				m_iMaxWidth = value;
			}
		}

		private int m_iMaxHeight = 500;
		/// <summary>
		/// Gets or sets the maximum height of the image.
		/// </summary>
		/// <value>The maximum height of the image.</value>
		public int MaxHeight
		{
			get { return m_iMaxHeight; }
			set
			{
				if (value < 1) throw new ArgumentOutOfRangeException("value");
				m_iMaxHeight = value;
			}
		}

		private int m_iQuality = 100;
		/// <summary>
		/// Gets or sets the quality of the output file.
		/// </summary>
		/// <value>The quality, a value ranging from 1 up to and
		/// including 100.</value>
		public int Quality
		{
			get { return m_iQuality; }
			set
			{
				if (value < 1)
					m_iQuality = 1;
				if (value > 100)
					m_iQuality = 100;
				else
					m_iQuality = value;
			}
		}

		private FileInfo m_fStampFile = null;
		/// <summary>
		/// Gets or sets the file containing the stamp.
		/// </summary>
		/// <value>A <see cref="FileInfo"/> object, or <see cref="null"/>
		/// to specify that no stamp should be used.</value>
		public FileInfo StampFile
		{
			get { return m_fStampFile; }
			set { m_fStampFile = value; }
		}

		private StampPlacement m_eStampPlacement = StampPlacement.Scale;
		/// <summary>
		/// Gets or sets the placement of the stamp.
		/// </summary>
		/// <value>A member of the <see cref="StampPlacement"/> enumeration.</value>
		public StampPlacement StampPlacement
		{
			get { return m_eStampPlacement; }
			set
			{
				if (!Enum.IsDefined(typeof(StampPlacement), value))
					throw new InvalidEnumArgumentException("value", (int)value, typeof(StampPlacement));
				m_eStampPlacement = value;
			}
		}

		private int m_iHorizontalDistance = 0;
		/// <summary>
		/// Gets or sets the horizontal distance between the vertical side
		/// and the stamp.
		/// </summary>
		/// <value>A value in pixels.</value>
		public int HorizontalDistance
		{
			get { return m_iHorizontalDistance; }
			set { m_iHorizontalDistance = value; }
		}

		private int m_iVerticalDistance = 0;
		/// <summary>
		/// Gets or sets the vertical distance between the vertical side
		/// and the stamp.
		/// </summary>
		/// <value>A value in pixels.</value>
		public int VerticalDistance
		{
			get { return m_iVerticalDistance; }
			set { m_iVerticalDistance = value; }
		}

		private float m_iStampTransparency = 0f;
		/// <summary>
		/// Gets or sets the transparency of the stamp.
		/// </summary>
		/// <value>A value between 0 and 1.</value>
		public float StampTransparency
		{
			get { return m_iStampTransparency; }
			set
			{
				if (value < 0f || value > 1f)
					throw new ArgumentOutOfRangeException("value");
				m_iStampTransparency = value;
			}
		}

		private string m_sNewFilenamePattern = "%n_%c0.%e";
		/// <summary>
		/// Gets or sets the pattern using which the new filenames are constructed.
		/// </summary>
		/// <value>The new filename pattern.</value>
		public string NewFilenamePattern
		{
			get { return m_sNewFilenamePattern; }
			set { m_sNewFilenamePattern = value; }
		}

		private DirectoryInfo m_fDestinationFolder = null;
		/// <summary>
		/// Gets or sets the destination folder.
		/// </summary>
		/// <value>A <see cref="DirectoryInfo"/> object, or <see cref="null"/> to
		/// specify that the files must be saved in their source-folder.</value>
		public DirectoryInfo DestinationFolder
		{
			get { return m_fDestinationFolder; }
			set { m_fDestinationFolder = value; }
		}

		private bool m_bCreateSubFolders = false;
		/// <summary>
		/// Gets or sets whether to create subfolders within the
		/// <see cref="DestionationFolder"/>.
		/// </summary>
		/// <value><see cref="true"/> to create subfolders;
		/// otherwise, <see cref="false"/>.</value>
		/// <remarks>Setting this property to any value has no
		/// effect when <see cref="DestinationFolder"/> is set to
		/// <see cref="null"/>.</remarks>
		public bool CreateSubFolders
		{
			get { return m_bCreateSubFolders; }
			set { m_bCreateSubFolders = value; }
		}
		#endregion

		#region Methods
		#endregion
	}
}
