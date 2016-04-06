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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SimpleResizer
{
	public partial class frmCustomFilenameEditor : Form
	{
		#region Constructors
		public frmCustomFilenameEditor()
		{
			InitializeComponent();
		}
		#endregion

		#region Events
		private void frmCustomFilenameEditor_Load(object sender, EventArgs e)
		{

		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the filename pattern.
		/// </summary>
		/// <value>A filename pattern.</value>
		public string Pattern
		{
			get { return txtPattern.Text; }
			set { txtPattern.Text = value; }
		}
		#endregion

		#region Field-button
		private void mnuFieldFilename_Click(object sender, EventArgs e)
		{ txtPattern.SelectedText = "%n"; }
		private void mnuFieldExtension_Click(object sender, EventArgs e)
		{ txtPattern.SelectedText = "%e"; }
		private void mnuFieldGlobalCounter_Click(object sender, EventArgs e)
		{ txtPattern.SelectedText = "%c4"; }
		private void mnuFieldLocalCounter_Click(object sender, EventArgs e)
		{ txtPattern.SelectedText = "%l"; }
		private void mnuFieldFoldername_Click(object sender, EventArgs e)
		{ txtPattern.SelectedText = "%f"; }
		#endregion
	}
}