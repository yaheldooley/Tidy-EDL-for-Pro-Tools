﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tidy_EDL_for_Pro_Tools
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());

		}
	}
}
