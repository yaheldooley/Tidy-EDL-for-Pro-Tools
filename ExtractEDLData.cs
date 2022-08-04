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
		public static SessionData GetSessionData(string allTextInFile)
		{
			string[] sections = SplitStringByString(allTextInFile, "T R A C K  L I S T I N G");
			if (sections.Length != 2) return null;

			//remove any tabs in the strings
			char tab = '\u0009';
			string sessionText = sections[0].Replace(tab.ToString(), "");
			string trackListingText = sections[1].Replace(tab.ToString(), "");

			if (sessionText != "")
			{
				string[] sessionDataLines = sessionText.Split('\n');
				if (sessionDataLines.Length < 5) return null;

				SessionData thisSession = new SessionData();
				thisSession.SessionName = RemoveStringBeforeAndWhiteSpaces(sessionDataLines[0], "SESSION NAME:");
				thisSession.SampleRate = RemoveStringBeforeAndWhiteSpaces(sessionDataLines[1], "SAMPLE RATE:");
				float sampleRate = 0;
				float.TryParse(thisSession.SampleRate, out sampleRate);
				int tidySampleRate = (int)sampleRate;
				thisSession.SampleRate = tidySampleRate.ToString() + " Hz";
				thisSession.BitDepth = RemoveStringBeforeAndWhiteSpaces(sessionDataLines[2], "BIT DEPTH:");
				thisSession.SessionStartTimeCode = RemoveStringBeforeAndWhiteSpaces(sessionDataLines[3], "SESSION START TIMECODE:");
				thisSession.SessionFrameRate = RemoveStringBeforeAndWhiteSpaces(sessionDataLines[4], "TIMECODE FORMAT:");
				thisSession.SessionFrameRate = thisSession.SessionFrameRate.Replace(" Frame", "");
				thisSession.AudioTracks = GetTrackListingData(trackListingText);
				return thisSession;
			}
			return null;
		}

		public static List<AudioTrackData> GetTrackListingData(string allTextInFile)
		{
			//Console.WriteLine(allTextInFile);
			//Split each track into string

			string[] rawTrackData = SplitStringByString(allTextInFile, "TRACK NAME:");
			//for (int i = 0; i < rawTrackData.Length; i++) rawTrackData[i] = rawTrackData[i].Trim();
			
			List<AudioTrackData> allTracks = new List<AudioTrackData>();
			//foreach (string s in rawTrackData) Console.WriteLine(s);
			//Console.WriteLine("Track Count = " + rawTrackData.Length);
			for (int i = 1; i < rawTrackData.Length; i++)
			{
				//Console.WriteLine($"=====Array positon {i} start====");
				//Console.WriteLine($"{rawTrackData[i]}");
				//Console.WriteLine($"=====Array positon {i} end====");
			}
			//return allTracks;
			char[] sentenceSplitter = new char[] { '\n' };
			for (int d = 1; d < rawTrackData.Length; d++)
			{
				string s = rawTrackData[d];
				
				string[] stringsWithReturns = s.Split(sentenceSplitter, StringSplitOptions.RemoveEmptyEntries);
				stringsWithReturns = RemoveReturns(stringsWithReturns);

				List<string> validTrackData = new List<string>();


				for (int i = 0; i < stringsWithReturns.Length; i++)
				{
					stringsWithReturns[i] = stringsWithReturns[i].Trim();
					if (stringsWithReturns[i] != string.Empty) validTrackData.Add(stringsWithReturns[i]);
				}

				for (int i = 0; i < validTrackData.Count; i++)
				{
					//Console.WriteLine($"=====Array positon {i} start====");
					//Console.WriteLine($"{validTrackData[i]}");
					//Console.WriteLine($"=====Array positon {i} end====");
				}

				AudioTrackData audioTrack = new AudioTrackData();
				audioTrack.TrackName = Tidy(validTrackData[0]);
				audioTrack.Comments = RemoveStringBeforeAndWhiteSpaces(validTrackData[1], "COMMENTS:");
				audioTrack.UserDelay = RemoveStringBeforeAndWhiteSpaces(validTrackData[2], "USER DELAY:");
				audioTrack.State = RemoveStringBeforeAndWhiteSpaces(validTrackData[3], "STATE:");
				allTracks.Add(audioTrack);
				//skip line 4 its just row description stuff

				//Seperate Clip Info from Track Info
				List<string> validClipData = new List<string>();
				for (int i = 5; i < validTrackData.Count; i++) { validClipData.Add(validTrackData[i]); }

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
					clip.ClipName = Tidy(clipDataLines[2]);
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
					else if(clip.Duration.Contains("Muted"))
					{
						clip.Duration = clip.Duration.Replace("Muted", "");
						clip.State = "Muted";
					}
					
					audioTrack.AudioClips.Add(clip);
				}
				
			}

			return allTracks;
		}

		private static string Tidy(string oldString)
		{
			string cleanString = oldString;
			oldString.Trim('\t','\n');
			oldString.Trim();
			return cleanString;
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
}
