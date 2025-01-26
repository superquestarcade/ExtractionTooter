using System.Collections.Generic;

namespace Managers
{
	public class InventoryManager : MonoBehaviourSingleton<InventoryManager>
	{
		private Dictionary<int, int> pickups = new();

		public void AddToInventory(int _pickupId, int _count)
		{
			if (!pickups.TryAdd(_pickupId, _count)) pickups[_pickupId] += _count;
			UiManager.singleton.SetPickupCount(_pickupId,pickups[_pickupId]);
		}

		public void Reset()
		{
			foreach(var pickup in pickups)
				UiManager.singleton.SetPickupCount(pickup.Key,0);
			pickups.Clear();
		}
	}
}