using UnityEngine;

namespace ARP
{
	public static class UnityExtensions
	{
		/// <summary>
		/// Extension method to check if a layer is in a layermask
		/// </summary>
		/// <param name="_mask"></param>
		/// <param name="_layer"></param>
		/// <returns></returns>
		public static bool Contains(this LayerMask _mask, int _layer)
		{
			return _mask == (_mask | (1 << _layer));
		}
	}
}