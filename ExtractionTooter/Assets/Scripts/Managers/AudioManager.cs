using UnityEngine;

namespace Managers
{
	public class AudioManager : MonoBehaviourSingleton<AudioManager>
	{
		[SerializeField] private AudioSource musicSource;
		[SerializeField] private AudioSource sfxSource;

		[SerializeField] private AudioClip backgroundMusicClip;
		[SerializeField] private AudioClip menuMusicClip;
		
		[SerializeField] private AudioClip moveClip;
		[SerializeField] private AudioClip pickupClip;
		[SerializeField] private AudioClip damageClip;
		[SerializeField] private AudioClip startClip;
		[SerializeField] private AudioClip endClip;
		[SerializeField] private AudioClip deadClip;

		public void PlayMenuMusic()
		{
			musicSource.Stop();
			musicSource.clip = menuMusicClip;
			musicSource.Play();
		}

		public void PlayGameMusic()
		{
			musicSource.Stop();
			musicSource.clip = backgroundMusicClip;
			musicSource.Play();
		}

		public void PlayMove()
		{
			sfxSource.PlayOneShot(moveClip);
		}

		public void PlayPickup()
		{
			sfxSource.PlayOneShot(pickupClip);
		}

		public void PlayDamage()
		{
			sfxSource.PlayOneShot(damageClip);
		}

		public void PlayStart()
		{
			sfxSource.PlayOneShot(startClip);
		}

		public void PlayEnd()
		{
			sfxSource.PlayOneShot(endClip);
		}

		public void PlayDead()
		{
			sfxSource.PlayOneShot(deadClip);
		}
	}
}