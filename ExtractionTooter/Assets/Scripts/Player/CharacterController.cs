using System;
using UnityEngine;

namespace Player
{
	public class CharacterController : MonoBehaviourPlus
	{
		[SerializeField] private float minMoveSpeed = 2f;
		[SerializeField] private float maxMoveSpeed = 5f;

		public Action<Vector2> OnLook;
		public Action OnMoveStart;
		public Action OnMoveComplete;
		public Action<float> OnSetSpeed;

		public void Look(Vector2 _value)
		{
			OnLook?.Invoke(_value);
		}

		public void MoveStarted()
		{
			OnMoveStart?.Invoke();
		}

		public void MoveComplete()
		{
			OnMoveComplete?.Invoke();
		}
	}
}