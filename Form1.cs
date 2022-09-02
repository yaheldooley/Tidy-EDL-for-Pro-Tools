using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Tidy_EDL_for_Pro_Tools
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			LoadAppSettings();
			this.listView1.DragDrop += new DragEventHandler(this.listView1_DragDrop);
			this.listView1.DragEnter += new DragEventHandler(this.listView1_DragEnter);
			Session.SetValidStatus += ShowValidProcess;
		}
		public void LoadAppSettings()
		{
			Session.SetDefaultValues();

			comboBox1.Items.Add(Session.PTParams.EDLFormat.ToString());
			comboBox1.SelectedItem = Session.PTParams.EDLFormat.ToString();
			check_simplifyNames.Checked = Session.PTParams.ExcludeExtensions;
			check_ExInactive.Checked = Session.PTParams.ExcludeEmptyTracks;
			check_ExEmptyTracks.Checked = Session.PTParams.ExcludeEmptyTracks;
			check_ExFades.Checked = Session.PTParams.ExcludeFades;
			checkBox_ExComments.Checked = Session.PTParams.TrackComments;
			checkBox_ExUserDelay.Checked = Session.PTParams.TrackUserDelay;
			checkBox_State.Checked = Session.PTParams.TrackState;
			checkBox_PllugIns.Checked = Session.PTParams.TrackPlugIns;
			checkBox_PresNonEDL.Checked = Session.PTParams.NonEDLData;
		}

		public void ShowValidProcess(ListViewItem item, bool valid)
		{
			if (listView1.Items.Contains(item))
			{
				if (valid)
				{
					item.BackColor = Color.Green;
					item.ForeColor = Color.White;
					//ListViewItem item = new ListViewItem();
					//item.for

					//var t = listBox1.Text;

					//listBox1.Items
					//strikethrough
				}
				else
				{
					item.BackColor = Color.Red;
					item.ForeColor = Color.White;
					//something else
				}
			}
		}

		#region UI Changes

		private void listView1_DragDrop(object sender, DragEventArgs e)
		{
			string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);

			for (int i = 0; i < s.Length; i++)
			{
				string ext = Path.GetExtension(s[i]);
				if (ext == ".txt" && !listView1.Items.ContainsKey(s[i]))
				{
					listView1.Items.Add(s[i]);
				}
			}
			DragDropText.Visible = listView1.Items.Count < 1;
		}

		private void listView1_DragEnter(object sender, DragEventArgs e)
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

		private void ExcludeButton_Click(object sender, EventArgs e)
		{
			if (listView1.Items.Count < 1) return;

			Session.ProcessCollectonsAsEDL(listView1.Items);
			Save();
			//Save settings

		}

		private void Save()
		{
			//Save settings
		}

		

		private void check_simplifyNames_CheckedChanged(object sender, EventArgs e)
		{
			Session.PTParams.ExcludeExtensions = check_simplifyNames.Checked;
		}

		private void check_ExInactive_CheckedChanged(object sender, EventArgs e)
		{
			Session.PTParams.ExcludeInactiveTracks = check_ExInactive.Checked;
		}

		private void check_ExEmptyTracks_CheckedChanged(object sender, EventArgs e)
		{
			Session.PTParams.ExcludeEmptyTracks = check_ExEmptyTracks.Checked;
		}

		private void check_ExFades_CheckedChanged(object sender, EventArgs e)
		{
			Session.PTParams.ExcludeFades = check_ExFades.Checked;
		}

		private void checkBox_ExComments_CheckedChanged(object sender, EventArgs e)
		{
			Session.PTParams.TrackComments = checkBox_ExComments.Checked;
		}

		private void checkBox_ExUserDelay_CheckedChanged(object sender, EventArgs e)
		{
			Session.PTParams.TrackUserDelay = checkBox_ExUserDelay.Checked;
		}

		private void checkBox_State_CheckedChanged(object sender, EventArgs e)
		{
			Session.PTParams.TrackState = checkBox_State.Checked;
		}

		private void checkBox_PllugIns_CheckedChanged(object sender, EventArgs e)
		{
			Session.PTParams.TrackPlugIns = checkBox_PllugIns.Checked;
		}

		private void checkBox_PresNonEDL_CheckedChanged(object sender, EventArgs e)
		{
			Session.PTParams.NonEDLData = checkBox_PresNonEDL.Checked;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Session.SetEDLFormat(comboBox1.Text);
		}

		private void buttonClear_Click_1(object sender, EventArgs e)
		{
			Session.AllRawTextData.Clear();
			listView1.Items.Clear();
			DragDropText.Visible = listView1.Items.Count < 1;
		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		#endregion

		#region Draggable Window
		private bool mouseDown;
		private Point lastLocation;

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			mouseDown = true;
			lastLocation = e.Location;
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			if (mouseDown)
			{
				this.Location = new Point(
					(this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

				this.Update();
			}
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			mouseDown = false;
		}

		#endregion

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
	}
}
