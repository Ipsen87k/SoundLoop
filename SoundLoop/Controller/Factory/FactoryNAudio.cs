using SoundLoop.Controller.Extensions;
using SoundLoop.Controller.NAudio;
using SoundLoop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SoundLoop.Controller.Factory
{
    internal class FactoryNAudio : IFactory<NAudioBase>
    {
        public static NAudioBase Create(string fname)
        {
            return fname?.GetExtensionWithoutPeriod() switch
            {
                FormatsData.MP4 => new NAudioMedia(fname),
                _ => new NAudioSound(fname)
            };
        }
    }
}
