using System;
using Managers;
using UnityEngine;

namespace Player
{
	public class CharacterController : MonoBehaviourPlus
	{
		[SerializeField] private float minMoveSpeed = 2f;
		[SerializeField] private float maxMoveSpeed = 5f;
		[SerializeField] private float moveHoldDuration = 3f;

		private bool moveHoldActive;
		private float moveTimer;

		private Vector2 direction;
		private float speed;
		private Vector2 velocity;

		public Action<Vector2> OnLook;
		public Action OnMoveStart;
		public Action OnMoveComplete;
		public Action<float> OnSetSpeed;
		
		#region Unity Functions

		private void Start()
		{
			InputManager.singleton.OnLook += Look;
			InputManager.singleton.OnMoveStart += MoveStarted;
			InputManager.singleton.OnMoveComplete += MoveComplete;
		}

		private void Update()
		{
			UpdateMoveHoldTimer();
			UpdateMovement();
		}

		private void OnDestroy()
		{
			InputManager.singleton.OnLook -= Look;
			InputManager.singleton.OnMoveStart -= MoveStarted;
			InputManager.singleton.OnMoveComplete -= MoveComplete;
		}
		
		#endregion
		
		private void UpdateMoveHoldTimer()
		{
			if (!moveHoldActive || moveTimer<=0) return;
			moveTimer -= Time.deltaTime;
		}
		
		private void UpdateMovement()
		{
			if (velocity.magnitude <= 0.001)
			{
				velocity = Vector2.zero;
				return;
			}
			velocity += -velocity * 0.01f;
			transform.position += (Vector3) velocity * Time.deltaTime;
			OnSetSpeed?.Invoke(velocity.magnitude);
		}

		private void Move(float _value)
		{
			speed = Mathf.Lerp(minMoveSpeed, maxMoveSpeed, _value);
			velocity = direction.normalized * speed;
			OnMoveComplete?.Invoke();
		}

		#region Inputs
		private void Look(Vector2 _value)
		{
			direction = _value;
			OnLook?.Invoke(_value);
		}

		private void MoveStarted()
		{
			moveHoldActive = true;
			moveTimer = moveHoldDuration;
			OnMoveStart?.Invoke();
		}

		private void MoveComplete()
		{
			Move(1-Mathf.Clamp01(moveTimer/moveHoldDuration));
			moveHoldActive = false;
			moveTimer = 0;
			OnMoveComplete?.Invoke();
		}
		#endregion
	}
}