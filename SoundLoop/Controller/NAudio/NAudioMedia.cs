using SoundLoop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace SoundLoop.Controller.NAudio
{
    internal class NAudioMedia : NAudioBase
    {
        public override void Read(string fname=null)
        {
            base.Read(fname);
			_stream = new MediaFoundationReader(FileName);
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
        public NAudioMedia(string fileName):base(fileName)
        {

        }
    }
}
