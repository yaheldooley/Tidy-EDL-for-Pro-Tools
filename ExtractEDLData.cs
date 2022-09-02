using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static Tidy_EDL_for_Pro_Tools.Form1;

namespace Tidy_EDL_for_Pro_Tools
{
	public class ExtractEDLData
	{
		private static SessionData currentSession;

		public static string[] HeadersPT = new string[] {
		"SESSION NAME",
		"O N L I N E  F I L E S  I N  S E S S I O N",
		"O F F L I N E  F I L E S  I N  S E S S I O N",
		"O N L I N E  C L I P S  I N  S E S S I O N",
		"P L U G - I N S  L I S T I N G",
		"T R A C K  L I S T I N G",
		"M A R K E R S  L I S T I N G",
		};

		private static Dictionary<string, string> CapturedHeaders = new Dictionary<string, string>();

		public static SessionData GetSessionData(string allTextInFile)
		{
			CapturedHeaders.Clear();

			currentSession = new SessionData();

			FindHeadersInString(allTextInFile);

			if (CapturedHeaders.ContainsKey(HeadersPT[0])) GetSessionFormatData();

			if (CapturedHeaders.ContainsKey(HeadersPT[1])) currentSession.NonEDLData += $"{HeadersPT[1]}{CapturedHeaders[HeadersPT[1]]}";
			if (CapturedHeaders.ContainsKey(HeadersPT[2])) currentSession.NonEDLData += $"{HeadersPT[2]}{CapturedHeaders[HeadersPT[2]]}";
			if (CapturedHeaders.ContainsKey(HeadersPT[3])) currentSession.NonEDLData += $"{HeadersPT[3]}{CapturedHeaders[HeadersPT[3]]}";
			if (CapturedHeaders.ContainsKey(HeadersPT[4])) currentSession.NonEDLData += $"{HeadersPT[4]}{CapturedHeaders[HeadersPT[4]]}";

			if (CapturedHeaders.ContainsKey(HeadersPT[5])) GetTrackListingData();

			if (CapturedHeaders.ContainsKey(HeadersPT[6])) currentSession.NonEDLData += $"{HeadersPT[6]}{CapturedHeaders[HeadersPT[6]]}";

			return currentSession;
		}

		private static void FindHeadersInString(string allTextInFile)
		{
			for (int i = 0; i < HeadersPT.Length; i++)
			{
				string thisString = allTextInFile;
				//val += allTextInFile;
				if (thisString.Contains(HeadersPT[i]))//file contains this data label
				{
					string[] splitStrings = SplitStringByString(thisString, HeadersPT[i]);
					if (splitStrings.Length > 0)
					{
						if (i == 0) FindEndOfDataSection(i, splitStrings[0]);
						else if (splitStrings.Length > 1)
						{
							if (i < HeadersPT.Length - 1) FindEndOfDataSection(i, splitStrings[1]);
							else
							{
								CapturedHeaders.Add(HeadersPT[i], splitStrings[splitStrings.Length - 1]);
							}
						}
					}
				}

			}
		}

		private static void GetSessionFormatData()
		{
			///		Data by Index
			//////	Session Name.
			//////	Sample Rate
			//////	Bit Depth
			//////	Session Start Timecode
			//////	Timecode Format
			//////	# of Audio tracks
			//////	# of Audio Clips
			//////	# of Audio Files

			string sessionString = CapturedHeaders[HeadersPT[0]].Replace('\t', ' '); ;
			//HeadersPT[0].Replace('\t', ' ');
			string[] sessionLines = sessionString.Split('\n');
			if (sessionLines.Length > 0) currentSession.SessionName = RemoveStringBeforeAndWhiteSpaces(sessionLines[0], ":");
			if (sessionLines.Length > 1)
			{
				currentSession.SampleRate = RemoveStringBeforeAndWhiteSpaces(sessionLines[1], "SAMPLE RATE:");
				string[] splitSR = SplitStringByString(currentSession.SampleRate, ".");
				currentSession.SampleRate = splitSR[0] + " Hz";
			}
			if (sessionLines.Length > 2)
			{
				currentSession.BitDepth = RemoveStringBeforeAndWhiteSpaces(sessionLines[2], "BIT DEPTH:");
			}
			if (sessionLines.Length > 3)
			{
				currentSession.SessionStartTimeCode = RemoveStringBeforeAndWhiteSpaces(sessionLines[3], "SESSION START TIMECODE:");
			}
			if (sessionLines.Length > 4)
			{
				currentSession.SessionFrameRate = RemoveStringBeforeAndWhiteSpaces(sessionLines[4], "TIMECODE FORMAT:");
				currentSession.SessionFrameRate = currentSession.SessionFrameRate.Replace(" Frame", "");
			}
			//IGNORE 5 (# of Audio tracks)
			//IGNORE 6 (# of Audio Clips)
			//IGNORE 7 (# of Audio Files)
		}

