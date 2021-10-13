using System;
using UnityEngine;
using Tetris.Sounds;

namespace Tetris.Managers
{
	public class AudioManager : Singleton<AudioManager>
	{
		public Sound[] sounds;

		protected override void OnInitialize()
		{
			base.OnInitialize();
			foreach (Sound _s in sounds)
			{
				_s.source = gameObject.AddComponent<AudioSource>();
				_s.source.clip = _s.clip;
				_s.source.loop = _s.loop;
			}
		}

		public void Play(string sound)
		{
			Sound s = Array.Find(sounds, item => item.name == sound);
			if (s == null)
			{
				Debug.LogWarning("Sound: " + name + " not found!");
				return;
			}

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;

			s.source.Play();
		}

		public bool IsPlaying(string sound)
		{
			Sound s = Array.Find(sounds, item => item.name == sound);
			if (s == null)
			{
				Debug.LogWarning("Sound: " + name + " not found!");
				return false;
			}

			return s.source.isPlaying;
		}
	}
}