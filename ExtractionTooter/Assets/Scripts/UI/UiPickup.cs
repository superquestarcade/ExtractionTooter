using TMPro;
using UnityEngine;

namespace UI
{
	public class UiPickup : MonoBehaviourPlus
	{
		[SerializeField] private int id;
		public int Id => id;
		[SerializeField] private TMP_Text countText;

		public void SetCount(int _value)
		{
			countText.text = _value.ToString();
		}
	}
}