		private static void FindEndOfDataSection(int labelIndex, string sectionWithExtra)
		{
			for (int i = labelIndex; i < HeadersPT.Length; i++)//find next data label
			{
				int nextLabel = i + 1;
				if (nextLabel < HeadersPT.Length)
				{
					if (sectionWithExtra.Contains(HeadersPT[nextLabel]))
					{
						string[] lastSplit = SplitStringByString(sectionWithExtra, HeadersPT[nextLabel]);
						CapturedHeaders.Add(HeadersPT[labelIndex], lastSplit[0]);
						break;
					}
					continue;
				}
				else
				{
					CapturedHeaders.Add(HeadersPT[labelIndex], sectionWithExtra);
					break;
				}
			}
		}

		public static void GetTrackListingData()
		{
			string[] rawTrackData = SplitStringByString(CapturedHeaders[HeadersPT[5]], "TRACK NAME:");

			List<AudioTrackData> allTracks = new List<AudioTrackData>();

			for (int d = 1; d < rawTrackData.Length; d++)
			{
				string s = rawTrackData[d];
				string[] stringsWithReturns = s.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
				stringsWithReturns = RemoveReturns(stringsWithReturns);

				List<string> validTrackData = new List<string>();

				for (int i = 0; i < stringsWithReturns.Length; i++)
				{
					stringsWithReturns[i] = stringsWithReturns[i].Trim();
					if (stringsWithReturns[i] != string.Empty) validTrackData.Add(stringsWithReturns[i]);
				}

				
				AudioTrackData audioTrack = new AudioTrackData();
				audioTrack.TrackName = TrimTabAndReturns(validTrackData[0]);
				
				audioTrack.Comments = RemoveStringBeforeAndWhiteSpaces(validTrackData[1], "COMMENTS:");
				audioTrack.UserDelay = RemoveStringBeforeAndWhiteSpaces(validTrackData[2], "USER DELAY:");
				audioTrack.State = RemoveStringBeforeAndWhiteSpaces(validTrackData[3], "STATE:");
				int clipStartPos = 5;
				if(validTrackData[4].Contains("PLUG-INS:"))
				{
					audioTrack.PlugIns = RemoveStringBeforeAndWhiteSpaces(validTrackData[4], "PLUG-INS:");
					clipStartPos++;
				}
				//skip line 4 if not plugins, its just row description stuff we'll generate again later

				if (Session.PTParams.ExcludeInactiveTracks)
				{
					if (audioTrack.State == "") allTracks.Add(audioTrack);
				}
				else allTracks.Add(audioTrack);

				//Seperate Clip Info from Track Info
				List<string> validClipData = new List<string>();
				for (int i = clipStartPos; i < validTrackData.Count; i++) { validClipData.Add(validTrackData[i]); }

				for (int c = 0; c < validClipData.Count; c++)
				{
					AudioClipData clip = new AudioClipData();

					string[] clipDataLines = validClipData[c].Split(new string[] {"   ", "\t"}, StringSplitOptions.RemoveEmptyEntries);
					clipDataLines = Tidy(clipDataLines);

					/// Index 0 is Channel Number
					/// Index 1 is Event Number (Order)
					/// Index 2 Filename
					/// Index 3 Start Timecode
					/// Index 4 End Timecode
					/// Index 5 Duration Timecode + State

					int channel = 1;
					int.TryParse(clipDataLines[0], out channel);
					if (channel > 1) break;

					bool fadeTrack = false;
					if (clipDataLines.Length > 2)
					{
						string[] nameAndExt = SeparateExtensionFromFilename(TrimTabAndReturns(clipDataLines[2]), out fadeTrack);

						if (Session.PTParams.ExcludeExtensions) clip.ClipName = TrimTabAndReturns(nameAndExt[0]);
						else clip.ClipName = TrimTabAndReturns(nameAndExt[0]) + nameAndExt[1];
					}

					if (Session.PTParams.ExcludeFades && fadeTrack)
						continue;
					
					else if (Session.PTParams.ExcludeEmptyTracks && clip.ClipName == "") 
						continue;

					else
					{
						bool isLargestString = clip.ClipName.Length > audioTrack.MaxCharactersInTrackNames;

						if (isLargestString)
							audioTrack.MaxCharactersInTrackNames = clip.ClipName.Length;
						
						clip.StartTime = clipDataLines[3];

						clip.EndTime = clipDataLines[4];

						clip.Duration = clipDataLines[5];

						if (clip.Duration.Contains("Unmuted"))
						{
							clip.Duration = clip.Duration.Replace("Unmuted", "");
							clip.State = "Unmuted";
						}
						else if (clip.Duration.Contains("Muted"))
						{
							clip.Duration = clip.Duration.Replace("Muted", "");
							clip.State = "Muted";
						}

						audioTrack.AudioClips.Add(clip);
					}
				}
			}
			currentSession.AudioTracks = allTracks;
		}

