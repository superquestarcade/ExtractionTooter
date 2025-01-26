using UI;
using UnityEngine;

namespace Managers
{
	public class UiManager : MonoBehaviourSingleton<UiManager>
	{
		[SerializeField] private UiHealth uiHealth;
		[SerializeField] private UiInventory uiInventory;

		public void SetHealth(float _value)
		{
			uiHealth.SetHealthSlider(_value);
		}

		public void SetPickupCount(int _id, int _count)
		{
			uiInventory.SetPickupCount(_id, _count);
		}
	}
}