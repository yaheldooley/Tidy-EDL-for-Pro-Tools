using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Tidy_EDL_for_Pro_Tools.Form1;

namespace Tidy_EDL_for_Pro_Tools
{
	public class ExtractEDLData
	{
		public static event Action<string> UpdateLabelText;

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
			MarkerData = "";
			CapturedHeaders.Clear();

			currentSession = new SessionData();

			FindHeadersInString(allTextInFile);

			if (CapturedHeaders.ContainsKey(HeadersPT[0])) FormatSessionInfo();

			//if (CapturedHeaders.ContainsKey(HeadersPT[1]))
			//if (CapturedHeaders.ContainsKey(HeadersPT[2]))
			//if (CapturedHeaders.ContainsKey(HeadersPT[3]))
			//if (CapturedHeaders.ContainsKey(HeadersPT[4]))

			if (CapturedHeaders.ContainsKey(HeadersPT[5])) GetTrackListingData();
			

			
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

		private static void FormatSessionInfo()
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
						CapturedHeaders.Add(HeadersPT[i], lastSplit[0]);
						break;
					}
					continue;
				}
				else
				{
					CapturedHeaders.Add(HeadersPT[i], sectionWithExtra);
					break;
				}
			}
		}

		public static string MarkerData = "";

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
				audioTrack.TrackName = Tidy(validTrackData[0]);
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

				if (currentParameters.ExcludeInactiveTracks)
				{
					if (audioTrack.State == "") allTracks.Add(audioTrack);
				}
				else allTracks.Add(audioTrack);

				//Seperate Clip Info from Track Info
				List<string> validClipData = new List<string>();
				for (int i = clipStartPos; i < validTrackData.Count; i++) { validClipData.Add(validTrackData[i]); }

				char[] clipDataSplitters = new char[] {'\t', ' '};
				for (int c = 0; c < validClipData.Count; c++)
				{
					AudioClipData clip = new AudioClipData();
					string[] clipDataLines = Regex.Split(validClipData[c], @"\s{2,}");
					for (int i = 0; i < clipDataLines.Length; i++)
					{
						Console.WriteLine($"=====ClipData positon {i} start====");
						Console.WriteLine($"{clipDataLines[i]}");
						Console.WriteLine($"=====ClipData positon {i} end====");
					}
					
					//if (clipDataLines.Length < 7) break; // something was removed from EDL
					int channel = 1;
					int.TryParse(clipDataLines[0].Trim(), out channel);
					if (channel > 1) break;

					if (currentParameters.SimplifyFileNames) clip.ClipName = SimplifyClipName(Tidy(clipDataLines[2]));
					else clip.ClipName = Tidy(clipDataLines[2]);

					bool fadeTrack = clip.ClipName == "(fade out)" || clip.ClipName == "(fade in)" || clip.ClipName == "(cross fade)";
					if (currentParameters.ExcludeFades && fadeTrack)
					{
						continue;
					}
					else if (currentParameters.ExcludeEmptyTracks && clip.ClipName == "") continue;
					else
					{
						if (clip.ClipName.Length > audioTrack.MaxCharactersInTrackNames)
						{
							audioTrack.MaxCharactersInTrackNames = clip.ClipName.Length;
						}
						clip.StartTime = Tidy(clipDataLines[3]);
						clip.EndTime = Tidy(clipDataLines[4]);
						clip.Duration = Tidy(clipDataLines[5]);
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

		private static string Tidy(string oldString)
		{
			string cleanString = oldString;
			oldString.Trim('\t','\n');
			oldString.Trim();
			return cleanString;
		}

		public static string SimplifyClipName(string oldName)
		{
			
			string strCopy = oldName;
			if (strCopy.Contains(".aif"))
			{
				string[] resultArray = SplitStringByString(strCopy, ".aif");
				strCopy = resultArray[0];
			}
			else if (strCopy.Contains(".wav"))
			{
				string[] resultArray = SplitStringByString(strCopy, ".wav");
				strCopy = resultArray[0];
			}
			else if (strCopy.Contains(".mp3"))
			{
				string[] resultArray = SplitStringByString(strCopy, ".mp3");
				strCopy = resultArray[0];
			}
			else if (strCopy.Contains(".mov"))
			{
				string[] resultArray = SplitStringByString(strCopy, ".mov");
				strCopy = resultArray[0];
			}


			return strCopy;
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
		public bool SimplifyFileNames = true;
		public bool ExcludeInactiveTracks = true;
		public bool ExcludeEmptyTracks = true;
		public bool ExcludeFades = true;
		public bool TrackComments = false;
		public bool TrackUserDelay = false;
		public bool TrackState = false;
		public bool TrackPlugIns = false;
		
		public bool PreserveNonEDLData = false;
	}
		
}
