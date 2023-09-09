
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
        public override void Read(string fname)
        {
            base.Read(fname);
            if (NullState || Stooped)
            {
                SoundData.WaveStream = new AudioFileReader(fname);
                SoundData.WaveOutEvent.Init(SoundData.WaveStream);
                //await Play();
            }
        }
        public override async Task Play()
        {
            Reset(SoundData.WaveStream);
            await base.Play();
        }
    }
}
