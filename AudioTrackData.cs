using System.Collections.Generic;

namespace Tidy_EDL_for_Pro_Tools
{
	public partial class Form1
	{
		public class AudioTrackData
		{
			public string TrackName;
			public string Comments;
			public string UserDelay;
			public string State;
			public string PlugIns;
			public int MaxCharactersInTrackNames = 0;

			public List<AudioClipData> AudioClips = new List<AudioClipData>();

			public string PrintTrackData(int sessionCharBuffer, SessionInfoParams param)
			{
				string s = "";
				s += "TRACK NAME: " + TrackName + "\n\n";
				if (currentParameters.TrackComments) s += "COMMENTS: " + Comments + "\n";
				if (currentParameters.TrackUserDelay) s += "UserDelay: " + UserDelay + "\n";
				if (currentParameters.TrackState) s += "State: " + State + "\n";
				if (currentParameters.TrackPlugIns) s += "PLUG-INS:" + PlugIns + "\n";
				foreach (AudioClipData clip in AudioClips) s += clip.PrintClipData(sessionCharBuffer);
				//s += "--------------------------------------------------------\n";
				s += "\n\n";
				return s;
			}

			public AudioTrackData()
			{
				TrackName = string.Empty;
				Comments = string.Empty;
				UserDelay = string.Empty;
				State = string.Empty;
				PlugIns = string.Empty;
			}
		}
	}
}
