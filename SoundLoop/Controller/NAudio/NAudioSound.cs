
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
        public override WaveStream Read(string fname=null)
        {
            base.Read(fname);
            //if (NullState || Stooped)
            //{
                //SoundData.WaveStream = new AudioFileReader(fname);
                //SoundData.WaveOutEvent.Init(SoundData.WaveStream);
                //await Play();
            if(fname != null)
            {
                _fileName = fname;
            }
            _stream = new AudioFileReader(this._fileName);
            _event = new WaveOutEvent();
            _event.PlaybackStopped += OnPlaybackStopped;
			//}
			return _stream;
        }
        public override void Play()
        {

            _event.Init(_stream);
            _event.Play();
        }
		private void OnPlaybackStopped(object sender, StoppedEventArgs args)
		{
			_stream.Dispose();
			_stream = null;
			_event.Dispose();
			_event = null;
		}
        public NAudioSound(string fname)
        {
            this._fileName = fname;
        }
	}
}
