using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundLoop.Controller.NAudio
{
    internal interface IReadable
    {
        void Read(string fname);
    }
}
