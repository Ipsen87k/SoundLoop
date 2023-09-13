using SoundLoop.Controller;

namespace SoundLoop
{
	public partial class Form1 : Form
	{
		Form1Events _form1Events;
		System.Windows.Forms.Timer timer;
		public Form1()
		{
			InitializeComponent();
            
			Text = "SoundLoop";

			Icon = new Icon(UFileDialog.GetIconPath());
			TimerInit();
			_form1Events = new(fnameStripStatusLabel, volumeTrackBar,TimeBar ,timer,this);

			openToolStripMenuItem.Click += _form1Events.FormOpen_Click;
			playToolStripMenuItem.Click += _form1Events.Form1Play_Click;
			stopToolStripMenuItem.Click += _form1Events.Form1Stop_Click;
			pauseToolStripMenuItem1.Click += _form1Events.Form1Pause_Click;
			volumeTrackBar.ValueChanged += _form1Events.Form1Volume_Change;
			TimeBar.Scroll += _form1Events.TimeBarSlideChanged;
			mp4Tomp3ToolStripMenuItem.Click += _form1Events.MP4ToMP3Convert_Click;
			mp3ToWavToolStripMenuItem.Click += _form1Events.MP3ToWavConvert_Click;
			timer.Tick += _form1Events.TimerTickChangeTimeBarValue;
		}
		
		private void TimerInit()
		{
			this.timer = new();
			this.timer.Enabled = false;
			this.timer.Interval=33;
		}
		private void TrackBarInit()
		{
			volumeTrackBar.TickStyle = TickStyle.None;
			TimeBar.TickStyle=TickStyle.None;
		}
	}
	
}