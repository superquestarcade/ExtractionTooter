using System;
using Managers;
using UnityEngine;

namespace Audio
{
	public class PlaySceneMusicOnLoad : MonoBehaviourPlus
	{
		[SerializeField] private bool isMenu = false;
		private void Start()
		{
			if(isMenu) AudioManager.singleton.PlayMenuMusic();
			else AudioManager.singleton.PlayGameMusic();
		}
	}
}