		private static string[] extArray = new string[] {
			".aif", ".AIF", 
			".wav", ".WAV", 
			".mp3", ".MP3", 
			".mov", ".MOV",
			".L", ".R", ".C", ".Ls", ".Rs", ".LFE", ".Lfe"};
		private static string[] SeparateExtensionFromFilename(string fileName, out bool fade)
		{		
			string clipName = string.Empty;
			string extension = string.Empty;

			if (fileName == "(fade out)" || fileName == "(fade in)" || fileName == "(cross fade)")
			{
				clipName = fileName;
				fade = true;
			}
			else fade = false;

			if (!fade) //Keep Searching for extension
			{
				foreach (string ext in extArray)
				{
					if (fileName.Contains(ext))
					{
						string[] resultArray = SplitStringByString(fileName, ext);
						clipName = resultArray[0];
						extension = ext;
						break;
					}
				}
			}
			
			return new string[] { clipName, extension };
		}

		private static void DebugDataInClipDataLines(string[] clipDataLines)
		{
			for (int i = 0; i < clipDataLines.Length; i++)
			{
				Console.WriteLine($"=====ClipData positon {i} start====");
				Console.WriteLine($"{clipDataLines[i]}");
				Console.WriteLine($"=====ClipData positon {i} end====");
			}
		}

		private static string ByteStringFromString(string thisString)
		{
			string value = string.Empty;
			foreach (byte b in System.Text.Encoding.UTF8.GetBytes(thisString.ToCharArray()))
			{
				value += b.ToString() + ", ";
				Console.WriteLine(b.ToString());
			}
				
			return value;
		}

		private static string TrimTabAndReturns(string oldString)
		{
			string cleanString = oldString;
			cleanString = cleanString.Trim('\t','\n');
			cleanString = cleanString.Trim();
			return cleanString;
		}

		private static string[] Tidy(string[] strings)
		{
			for (int i = 0; i < strings.Length; i++)
			{
				strings[i] = strings[i].Trim('\t', '\n');
				strings[i] = strings[i].Trim();
			}
			return strings;
		}

		public static string FindStringBetween(string strSource, string strStart, string strEnd)
		{
			
			if (strSource.Contains(strStart) && strSource.Contains(strEnd))
			{
				int Start, End;
				Start = strSource.IndexOf(strStart, 0) + strStart.Length;
				End = strSource.IndexOf(strEnd, Start);
				string final = strSource.Substring(Start, End - Start);
				return final.Trim();
			}
			return "";
		}

		public static string[] SplitStringByString(string fullString, string splitter)
		{
			return fullString.Split(new string[] { splitter }, StringSplitOptions.RemoveEmptyEntries);
		}

		public static string RemoveStringBeforeAndWhiteSpaces(string stringToProcess, string toRemove)
		{
			stringToProcess = stringToProcess.Replace(toRemove, "");
			return stringToProcess.Trim();
		}

		public static string RemoveReturns(string strSource)
		{
			return Regex.Replace(strSource, @"\t|\n|\r", "");
		}

		public static string[] RemoveReturns(string[] strArray)
		{
			for (int i = 0; i < strArray.Length; i++)
			{
				strArray[i] = RemoveReturns(strArray[i]);
			}
			return strArray;
		}
	}

	public class SessionInfoParams
	{
		public EDLFormat EDLFormat = EDLFormat.ProTools; 	

		public bool ExcludeExtensions = true;
		public bool ExcludeInactiveTracks = true;
		public bool ExcludeEmptyTracks = true;
		public bool ExcludeFades = true;
		public bool TrackComments = false;
		public bool TrackUserDelay = false;
		public bool TrackState = false;
		public bool TrackPlugIns = false;
		
		public bool NonEDLData = false;

		public IEnumerable<string> TrueBools
		{
			get
			{
				return GetType()
					.GetProperties().Where(p => p.PropertyType == typeof(bool)
												 && (bool)p.GetValue(this, null))
					.Select(p => p.Name);
			}
		}
		public IEnumerable<string> FalseBools
		{
			get
			{
				return GetType()
					.GetProperties().Where(p => p.PropertyType == typeof(bool)
												 && (bool)p.GetValue(this, null))
					.Select(p => p.Name);
			}
		}

	}

	public enum EDLFormat
	{
		ProTools,
	}


}
