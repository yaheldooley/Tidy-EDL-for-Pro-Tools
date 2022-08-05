using System;
using System.Collections.Generic;

namespace Tidy_EDL_for_Pro_Tools
{
	public partial class Form1
	{
		public class SessionData
		{
			public string SessionName;
			public string SampleRate;
			public string BitDepth;
			public string SessionStartTimeCode;
			public string SessionFrameRate;
			public string NonEDLData;

			public List<AudioTrackData> AudioTracks = new List<AudioTrackData>();

			public string PrintSessionInfo()
			{
				string s = "";
				s += $"{SessionName}\n\n";
				s += $"Format: {SampleRate}, {BitDepth}\n";
				s += $"FPS: {SessionFrameRate}\n";
				s += $"Session Start: {SessionStartTimeCode}\n\n";

				s += $"Track Count: {AudioTracks.Count}\n";
				s += $"Unique Cue Count: {GetOriginalCueCount()}\n\n";

				int highestCharCount = 0;
				for (int i = 0; i < AudioTracks.Count; i++)
				{
					if (AudioTracks[i].MaxCharactersInTrackNames > highestCharCount)
					{
						highestCharCount = AudioTracks[i].MaxCharactersInTrackNames;
					}
				}

				string trackListHeader = CreateTrackListColumnHeader(highestCharCount);
				string breakString = "";
				for (int i = 0; i < trackListHeader.Length + 2; i++)
				{
					breakString += "=";
				}
				s += breakString;

				s += $"\n{trackListHeader}\n\n";

				for (int i = 0; i < AudioTracks.Count; i++)
				{
					AudioTrackData track = AudioTracks[i];
					s += track.PrintTrackData(highestCharCount, currentParameters);
				}

				return s;
			}

			private string CreateTrackListColumnHeader(int bufferCount)
			{
				string s = "T R A C K  L I S T";
				s += GetEmptySpaces((bufferCount - s.Length) + 5);

				int timecodeCharLength = 11;

				string start = "START TIME";
				s += start;
				s += GetEmptySpaces((timecodeCharLength - start.Length) + 5);

				string end = "END TIME";
				s += end;
				s += GetEmptySpaces((timecodeCharLength - end.Length) + 5);

				string duration = "DURATION";
				s += duration;
				s += GetEmptySpaces((timecodeCharLength - duration.Length) + 5);
				s += "State";

				return s;
			}

			public int GetOriginalCueCount()
			{
				List<string> originalFileNames = new List<string>();

				foreach(AudioTrackData track in AudioTracks)
				{
					foreach(AudioClipData clip in track.AudioClips)
					{
						if (!originalFileNames.Contains(clip.ClipName)) originalFileNames.Add(clip.ClipName);
					}
				}
				return originalFileNames.Count;
			}

			public string GetEmptySpaces(int count)
			{
				string s = string.Empty;
				for (int i = 0; i < count; i++)
				{
					s += " ";
				}
				return s;
			}
		}
	}
}
