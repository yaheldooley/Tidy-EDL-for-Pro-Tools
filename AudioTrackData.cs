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
			public int MaxCharactersInTrackNames = 0;

			public List<AudioClipData> AudioClips = new List<AudioClipData>();

			public string PrintTrackData(int sessionCharBuffer)
			{
				string s = "";
				s += "TRACK NAME: " + TrackName + "\n\n";
				//s += "COMMENTS: " + Comments + "\n";
				//s += "UserDelay: " + UserDelay + "\n";
				//s += "State: " + State + "\n";

				foreach (AudioClipData clip in AudioClips) s += clip.PrintClipData(sessionCharBuffer);
				//s += "--------------------------------------------------------\n";
				s += "\n\n";
				return s;
			}
		}
	}
}
