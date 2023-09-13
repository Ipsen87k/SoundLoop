
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace SoundLoop.Controller.NAudio
{
    internal class NAudioSound : NAudioBase
    {
        public override void Read(string fname=null)
        {
            base.Read(fname);

            _stream = new AudioFileReader(this.FileName);
            _event = new WaveOutEvent();
            _event.PlaybackStopped += OnPlaybackStopped;
            Reset();
        }
        public override void Play()
        {
            if (IsStreamNull)
            {
                return;
            }
			if (Paused)
			{
				_event.Play();
			}
            else
            {
				_event.Init(_stream);
				_event.Play();
			}

			
		}

        public NAudioSound(string fname) : base(fname)
        {

        }
	}
}
