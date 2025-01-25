using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ARP
{
    /// <summary>
    ///     This class is a singleton class that lazy-loads itself when called from resources
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
	public class ScreenFadeSystem : MonoBehaviourPlus
	{
		public enum State
		{
			Clear,
			Opaque,
        }

		private static ScreenFadeSystem _instance;
		private static CanvasGroup _myCanvasGroup;
		private static bool isFading; // This is a gross hack and I don't like it -NL

		public static async UniTask FadeAsync(State _type, float _duration, float _waitAfterFade = 0f)
		{
			if (isFading) return;
			Debug.Log($"ScreenFadeSystem.FadeAsync start fade {_type}");
			isFading = true;
			PokeAwake();
			var startTime = Time.time;
			// before yield
			switch (_type)
			{
				case State.Clear:
					_myCanvasGroup.alpha = 1;
					_myCanvasGroup.blocksRaycasts = true;
					break;
				case State.Opaque:
					_myCanvasGroup.alpha = 0;
					_myCanvasGroup.blocksRaycasts = false;
					break;
			}

			// yield while
			while (Time.time < startTime + _duration)
			{
				if (_myCanvasGroup == null)
				{
					Debug.LogWarning("ScreenFadeSystem.FadeAsync missing canvasGroup, exiting early");
					return;
				}

				switch (_type)
				{
					case State.Clear:
						_myCanvasGroup.alpha = Mathf.Lerp(1, 0, Mathf.Clamp01((Time.time - startTime) / _duration));
						break;
					case State.Opaque:
						_myCanvasGroup.alpha = Mathf.Lerp(0, 1, Mathf.Clamp01((Time.time - startTime) / _duration));
						break;
				}

				await UniTask.Yield();
			}

			// after yield
			switch (_type)
			{
				case State.Clear:
					_myCanvasGroup.alpha = 0;
					_myCanvasGroup.blocksRaycasts = false;
					break;
				case State.Opaque:
					_myCanvasGroup.alpha = 1;
					_myCanvasGroup.blocksRaycasts = true;
					break;
			}
			
			
			// Wait after fade
			while (Time.time < startTime + _duration + _waitAfterFade) await UniTask.Yield();
			isFading = false;
			Debug.Log($"ScreenFadeSystem.FadeAsync complete fade {_type}");
		}

		private static void PokeAwake()
		{
			if (_instance == null)
			{
				var go = new GameObject("ScreenFadeSystem");
				DontDestroyOnLoad(go);
				_instance = go.AddComponent<ScreenFadeSystem>();
				var canvas = (GameObject) Instantiate(Resources.Load("CanvasScreenFade"), go.transform);
				_myCanvasGroup = go.GetComponent<CanvasGroup>();
			}
		}

		public static void SetState(State _type)
		{
			if (isFading) return;
			Debug.Log($"ScreenFadeSystem.SetState {_type}");
			switch (_type)
			{
				case State.Clear:
					_myCanvasGroup.alpha = 0;
					_myCanvasGroup.blocksRaycasts = false;
					break;
				case State.Opaque:
					_myCanvasGroup.alpha = 1;
					_myCanvasGroup.blocksRaycasts = true;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(_type), _type, null);
			}
		}
	}
}