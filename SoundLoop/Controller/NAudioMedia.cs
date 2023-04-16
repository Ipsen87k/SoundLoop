﻿using SoundLoop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
namespace SoundLoop.Controller
{
	internal class NAudioMedia:NAudioFunc
	{
		public override void Read(string fname)
		{
			_SoundModel.SoundEvent = new();
			_SoundModel.MFR = new(fname);
			_SoundModel.SoundEvent.Init(_SoundModel.MFR);
		}

		public override void Play()
		{
			Reset(_SoundModel.MFR);
			base.Play();
		}
	}
}
