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
using System.ComponentModel;

namespace SimpleResizer
{
	/// <summary>
	/// A batch of files and folders to process.
	/// </summary>
	public class Batch : CollectionBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Batch"/> class.
		/// </summary>
		public Batch()
			: this(null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Batch"/> class.
		/// </summary>
		/// <param name="settings">The settings.</param>
		public Batch(BatchProcessSettings settings)
		{
			if (settings == null)
				m_xSettings = new BatchProcessSettings();
			else
				m_xSettings = settings;
		}
		#endregion

		#region Event Overrides
		/// <summary>
		/// Performs additional custom processes when clearing the contents of the <see cref="T:System.Collections.CollectionBase"></see> instance.
		/// </summary>
		protected override void OnClear()
		{
			foreach (BatchItem item in List)
			{
				if (item != null && item.Owner == this)
					item.Owner = null;
			}
			base.OnClear();
		}

		/// <summary>
		/// Performs additional custom processes when removing an element from the <see cref="T:System.Collections.CollectionBase"></see> instance.
		/// </summary>
		/// <param name="index">The zero-based index at which value can be found.</param>
		/// <param name="value">The value of the element to remove from index.</param>
		protected override void OnRemove(int index, object value)
		{
			if (value != null)
			{
				BatchItem item = (BatchItem)value;
				if (item.Owner == this)
					item.Owner = null;
			}
			base.OnRemove(index, value);
		}

		/// <summary>
		/// Performs additional custom processes before setting a value in the <see cref="T:System.Collections.CollectionBase"></see> instance.
		/// </summary>
		/// <param name="index">The zero-based index at which oldValue can be found.</param>
		/// <param name="oldValue">The value to replace with newValue.</param>
		/// <param name="newValue">The new value of the element at index.</param>
		protected override void OnSet(int index, object oldValue, object newValue)
		{
			if (oldValue != null)
			{
				BatchItem oldItem = (BatchItem)oldValue;
				if (oldItem.Owner == this)
					oldItem.Owner = null;
			}
			if (newValue != null)
			{
				BatchItem newItem = (BatchItem)newValue;
				if (newItem.Owner != null && newItem.Owner != this)
					newItem.Owner.Remove(newItem);
				newItem.Owner = this;
			}
			base.OnSet(index, oldValue, newValue);
		}

		/// <summary>
		/// Performs additional custom processes before inserting a new element into the <see cref="T:System.Collections.CollectionBase"></see> instance.
		/// </summary>
		/// <param name="index">The zero-based index at which to insert value.</param>
		/// <param name="value">The new value of the element at index.</param>
		protected override void OnInsert(int index, object value)
		{
			if (value != null)
			{
				BatchItem item = (BatchItem)value;
				if (item.Owner != null && item.Owner != this)
					item.Owner.Remove(item);
				item.Owner = this;
			}
			base.OnInsert(index, value);
		}
		#endregion

		#region Properties
		private BatchProcessSettings m_xSettings;
		/// <summary>
		/// Gets the settings for this <see cref="BatchFolder"/>.
		/// </summary>
		/// <value>A <see cref="BatchProcessSettings"/> object.</value>
		public BatchProcessSettings Settings
		{
			get { return m_xSettings; }
		}

		private int m_iBatchFileCount = 0;
		/// <summary>
		/// Gets the number of <see cref="BatchFile"/> items in
		/// this <see cref="Batch"/>.
		/// </summary>
		/// <value>The number of <see cref="BatchFile"/> items.</value>
		public int BatchFileCount
		{
			get { return m_iBatchFileCount; }
		}

		private int m_iBatchFolderCount = 0;
		/// <summary>
		/// Gets the number of <see cref="BatchFolder"/> items in
		/// this <see cref="Batch"/>.
		/// </summary>
		/// <value>The number of <see cref="BatchFolder"/> items.</value>
		public int BatchFolderCount
		{
			get { return m_iBatchFolderCount; }
		}
		#endregion

		#region Methods
		/// <summary>
		/// Adds a <see cref="BatchItem"/> to the end of the collection.
		/// </summary>
		/// <param name="item">The <see cref="BatchItem"/> to add.</param>
		/// <returns>The index at which the <see cref="BatchItem"/>
		/// was added.</returns>
		public int Add(BatchItem item)
		{ return List.Add(item); }

		/// <summary>
		/// Adds an array of <see cref="BatchItem"/> objects to the end
		/// of the collection.
		/// </summary>
		/// <param name="items">An array of <see cref="BatchItem"/>
		/// objects to add.</param>
		public void AddRange(IEnumerable<BatchItem> items)
		{
			foreach (BatchItem item in items)
			{
				Add(item);
			}
		}

		/// <summary>
		/// Inserts a <see cref="BatchItem"/> into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="item"/>
		/// is inserted.</param>
		/// <param name="item">The <see cref="BatchItem"/> to insert.</param>
		public void Insert(int index, BatchItem item)
		{
			List.Insert(index, item);
		}

		/// <summary>
		/// Removes the specified <see cref="BatchItem"/> from the collection.
		/// </summary>
		/// <param name="item">The <see cref="BatchItem"/> to remove.</param>
		public void Remove(BatchItem item)
		{
			List.Remove(item);
		}

		/// <summary>
		/// Determines whether the collection contains a specific
		/// <see cref="BatchItem"/>.
		/// </summary>
		/// <param name="item">The <see cref="BatchItem"/> to look for.</param>
		/// <returns><see cref="true"/> when the specified <see cref="BatchItem"/>
		/// was found; otherwise, <see cref="false"/>.</returns>
		public bool Contains(BatchItem item)
		{
			return List.Contains(item);
		}

		/// <summary>
		/// Searches for the specified <see cref="BatchItem"/> and
		/// returns the zero-based index of the first occurrence
		/// within the entire collection.
		/// </summary>
		/// <param name="item">The <see cref="BatchItem"/> to add.</param>
		/// <returns>The index of the <see cref="BatchItem"/> if found;
		/// otherwise, -1.</returns>
		public int IndexOf(BatchItem item)
		{
			return List.IndexOf(item);
		}
		#endregion

		#region Event Overrides
		/// <summary>
		/// Performs additional custom processes after inserting a
		/// new element into this collection.
		/// </summary>
		/// <param name="index">The zero-based index at which to
		/// insert <paramref name="value"/>.</param>
		/// <param name="value">The new value of the element at
		/// <paramref name="index"/>.</param>
		protected override void OnInsertComplete(int index, object value)
		{
			if (value is BatchFile)
				m_iBatchFileCount++;
			if (value is BatchFolder)
				m_iBatchFolderCount++;
			base.OnInsertComplete(index, value);
		}

		/// <summary>
		/// Performs additional custom processes after removing an
		/// element from this collection.
		/// </summary>
		/// <param name="index">The zero-based index at which
		/// <paramref name="value"/> can be found.</param>
		/// <param name="value">The value of the element to remove
		/// from <paramref name="index"/>.</param>
		protected override void OnRemoveComplete(int index, object value)
		{
			if (value is BatchFile)
				m_iBatchFileCount--;
			if (value is BatchFolder)
				m_iBatchFolderCount--;
			base.OnRemoveComplete(index, value);
		}

		/// <summary>
		/// Performs additional custom processes after clearing
		/// the contents of this collection.
		/// </summary>
		protected override void OnClearComplete()
		{
			m_iBatchFileCount = 0;
			m_iBatchFolderCount = 0;
			base.OnClearComplete();
		}
		#endregion

		#region Indexers
		/// <summary>
		/// Gets the <see cref="BatchItem"/> at the specified index.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns>The found <see cref="BatchItem"/>;
		/// or <see cref="null"/>.</returns>
		public BatchItem this[int index]
		{
			get { return (BatchItem)List[index]; }
		}
		#endregion
	}
}
