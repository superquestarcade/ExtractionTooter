using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
	public class PlayerAnimController : MonoBehaviourPlus
	{
		[SerializeField] private Animator animator;
		[SerializeField] private PlayerController playerController;
		[SerializeField] private PlayerHealth playerHealth;
		[SerializeField] private DamageReciever damageReciever;
		[SerializeField] private string moveHorizontalParamName = "MoveH";
		[SerializeField] private string moveVerticalParamName = "MoveV";
		[SerializeField] private string boostParamName = "Boost";
		[SerializeField] private string deathParamName = "Die";
		[SerializeField] private string speedParamName = "Speed";

		private void Start()
		{
			playerController.OnLook += Look;
			playerController.OnMoveStart += MoveStart;
			playerController.OnMoveComplete += MoveComplete;
			playerController.OnSetSpeed += Speed;
			damageReciever.OnTakeDamage += TakeDamage;
			playerHealth.OnDeath += Die;
		}

		private void OnDestroy()
		{
			playerController.OnLook -= Look;
			playerController.OnMoveStart -= MoveStart;
			playerController.OnMoveComplete -= MoveComplete;
			playerController.OnSetSpeed -= Speed;
			damageReciever.OnTakeDamage -= TakeDamage;
			playerHealth.OnDeath -= Die;
		}
		
		private void MoveStart()
		{
			animator.SetBool(boostParamName, true);
		}

		private void MoveComplete()
		{
			animator.SetBool(boostParamName, false);
		}

		private void Look(Vector2 _direction)
		{
			Debug.Log($"CharacterAnimController.Look {_direction}");
			animator.SetFloat(moveHorizontalParamName, _direction.x);
			animator.SetFloat(moveVerticalParamName, _direction.y);
		}

		private void Speed(float _speed)
		{
			animator.SetFloat(speedParamName, _speed);
		}
		
		private void TakeDamage(float _value, Transform _sourceTransform)
		{
			
		}
		
		private void Die()
		{
			animator.SetTrigger(deathParamName);
		}
	}
}