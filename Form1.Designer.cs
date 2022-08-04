
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.AllowDrop = true;
			this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 16;
			this.listBox1.Location = new System.Drawing.Point(12, 36);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(361, 116);
			this.listBox1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(410, 214);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(127, 62);
			this.button1.TabIndex = 1;
			this.button1.Text = "TIDY";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// listBox2
			// 
			this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listBox2.FormattingEnabled = true;
			this.listBox2.ItemHeight = 16;
			this.listBox2.Location = new System.Drawing.Point(12, 198);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(361, 116);
			this.listBox2.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(410, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.SeaShell;
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(271, 26);
			this.label2.TabIndex = 4;
			this.label2.Text = "DROP TEXT FILES HERE";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.SeaShell;
			this.label3.Location = new System.Drawing.Point(12, 169);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(255, 26);
			this.label3.TabIndex = 5;
			this.label3.Text = "COULD NOT PROCESS";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.ClientSize = new System.Drawing.Size(549, 331);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBox2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}

