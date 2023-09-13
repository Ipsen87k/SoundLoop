using SoundLoop.Controller.Factory;
using SoundLoop.Controller.NAudio;
using SoundLoop.Controller.NRecoNAudioConvert;
using SoundLoop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLoop.Controller
{
    internal class Form1Events:ISoundModelProvider
    {
        NAudioBase _NAudio;
        private bool IsNAudioNull=> _NAudio == null;
        private event EventHandler<EventArgs> OnStopped;
        public SoundData SoundData => SoundData.Instance;
        public System.Windows.Forms.Timer Timer { get; init; }
        public ToolStripStatusLabel Status {  get; init; }
        public TrackBar VolumeBar { get; init; }
        public TrackBar TimeBar { get; init; }
        public Form Form {  get; init; }
        public Form1Events(ToolStripStatusLabel status,TrackBar trackBar,TrackBar timeBar, System.Windows.Forms.Timer timer,Form form)
        {
            Status = status;
            VolumeBar = trackBar;
            TimeBar = timeBar;
            this.Timer = timer; 
            Form = form;

            OnStopped += Form1Stop_Click;
        }
        public void FormOpen_Click(object sender, EventArgs e)
        {
            var fileName =UFileDialog.FileOpen();
            if (string.IsNullOrEmpty(fileName))
                return;
            if(!IsNAudioNull)
            {
                //再生中にファイルを開いた時の対象
                OnStopped?.Invoke(this,EventArgs.Empty);
            }
            _NAudio=FactoryNAudio.Create(fileName);
            
            Status.Text = Path.GetFileName(fileName);

            _NAudio.Read(fileName);
			Init();
            VolumeBarInit();
			_NAudio.Play();

        }
        public void Form1Play_Click(object sender, EventArgs e)
        {
            if (IsNAudioNull)
            {
                return;
            }
			_NAudio.Play();
		}
        public void Form1Pause_Click(object sender, EventArgs e)
        {
			if (IsNAudioNull)
			{
				return;
			}
			_NAudio.Pause();
        }
        public void Form1Volume_Change(object sender, EventArgs e)
        {
			if (IsNAudioNull)
			{
				return;
			}
			var adjustVolumeNum = 100f;
			_NAudio.AdjustVolume(VolumeBar.Value / adjustVolumeNum);
		}
        public void Form1Stop_Click(object sender, EventArgs e)
        {
			if (IsNAudioNull)
			{
				return;
			}
			Timer.Enabled = false;
			_NAudio.Stop();
            _NAudio = null;
        }
        public void MP4ToMP3Convert_Click(object sender, EventArgs e)
        {
			SoundData.Fname=UFileDialog.InvokeFileOpen(SoundData.Fname);
            IConverter converter = FactoryConvert.Create(SoundData.Fname);
            converter.Convert();
        }
        public void MP3ToWavConvert_Click(object sender, EventArgs e)
        {
			SoundData.Fname=UFileDialog.InvokeFileOpen(SoundData.Fname);
            IConverter converter = FactoryConvert.Create(SoundData.Fname);
            converter.Convert();
        }
        private void Init()
        {
			//if (SoundData.WaveOutEvent is null)
			//	return;
            TimeBar.Minimum = 0;
            TimeBar.Maximum = _NAudio.GetTotalTimes;
            Timer.Enabled = true;

#if DEBUG
            Debug.WriteLineIf(false,$"動画時間 = {TimeBar.Maximum}");
#endif

        }
        private void VolumeBarInit()
        {
            VolumeBar.Minimum = 0;
            VolumeBar.Value = (int)_NAudio.GetVolume;
#if DEBUG
            Debug.WriteLineIf(true,$"音のサイズ = {_NAudio.GetVolume} VolumeBarの値 = {VolumeBar.Value}");
#endif
        }
        public void TimeBarSlideChanged(object sender, EventArgs e)
        {
			if (IsNAudioNull)
			{
				return;
			}
			var currentTimeValue = TimeBar.Value;
#if DEBUG
			Debug.WriteLineIf(false,$"timebar = {currentTimeValue}");
			Debug.WriteLineIf(false,$"現在の動画時間 = {SoundData.WaveStream.Position}");
#endif
            Timer.Enabled = false;
            _NAudio.WhenSeekChangeTime(currentTimeValue);
            Timer.Enabled = true;
        }

        public void TimerTickChangeTimeBarValue(object sender, EventArgs e)
		{
			if (_NAudio.IsStreamNull)
            {
                _NAudio.Stop();
                _NAudio = FactoryNAudio.Create(_NAudio.FileName);
                _NAudio.Read();
                _NAudio.Play();
            }
			var currentTime = _NAudio.GetCurrentSeconds;
			TimeBar.Value= currentTime;
#if DEBUG
            Debug.WriteLineIf(false, $"現在の位置(current.second) = {SoundData.WaveStream.CurrentTime.Seconds}  TrackBarの最大値 = {TimeBar.Maximum}");
            Debug.WriteLineIf(false,$"現在の位置 = {SoundData.WaveStream.Position/SoundData.WaveStream.WaveFormat.AverageBytesPerSecond}");
#endif
        }

	}
}
