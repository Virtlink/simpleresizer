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
using System.IO;

namespace SimpleResizer
{
	/// <summary>
	/// Displays a report.
	/// </summary>
	public partial class frmReport : Form
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="frmReport"/> class.
		/// </summary>
		public frmReport()
		{
			InitializeComponent();
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the report's text.
		/// </summary>
		/// <value>A string.</value>
		public string Report
		{
			get { return txtReport.Text; }
			set { txtReport.Text = value; }
		}
		#endregion

		#region Event Handlers
		/// <summary>
		/// Handles the Click event of the btnSaveAs control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance
		/// containing the event data.</param>
		private void btnSaveAs_Click(object sender, EventArgs e)
		{
			if (dlgSaveAs.ShowDialog(this) == DialogResult.OK)
			{
				StreamWriter writer = new StreamWriter(dlgSaveAs.FileName);
				writer.Write(txtReport.Text);
				writer.Close();
				writer.Dispose();
			}
		}

		private void frmReport_Load(object sender, EventArgs e)
		{

		}
		#endregion
	}
}