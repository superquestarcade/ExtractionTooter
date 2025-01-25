using UnityEditor;
using UnityEngine.Device;

namespace UI
{
	public class UiMainMenu : MonoBehaviourPlus
	{
		public void Play()
		{
			GameManager.singleton.StartGame();
		}

		public void Quit()
		{
#if UNITY_EDITOR
			EditorApplication.ExitPlaymode();
#else
			Application.Quit();
#endif
		}
	}
}