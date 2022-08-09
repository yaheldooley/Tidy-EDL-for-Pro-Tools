using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;
using static Tidy_EDL_for_Pro_Tools.Form1;

namespace Tidy_EDL_for_Pro_Tools
{
	public static class Session
	{
		public static event Action<ListViewItem, bool> SetValidStatus;
		public static void SetDefaultValues()
		{
			PTParams = new SessionInfoParams();
			PTParams.ExcludeExtensions = true;
			PTParams.ExcludeInactiveTracks = true;
			PTParams.ExcludeEmptyTracks = true;
			PTParams.ExcludeFades = true;
			PTParams.TrackComments = true;
			PTParams.TrackUserDelay = true;
			PTParams.TrackState = true;
			PTParams.TrackPlugIns = true;
			PTParams.PreserveNonEDLData = true;
		}

		public static void SetEDLFormat(string formatName)
		{
			// compare string to EDLFormat enum
		}

		public static Dictionary<ListViewItem, string> AllRawTextData = new Dictionary<ListViewItem, string>();
		public static List<SessionData> AllSessionData = new List<SessionData>();
		public static SessionInfoParams PTParams;

		public static void ProcessObjectsAsEDL(ListViewItemCollection collection)
		{
			AllRawTextData.Clear();
			for (int i = 0; i < collection.Count; i++)
			{
				AllRawTextData.Add(collection[i], collection[i].Text);
			}
			FormatAllTextFilesInList();
		}

		public static void FormatAllTextFilesInList()
		{
			foreach (KeyValuePair<ListViewItem, string> pair in AllRawTextData)
			{
				string allTextInFile = File.ReadAllText(pair.Value);

				SessionData newData = ExtractEDLData.GetSessionData(allTextInFile);

				if (newData.SessionName == null) //EDL is not AVID PRO TOOLS FORMAT
				{
					SetValidStatus(pair.Key, false);
					// text files does not contain Pro Tools EDL Data
					// display somehow whether it worked or not
					//
					continue;
				}
				else
				{
					AllSessionData.Add(newData);
					CreateNewEDLTextFile(newData, pair.Value);
					SetValidStatus(pair.Key, true);
				}
			}
		}

		public static void CreateNewEDLTextFile(SessionData sessionData, string textFilePath)
		{
			string fullFileName = Path.GetDirectoryName(textFilePath) + "\\" + RemoveInvalidFileNameCharacters(sessionData.SessionName) + "_TidyEDL.txt";

			if (File.Exists(fullFileName))
			{
				File.Delete(fullFileName);
			}
			string dataToWrite = sessionData.PrintSessionInfo();
			//label1.Text = $"Full Filename: {fullFileName}\nData: {dataToWrite}";

			//return;

			// Create a new file     
			using (FileStream fs = File.Create(fullFileName))
			{
				// Add some text to file    
				Byte[] title = new UTF8Encoding(true).GetBytes(dataToWrite);
				fs.Write(title, 0, title.Length);
			}

		}

		private static string RemoveInvalidFileNameCharacters(string fileName)
		{
			return Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
		}

		
	}
		
}
