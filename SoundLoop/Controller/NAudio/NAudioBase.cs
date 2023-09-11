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
    abstract internal class NAudioBase : IUserPlaybackable,ISoundModelProvider,IReadable<WaveStream>
    {
        public SoundData SoundData => SoundData.Instance;
        protected WaveStream _stream;
        protected WaveOutEvent _event;
        public string _fileName { get; protected set; }

        protected bool Stooped => SoundData.WaveOutEvent.PlaybackState == PlaybackState.Stopped;
        protected bool Paused => SoundData.WaveOutEvent.PlaybackState == PlaybackState.Paused;
        public bool NullState => _event?.PlaybackState == null;
        public bool IsStreamNull => _stream == null;

        public int GetCurrentSeconds => (int)(_stream.Position / _stream.WaveFormat.AverageBytesPerSecond);
        public int GetTotalTimes => (int)(_stream.Length /  _stream.WaveFormat.AverageBytesPerSecond);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Pause()
        {
            _event.Pause();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AdjustVolume(float volume)
        {
            SoundData.WaveOutEvent.Volume = volume;
        }
        public void WhenSeekChangeTime(int seconds)
        {
            _stream.Position = seconds*_stream.WaveFormat.AverageBytesPerSecond;
        }

        //LoopとPlayは再帰
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual void Play()
        {
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected async Task Loop()
        {
            while (true)
            {
                if (Stooped)
                    break;
                if (Paused)
                    return;
            }
  
        }
        protected void Reset(WaveStream waveStream)
        {
            if (Stooped)
            {
                waveStream.Position = 0;
            }
        }
        public virtual WaveStream Read(string fname)
        {
            if (Paused)
                SoundData.WaveOutEvent.Play();
            return null;
        }

        public async Task Resume()
        {
            if (Paused)
            {
                
            }
        }

		public void Stop()
		{
			if(_stream == null)
                return;
            Pause();
            SoundData.WaveOutEvent.Stop();
		}

	}
}
