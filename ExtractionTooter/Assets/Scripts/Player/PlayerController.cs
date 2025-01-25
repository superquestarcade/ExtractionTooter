using System;
using Managers;
using UnityEngine;

namespace Player
{
	public class PlayerController : MonoBehaviourPlus
	{
		[SerializeField] private Rigidbody2D rb;
		[SerializeField] private float minMoveSpeed = 2f;
		[SerializeField] private float maxMoveSpeed = 5f;
		[SerializeField] private float moveHoldDuration = 3f;

		private bool controlActive = true;
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
			OnSetSpeed?.Invoke(rb.linearVelocity.magnitude);
		}

		private void Move(float _value)
		{
			speed = Mathf.Lerp(minMoveSpeed, maxMoveSpeed, _value);
			rb.AddForce(direction.normalized * speed);
			OnMoveComplete?.Invoke();
		}

		public void SetControlActive(bool _value)
		{
			controlActive = _value;
			if (!_value)
			{
				moveHoldActive = false;
				moveTimer = 0;
				speed = 0;
			}
		}

		public void BounceAwayFromDamage(Transform _sourceTransform)
		{
			var bounceDir = transform.position - _sourceTransform.position;
			rb.linearVelocity = Vector3.zero;
			rb.AddForce(bounceDir.normalized * maxMoveSpeed/2);
		}

		#region Inputs
		private void Look(Vector2 _value)
		{
			if (!controlActive) return;
			direction = _value;
			OnLook?.Invoke(_value);
		}

		private void MoveStarted()
		{
			if (!controlActive) return;
			moveHoldActive = true;
			moveTimer = moveHoldDuration;
			OnMoveStart?.Invoke();
		}

		private void MoveComplete()
		{
			if (!controlActive) return;
			Move(1-Mathf.Clamp01(moveTimer/moveHoldDuration));
			moveHoldActive = false;
			moveTimer = 0;
			OnMoveComplete?.Invoke();
		}
		#endregion
	}
}