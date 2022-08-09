
namespace Tidy_EDL_for_Pro_Tools
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.RunButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.DragDropText = new System.Windows.Forms.Label();
			this.check_simplifyNames = new System.Windows.Forms.CheckBox();
			this.check_ExInactive = new System.Windows.Forms.CheckBox();
			this.check_ExEmptyTracks = new System.Windows.Forms.CheckBox();
			this.check_ExFades = new System.Windows.Forms.CheckBox();
			this.checkBox_ExComments = new System.Windows.Forms.CheckBox();
			this.checkBox_ExUserDelay = new System.Windows.Forms.CheckBox();
			this.checkBox_State = new System.Windows.Forms.CheckBox();
			this.checkBox_PllugIns = new System.Windows.Forms.CheckBox();
			this.checkBox_PresNonEDL = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.edlFormatText = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// RunButton
			// 
			this.RunButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.RunButton.BackColor = System.Drawing.Color.Green;
			this.RunButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(255)))), ((int)(((byte)(152)))));
			this.RunButton.FlatAppearance.BorderSize = 3;
			this.RunButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
			this.RunButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.RunButton.Font = new System.Drawing.Font("Ebrima", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RunButton.ForeColor = System.Drawing.Color.Snow;
			this.RunButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.RunButton.Location = new System.Drawing.Point(207, 481);
			this.RunButton.Name = "RunButton";
			this.RunButton.Size = new System.Drawing.Size(144, 53);
			this.RunButton.TabIndex = 1;
			this.RunButton.Text = "EXCLUDE";
			this.RunButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.RunButton.UseVisualStyleBackColor = false;
			this.RunButton.Click += new System.EventHandler(this.ExcludeButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Fliped", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label2.Location = new System.Drawing.Point(286, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(0, 16);
			this.label2.TabIndex = 3;
			// 
			// DragDropText
			// 
			this.DragDropText.AutoSize = true;
			this.DragDropText.Enabled = false;
			this.DragDropText.Font = new System.Drawing.Font("Fliped", 20F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DragDropText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.DragDropText.Location = new System.Drawing.Point(18, 82);
			this.DragDropText.Name = "DragDropText";
			this.DragDropText.Size = new System.Drawing.Size(316, 27);
			this.DragDropText.TabIndex = 4;
			this.DragDropText.Text = "DRAG AND DROP TXT FILES HERE";
			this.DragDropText.Click += new System.EventHandler(this.label3_Click);
			// 
			// check_simplifyNames
			// 
			this.check_simplifyNames.AutoSize = true;
			this.check_simplifyNames.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.check_simplifyNames.ForeColor = System.Drawing.SystemColors.Control;
			this.check_simplifyNames.Location = new System.Drawing.Point(23, 318);
			this.check_simplifyNames.Name = "check_simplifyNames";
			this.check_simplifyNames.Size = new System.Drawing.Size(130, 25);
			this.check_simplifyNames.TabIndex = 5;
			this.check_simplifyNames.Text = "File Extensions";
			this.check_simplifyNames.UseVisualStyleBackColor = true;
			this.check_simplifyNames.CheckedChanged += new System.EventHandler(this.check_simplifyNames_CheckedChanged);
			// 
			// check_ExInactive
			// 
			this.check_ExInactive.AutoSize = true;
			this.check_ExInactive.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.check_ExInactive.ForeColor = System.Drawing.SystemColors.Control;
			this.check_ExInactive.Location = new System.Drawing.Point(23, 342);
			this.check_ExInactive.Name = "check_ExInactive";
			this.check_ExInactive.Size = new System.Drawing.Size(130, 25);
			this.check_ExInactive.TabIndex = 6;
			this.check_ExInactive.Text = "Inactive Tracks";
			this.check_ExInactive.UseVisualStyleBackColor = true;
			this.check_ExInactive.CheckedChanged += new System.EventHandler(this.check_ExInactive_CheckedChanged);
			// 
			// check_ExEmptyTracks
			// 
			this.check_ExEmptyTracks.AutoSize = true;
			this.check_ExEmptyTracks.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.check_ExEmptyTracks.ForeColor = System.Drawing.SystemColors.Control;
			this.check_ExEmptyTracks.Location = new System.Drawing.Point(23, 365);
			this.check_ExEmptyTracks.Name = "check_ExEmptyTracks";
			this.check_ExEmptyTracks.Size = new System.Drawing.Size(121, 25);
			this.check_ExEmptyTracks.TabIndex = 7;
			this.check_ExEmptyTracks.Text = "Empty Tracks";
			this.check_ExEmptyTracks.UseVisualStyleBackColor = true;
			this.check_ExEmptyTracks.CheckedChanged += new System.EventHandler(this.check_ExEmptyTracks_CheckedChanged);
			// 
			// check_ExFades
			// 
			this.check_ExFades.AutoSize = true;
			this.check_ExFades.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.check_ExFades.ForeColor = System.Drawing.SystemColors.Control;
			this.check_ExFades.Location = new System.Drawing.Point(23, 389);
			this.check_ExFades.Name = "check_ExFades";
			this.check_ExFades.Size = new System.Drawing.Size(69, 25);
			this.check_ExFades.TabIndex = 8;
			this.check_ExFades.Text = "Fades";
			this.check_ExFades.UseVisualStyleBackColor = true;
			this.check_ExFades.CheckedChanged += new System.EventHandler(this.check_ExFades_CheckedChanged);
			// 
			// checkBox_ExComments
			// 
			this.checkBox_ExComments.AutoSize = true;
			this.checkBox_ExComments.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBox_ExComments.ForeColor = System.Drawing.SystemColors.Control;
			this.checkBox_ExComments.Location = new System.Drawing.Point(23, 413);
			this.checkBox_ExComments.Name = "checkBox_ExComments";
			this.checkBox_ExComments.Size = new System.Drawing.Size(105, 25);
			this.checkBox_ExComments.TabIndex = 9;
			this.checkBox_ExComments.Text = "Comments";
			this.checkBox_ExComments.UseVisualStyleBackColor = true;
			this.checkBox_ExComments.CheckedChanged += new System.EventHandler(this.checkBox_ExComments_CheckedChanged);
			// 
			// checkBox_ExUserDelay
			// 
			this.checkBox_ExUserDelay.AutoSize = true;
			this.checkBox_ExUserDelay.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBox_ExUserDelay.ForeColor = System.Drawing.SystemColors.Control;
			this.checkBox_ExUserDelay.Location = new System.Drawing.Point(23, 437);
			this.checkBox_ExUserDelay.Name = "checkBox_ExUserDelay";
			this.checkBox_ExUserDelay.Size = new System.Drawing.Size(104, 25);
			this.checkBox_ExUserDelay.TabIndex = 10;
			this.checkBox_ExUserDelay.Text = "User Delay";
			this.checkBox_ExUserDelay.UseVisualStyleBackColor = true;
			this.checkBox_ExUserDelay.CheckedChanged += new System.EventHandler(this.checkBox_ExUserDelay_CheckedChanged);
			// 
			// checkBox_State
			// 
			this.checkBox_State.AutoSize = true;
			this.checkBox_State.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBox_State.ForeColor = System.Drawing.SystemColors.Control;
			this.checkBox_State.Location = new System.Drawing.Point(23, 461);
			this.checkBox_State.Name = "checkBox_State";
			this.checkBox_State.Size = new System.Drawing.Size(105, 25);
			this.checkBox_State.TabIndex = 11;
			this.checkBox_State.Text = "Track State";
			this.checkBox_State.UseVisualStyleBackColor = true;
			this.checkBox_State.CheckedChanged += new System.EventHandler(this.checkBox_State_CheckedChanged);
			// 
			// checkBox_PllugIns
			// 
			this.checkBox_PllugIns.AutoSize = true;
			this.checkBox_PllugIns.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBox_PllugIns.ForeColor = System.Drawing.SystemColors.Control;
			this.checkBox_PllugIns.Location = new System.Drawing.Point(23, 485);
			this.checkBox_PllugIns.Name = "checkBox_PllugIns";
			this.checkBox_PllugIns.Size = new System.Drawing.Size(86, 25);
			this.checkBox_PllugIns.TabIndex = 12;
			this.checkBox_PllugIns.Text = "Plug-Ins";
			this.checkBox_PllugIns.UseVisualStyleBackColor = true;
			this.checkBox_PllugIns.CheckedChanged += new System.EventHandler(this.checkBox_PllugIns_CheckedChanged);
			// 
			// checkBox_PresNonEDL
			// 
			this.checkBox_PresNonEDL.AutoSize = true;
			this.checkBox_PresNonEDL.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBox_PresNonEDL.ForeColor = System.Drawing.SystemColors.Control;
			this.checkBox_PresNonEDL.Location = new System.Drawing.Point(23, 509);
			this.checkBox_PresNonEDL.Name = "checkBox_PresNonEDL";
			this.checkBox_PresNonEDL.Size = new System.Drawing.Size(128, 25);
			this.checkBox_PresNonEDL.TabIndex = 13;
			this.checkBox_PresNonEDL.Text = "Non-EDL Data";
			this.checkBox_PresNonEDL.UseVisualStyleBackColor = true;
			this.checkBox_PresNonEDL.CheckedChanged += new System.EventHandler(this.checkBox_PresNonEDL_CheckedChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.label4.Font = new System.Drawing.Font("Ebrima", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label4.Location = new System.Drawing.Point(19, 200);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(45, 20);
			this.label4.TabIndex = 15;
			this.label4.Text = "PASS";
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.AllowDrop = true;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(23, 286);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 17;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// edlFormatText
			// 
			this.edlFormatText.AutoSize = true;
			this.edlFormatText.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.edlFormatText.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.edlFormatText.Location = new System.Drawing.Point(19, 262);
			this.edlFormatText.Name = "edlFormatText";
			this.edlFormatText.Size = new System.Drawing.Size(103, 21);
			this.edlFormatText.TabIndex = 18;
			this.edlFormatText.Text = "EDL FORMAT";
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(175)))), ((int)(((byte)(158)))));
			this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(255)))), ((int)(((byte)(152)))));
			this.button1.FlatAppearance.BorderSize = 3;
			this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.Snow;
			this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button1.Location = new System.Drawing.Point(262, 191);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(85, 36);
			this.button1.TabIndex = 19;
			this.button1.Text = "CLEAR";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.buttonClear_Click_1);
			// 
			// listView1
			// 
			this.listView1.AllowDrop = true;
			this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(74)))), ((int)(((byte)(59)))));
			this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listView1.ForeColor = System.Drawing.SystemColors.Info;
			this.listView1.FullRowSelect = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(12, 12);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(335, 173);
			this.listView1.TabIndex = 20;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.List;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label1.Font = new System.Drawing.Font("Ebrima", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label1.Location = new System.Drawing.Point(68, 200);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 20);
			this.label1.TabIndex = 21;
			this.label1.Text = "FAIL";
			// 
			// Form1
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(94)))), ((int)(((byte)(79)))));
			this.ClientSize = new System.Drawing.Size(363, 546);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.DragDropText);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.edlFormatText);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.checkBox_PresNonEDL);
			this.Controls.Add(this.checkBox_PllugIns);
			this.Controls.Add(this.checkBox_State);
			this.Controls.Add(this.checkBox_ExUserDelay);
			this.Controls.Add(this.checkBox_ExComments);
			this.Controls.Add(this.check_ExFades);
			this.Controls.Add(this.check_ExEmptyTracks);
			this.Controls.Add(this.check_ExInactive);
			this.Controls.Add(this.check_simplifyNames);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.RunButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Tidy EDL - A worflow tool by Yahel Dooley";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button RunButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label DragDropText;
		private System.Windows.Forms.CheckBox check_simplifyNames;
		private System.Windows.Forms.CheckBox check_ExInactive;
		private System.Windows.Forms.CheckBox check_ExEmptyTracks;
		private System.Windows.Forms.CheckBox check_ExFades;
		private System.Windows.Forms.CheckBox checkBox_ExComments;
		private System.Windows.Forms.CheckBox checkBox_ExUserDelay;
		private System.Windows.Forms.CheckBox checkBox_State;
		private System.Windows.Forms.CheckBox checkBox_PllugIns;
		private System.Windows.Forms.CheckBox checkBox_PresNonEDL;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label edlFormatText;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Label label1;
	}
}

