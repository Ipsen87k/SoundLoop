﻿using SoundLoop.Controller.Extensions;
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
    internal class FactoryNAudio : IFactory<IUserPlaybackable>
    {
        public static IUserPlaybackable Create(string fname)
        {
            return fname?.GetExtensionWithoutPeriod() switch
            {
                FormatsData.MP4 => new NAudioMedia(),
                _ => new NAudioSound()
            };
        }
    }
}
