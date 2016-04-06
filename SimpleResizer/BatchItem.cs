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
	#region Enums
	/// <summary>
	/// Specifies the type of the <see cref="BatchItem"/>.
	/// </summary>
	public enum BatchItemType
	{
		/// <summary>
		/// The <see cref="BatchItem"/> is something unknown.
		/// </summary>
		None,
		/// <summary>
		/// The <see cref="BatchItem"/> is a <see cref="BatchFile"/>.
		/// </summary>
		File,
		/// <summary>
		/// The <see cref="BatchItem"/> is a <see cref="BatchFolder"/>.
		/// </summary>
		Folder
	}
	#endregion

	/// <summary>
	/// Represents an item to be processed.
	/// </summary>
	public abstract class BatchItem : ICloneable
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="BatchItem"/> class.
		/// </summary>
		/// <param name="owner">The owning <see cref="Batch"/> object.</param>
		protected BatchItem(Batch owner)
		{
			m_xOwner = owner;
		}
		#endregion

		#region Properties
		private Batch m_xOwner;
		/// <summary>
		/// Gets the owning <see cref="Batch"/> object.
		/// </summary>
		/// <value>A <see cref="Batch"/> object.</value>
		public Batch Owner
		{
			get { return m_xOwner; }
			protected internal set { m_xOwner = value; }
		}

		/// <summary>
		/// Gets the <see cref="BatchItemType"/> of this <see cref="BatchItem"/>.
		/// </summary>
		/// <value>A member of the <see cref="BatchItemType"/> enumeration.</value>
		public virtual BatchItemType ItemType
		{
			get { return BatchItemType.None; }
		}

		/// <summary>
		/// Gets the name of this <see cref="BatchItem"/>.
		/// </summary>
		/// <value>The <see cref="BatchItem"/>'s name.</value>
		public abstract string Name
		{
			get;
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
		internal abstract ProcessingItem[] GetProcessingItems(BatchProcessor processor);

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public abstract object Clone();
		#endregion
	}
}
