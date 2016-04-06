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
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace SimpleResizer
{
	/// <summary>
	/// About form.
	/// </summary>
	partial class frmAbout : Form
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="frmAbout"/> class.
		/// </summary>
		public frmAbout()
		{
			InitializeComponent();

			//  Initialize the AboutBox to display the product information from the assembly information.
			//  Change assembly information settings for your application through either:
			//  - Project->Properties->Application->Assembly Information
			//  - AssemblyInfo.cs
			this.Text = String.Format("About {0}", AssemblyTitle);
			this.labelProductName.Text = AssemblyProduct;
			this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
			this.labelCopyright.Text = AssemblyCopyright;
			this.labelCompanyName.Text = AssemblyCompany;
			this.textBoxDescription.Text = AssemblyDescription;
		}
		#endregion

		#region Assembly Attribute Accessors
		/// <summary>
		/// Gets the assembly title.
		/// </summary>
		/// <value>The assembly title.</value>
		public string AssemblyTitle
		{
			get
			{
				// Get all Title attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				// If there is at least one Title attribute
				if (attributes.Length > 0)
				{
					// Select the first one
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					// If it is not an empty string, return it
					if (titleAttribute.Title != "")
						return titleAttribute.Title;
				}
				// If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		/// <summary>
		/// Gets the assembly version.
		/// </summary>
		/// <value>The assembly version.</value>
		public string AssemblyVersion
		{
			get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
		}

		/// <summary>
		/// Gets the assembly description.
		/// </summary>
		/// <value>The assembly description.</value>
		public string AssemblyDescription
		{
			get
			{
				// Get all Description attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				// If there aren't any Description attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Description attribute, return its value
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		/// <summary>
		/// Gets the assembly product.
		/// </summary>
		/// <value>The assembly product.</value>
		public string AssemblyProduct
		{
			get
			{
				// Get all Product attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				// If there aren't any Product attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Product attribute, return its value
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		/// <summary>
		/// Gets the assembly copyright.
		/// </summary>
		/// <value>The assembly copyright.</value>
		public string AssemblyCopyright
		{
			get
			{
				// Get all Copyright attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				// If there aren't any Copyright attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Copyright attribute, return its value
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		/// <summary>
		/// Gets the assembly company.
		/// </summary>
		/// <value>The assembly company.</value>
		public string AssemblyCompany
		{
			get
			{
				// Get all Company attributes on this assembly
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				// If there aren't any Company attributes, return an empty string
				if (attributes.Length == 0)
					return "";
				// If there is a Company attribute, return its value
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}
		#endregion

		#region Event Handlers
		/// <summary>
		/// Handles the Load event of the frmAbout control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void frmAbout_Load(object sender, EventArgs e)
		{

		}
		#endregion
	}
}
