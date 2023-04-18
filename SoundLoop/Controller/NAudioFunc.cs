﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using SoundLoop.Models;

namespace SoundLoop.Controller
{
    abstract internal class NAudioFunc:IReadable
    {
        protected SoundModel _SoundModel = SoundModel.Instance;
		protected bool Stooped=>_SoundModel.SoundEvent.PlaybackState== PlaybackState.Stopped;
		protected bool Paused=>_SoundModel.SoundEvent.PlaybackState==PlaybackState.Paused;
		protected bool NullState => _SoundModel.SoundEvent?.PlaybackState == null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Pause()
        {
            _SoundModel.SoundEvent.Pause();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AdjustVolume(float volume)
        {
            _SoundModel.SoundEvent.Volume = volume;
        }
		//LoopとPlayは再帰
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public virtual async void Play()
		{
			_SoundModel.SoundEvent.Play();
			await Task.Run(Loop);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void Loop()
        {
			while (true)
			{
				if (_SoundModel.SoundEvent.PlaybackState == PlaybackState.Stopped)
					break;
				if (_SoundModel.SoundEvent.PlaybackState == PlaybackState.Paused)
					return;
				Debug.WriteLine(_SoundModel.AFR.CurrentTime);
			}
			Play();
		}
		protected void Reset(WaveStream waveStream)
		{
			if (_SoundModel.SoundEvent.PlaybackState == PlaybackState.Stopped)
			{
				waveStream.Position = 0;
			}
		}
		public virtual void Read(string fname) { }

	}
}
