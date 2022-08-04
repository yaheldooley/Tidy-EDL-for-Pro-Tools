using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tidy_EDL_for_Pro_Tools;

namespace Tidy_EDL_for_Pro_Tools
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			this.listBox1.DragDrop += new DragEventHandler(this.listBox1_DragDrop);
			this.listBox1.DragEnter += new DragEventHandler(this.listBox1_DragEnter);
		}

		private List<string> AllRawTextData = new List<string>();
		private List<SessionData> AllSessionData = new List<SessionData>();


		private void listBox1_DragDrop(object sender, DragEventArgs e)
		{
			string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);

			for (int i = 0; i < s.Length; i++)
			{
				string ext = Path.GetExtension(s[i]);
				if (ext == ".txt")
				{
					listBox1.Items.Add(s[i]);
				}
			}
		}

		private void listBox1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.All;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (listBox1.Items.Count < 1) return;

			foreach (var item in listBox1.Items) { AllRawTextData.Add(item.ToString()); }
			FormatAllTextFilesInList();

		}

		private void FormatAllTextFilesInList()
		{
			for (int i = 0; i < AllRawTextData.Count; i++)
			{
				string allTextInFile = File.ReadAllText(AllRawTextData[i]);
				SessionData newData = ExtractEDLData.GetSessionData(allTextInFile);
				if (newData == null) //EDL is not AVID PRO TOOLS FORMAT
				{
					// text files does not contain Pro Tools EDL Data
					listBox2.Items.Add(AllRawTextData[i]);
					continue;
				}
				else
				{
					AllSessionData.Add(newData);
					CreateNewEDL(newData, AllRawTextData[i]);
					//label1.Text = newData.Print();
				}
			}
		}

		private void CreateNewEDL(SessionData sessionData, string textFilePath)
		{
			string fullFileName = Path.GetDirectoryName(textFilePath) + "\\" + removeInvalidChar(sessionData.SessionName) + "_TidyEDL.txt";
			//string OnlyValidCharacters = removeInvalidChar(fullFileName);

			if (File.Exists(fullFileName))
			{
				File.Delete(fullFileName);
			}
			string dataToWrite = sessionData.PrintSessionInfo();
			label1.Text = $"Full Filename: {fullFileName}\nData: {dataToWrite}";

			//return;

			// Create a new file     
			using (FileStream fs = File.Create(fullFileName))
			{
				// Add some text to file    
				Byte[] title = new UTF8Encoding(true).GetBytes(dataToWrite);
				fs.Write(title, 0, title.Length);
			}

		}

		private static string removeInvalidChar(string fileName)
		{
			return Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
		}
	}
}
