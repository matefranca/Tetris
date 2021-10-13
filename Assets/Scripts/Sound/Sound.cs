using UnityEngine;

namespace Tetris.Sounds
{
	[System.Serializable]
	public class Sound
	{
		[Header("Name and Clip.")]
		public string name;
		public AudioClip clip;

		[Header("Clip Variables.")]
		[Range(0f, 1f)]
		public float volume = .75f;
		[Range(.1f, 3f)]
		public float pitch = 1f;

		[Header("Loop Options.")]
		public bool loop = false;

		[HideInInspector]
		public AudioSource source;
	}
}