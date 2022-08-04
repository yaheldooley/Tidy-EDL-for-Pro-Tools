namespace Tidy_EDL_for_Pro_Tools
{
	public partial class Form1
	{
		public class AudioClipData
		{
			public string ClipName;
			public string StartTime;
			public string EndTime;
			public string Duration;
			public string State;

			private string tab = "     ";
			public string PrintClipData(int bufferCount)
			{
				string s = "";
				s += ClipName;
				int spaces = (bufferCount + 5) - ClipName.Length;
				if (spaces == 0) s += "";
				for (int i = 0; i < spaces; i++)
				{
					s += " ";
				}
				s += StartTime + tab;
				s += EndTime + tab;
				s += Duration + tab;
				s += State + "\n";
				return s;
			}
		}
	}
}
