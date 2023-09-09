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
        public override void Read(string fname)
        {
            base.Read(fname);
            if (NullState || Stooped)
            {
                using (SoundData.WaveStream = new MediaFoundationReader(fname))
                {
                    SoundData.WaveOutEvent.Init(SoundData.WaveStream);
                    //await Play();
                }
            }
        }
        public override async Task Play()
        {
            Reset(SoundData.WaveStream);
            await base.Play();
        }
    }
}
