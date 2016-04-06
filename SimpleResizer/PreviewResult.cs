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
using System.Drawing;

namespace SimpleResizer
{
	/// <summary>
	/// The result of an image's preview.
	/// </summary>
	public struct PreviewResult
	{
		#region Fields
		/// <summary>
		/// An empty <see cref="PreviewResult"/>.
		/// </summary>
		public static readonly PreviewResult Empty = new PreviewResult(null, null);
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="PreviewResult"/> struct.
		/// </summary>
		public PreviewResult(Image previewImage, string newFilename)
		{
			m_xPreviewImage = previewImage;
			m_sNewFilename = newFilename;
		}
		#endregion

		#region Properties
		//private ProcessingItem m_xProcessingItem;
		///// <summary>
		///// Gets the <see cref="ProcessingItem"/> which was created.
		///// </summary>
		///// <value>A <see cref="ProcessingItem"/> object.</value>
		//public ProcessingItem ProcessingItem
		//{
		//    get { return m_xProcessingItem; }
		//}

		private Image m_xPreviewImage;
		/// <summary>
		/// Gets the preview image.
		/// </summary>
		/// <value>An <see cref="Image"/>; or <see cref="null"/>..</value>
		public Image PreviewImage
		{
			get { return m_xPreviewImage; }
		}

		private string m_sNewFilename;
		/// <summary>
		/// Gets the new filename.
		/// </summary>
		/// <value>The new filename; or <see cref="null"/>.</value>
		public string NewFilename
		{
			get { return m_sNewFilename; }
		}
		#endregion

		#region Methods
		#endregion
	}
}
