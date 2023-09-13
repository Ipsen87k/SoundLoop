using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using SoundLoop.Models;

namespace SoundLoop.Controller.NAudio
{
    abstract internal class NAudioBase : IUserPlaybackable,ISoundModelProvider
    {
        public SoundData SoundData => SoundData.Instance;
        protected WaveStream _stream;
        protected WaveOutEvent _event;
        public string FileName { get; protected set; }

        protected bool Stooped => _event.PlaybackState == PlaybackState.Stopped;
        protected bool Paused => _event.PlaybackState == PlaybackState.Paused;
        public bool NullState => _event?.PlaybackState == null;
        public bool IsStreamNull => _stream == null;

        public int GetCurrentSeconds => (int)(_stream.Position / _stream.WaveFormat.AverageBytesPerSecond);
        public int GetTotalTimes => (int)(_stream.Length /  _stream.WaveFormat.AverageBytesPerSecond);
        public float GetVolume => _event.Volume*100f;
        public NAudioBase(string filename)
        {
            FileName = filename;
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Pause()
        {
            if(IsStreamNull)
            {
                return;
            }
            _event.Pause();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AdjustVolume(float volume)
        {
			if (IsStreamNull)
			{
				return;
			}
			_event.Volume = volume;
        }
        public void WhenSeekChangeTime(int seconds)
        {
			if (IsStreamNull)
			{
				return;
			}
			_event.Pause();
            _stream.Position = seconds*_stream.WaveFormat.AverageBytesPerSecond;
            _event.Play();
        }
        [method:MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void Reset()
        {
            _stream.Position = 0;
        }
		protected void OnPlaybackStopped(object sender, StoppedEventArgs args)
		{
			_stream.Dispose();
			_stream = null;
			_event.Dispose();
			_event = null;
		}
		public virtual void Read(string fname=null)
		{
			if (fname != null)
			{
				FileName = fname;
			}
		}

        public void Resume()
        {
            if (Paused)
            {
                _event.Play();
            }
        }

		public void Stop()
		{
			if(IsStreamNull)
                return;
            Pause();
            _event.Stop();
		}

		public virtual void Play()
		{
		}
	}
}
