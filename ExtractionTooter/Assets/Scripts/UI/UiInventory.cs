using UnityEngine;

namespace UI
{
	public class UiInventory : MonoBehaviourPlus
	{
		[SerializeField] private UiPickup[] uiPickups;

		public void SetPickupCount(int _id, int _count)
		{
			foreach (var p in uiPickups)
			{
				if (p.Id != _id) continue;
				p.SetCount(_count);
				return;
			}
			Debug.LogError($"UiInventory.SetPickupCount no pickup UI found for {_id}");
		}
	}
}