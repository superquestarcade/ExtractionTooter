using UnityEngine;
using UnityEngine.UI;

public class UiHealth : MonoBehaviourPlus
{
	[SerializeField] private Slider healthSlider;

	public void SetHealthSlider(float _value)
	{
		healthSlider.value = _value;
	}
}
