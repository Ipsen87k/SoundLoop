﻿
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
namespace SoundLoop.Controller
{
	internal class NAudioSound : NAudioFunc
	{
		public override void Read(string fname)
		{
			_SoundModel.SoundEvent = new();
			_SoundModel.AFR = new(fname);
			_SoundModel.SoundEvent.Init(_SoundModel.AFR);
		}
		public override void Play()
		{
			
			Reset(_SoundModel.AFR);
			base.Play();
		}
	}
}
