namespace SoundLoop
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			menuStrip1 = new MenuStrip();
			ファイルToolStripMenuItem = new ToolStripMenuItem();
			openToolStripMenuItem = new ToolStripMenuItem();
			playToolStripMenuItem = new ToolStripMenuItem();
			pauseToolStripMenuItem1 = new ToolStripMenuItem();
			stopToolStripMenuItem = new ToolStripMenuItem();
			変換ToolStripMenuItem = new ToolStripMenuItem();
			mp4Tomp3ToolStripMenuItem = new ToolStripMenuItem();
			mp3ToWavToolStripMenuItem = new ToolStripMenuItem();
			volumeTrackBar = new TrackBar();
			statusStrip1 = new StatusStrip();
			fnameStripStatusLabel = new ToolStripStatusLabel();
			TimeBar = new TrackBar();
			menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)volumeTrackBar).BeginInit();
			statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)TimeBar).BeginInit();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { ファイルToolStripMenuItem, playToolStripMenuItem, pauseToolStripMenuItem1, stopToolStripMenuItem, 変換ToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(800, 24);
			menuStrip1.TabIndex = 0;
			menuStrip1.Text = "menuStrip1";
			// 
			// ファイルToolStripMenuItem
			// 
			ファイルToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem });
			ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
			ファイルToolStripMenuItem.Size = new Size(53, 20);
			ファイルToolStripMenuItem.Text = "ファイル";
			// 
			// openToolStripMenuItem
			// 
			openToolStripMenuItem.Name = "openToolStripMenuItem";
			openToolStripMenuItem.Size = new Size(110, 22);
			openToolStripMenuItem.Text = "開く(O)";
			// 
			// playToolStripMenuItem
			// 
			playToolStripMenuItem.Name = "playToolStripMenuItem";
			playToolStripMenuItem.Size = new Size(43, 20);
			playToolStripMenuItem.Text = "再生";
			// 
			// pauseToolStripMenuItem1
			// 
			pauseToolStripMenuItem1.Name = "pauseToolStripMenuItem1";
			pauseToolStripMenuItem1.Size = new Size(67, 20);
			pauseToolStripMenuItem1.Text = "一時停止";
			// 
			// stopToolStripMenuItem
			// 
			stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			stopToolStripMenuItem.Size = new Size(43, 20);
			stopToolStripMenuItem.Text = "停止";
			// 
			// 変換ToolStripMenuItem
			// 
			変換ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mp4Tomp3ToolStripMenuItem, mp3ToWavToolStripMenuItem });
			変換ToolStripMenuItem.Name = "変換ToolStripMenuItem";
			変換ToolStripMenuItem.Size = new Size(43, 20);
			変換ToolStripMenuItem.Text = "変換";
			// 
			// mp4Tomp3ToolStripMenuItem
			// 
			mp4Tomp3ToolStripMenuItem.Name = "mp4Tomp3ToolStripMenuItem";
			mp4Tomp3ToolStripMenuItem.Size = new Size(132, 22);
			mp4Tomp3ToolStripMenuItem.Text = "mp4→mp3";
			// 
			// mp3ToWavToolStripMenuItem
			// 
			mp3ToWavToolStripMenuItem.Name = "mp3ToWavToolStripMenuItem";
			mp3ToWavToolStripMenuItem.Size = new Size(132, 22);
			mp3ToWavToolStripMenuItem.Text = "mp3→wav";
			// 
			// volumeTrackBar
			// 
			volumeTrackBar.Location = new Point(696, 0);
			volumeTrackBar.Name = "volumeTrackBar";
			volumeTrackBar.Size = new Size(104, 45);
			volumeTrackBar.TabIndex = 2;
			// 
			// statusStrip1
			// 
			statusStrip1.Items.AddRange(new ToolStripItem[] { fnameStripStatusLabel });
			statusStrip1.Location = new Point(0, 428);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new Size(800, 22);
			statusStrip1.TabIndex = 3;
			statusStrip1.Text = "statusStrip1";
			// 
			// fnameStripStatusLabel
			// 
			fnameStripStatusLabel.Name = "fnameStripStatusLabel";
			fnameStripStatusLabel.Size = new Size(38, 17);
			fnameStripStatusLabel.Text = "status";
			// 
			// TimeBar
			// 
			TimeBar.Location = new Point(0, 380);
			TimeBar.Name = "TimeBar";
			TimeBar.Size = new Size(800, 45);
			TimeBar.TabIndex = 4;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(TimeBar);
			Controls.Add(statusStrip1);
			Controls.Add(volumeTrackBar);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Name = "Form1";
			Text = "Form1";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)volumeTrackBar).EndInit();
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)TimeBar).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menuStrip1;
		private ToolStripMenuItem ファイルToolStripMenuItem;
		private ToolStripMenuItem openToolStripMenuItem;
		private ToolStripMenuItem playToolStripMenuItem;
		private ToolStripMenuItem stopToolStripMenuItem;
		private TrackBar volumeTrackBar;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel fnameStripStatusLabel;
		private ToolStripMenuItem 変換ToolStripMenuItem;
		private ToolStripMenuItem mp4Tomp3ToolStripMenuItem;
		private ToolStripMenuItem mp3ToWavToolStripMenuItem;
		private ToolStripMenuItem pauseToolStripMenuItem1;
		private TrackBar TimeBar;
	}
}