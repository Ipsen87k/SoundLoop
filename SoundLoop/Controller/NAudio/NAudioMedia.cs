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
        public override WaveStream Read(string fname)
        {
            base.Read(fname);
            if (NullState || Stooped)
            {
                //using (SoundData.WaveStream = new MediaFoundationReader(fname))
                //{
                //    SoundData.WaveOutEvent.Init(SoundData.WaveStream);
                //    //await Play();
                //}
            }
            return null;
        }
        public override void Play()
        {
            Reset(SoundData.WaveStream);
            //await base.Play();
        }

    }
}
