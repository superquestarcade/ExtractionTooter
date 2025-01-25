using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
	public class CharacterAnimController : MonoBehaviourPlus
	{
		[SerializeField] private Animator animator;
		[SerializeField] private PlayerController playerController;
		[SerializeField] private string moveHorizontalParamName = "MoveH";
		[SerializeField] private string moveVerticalParamName = "MoveV";
		[SerializeField] private string boostParamName = "Boost";
		// [SerializeField] private string moveCompleteParamName = "MoveComplete";
		[SerializeField] private string speedParamName = "Speed";

		private void Start()
		{
			playerController.OnLook += Look;
			playerController.OnMoveStart += MoveStart;
			playerController.OnMoveComplete += MoveComplete;
			playerController.OnSetSpeed += Speed;
		}
		
		private void OnDestroy()
		{
			playerController.OnLook -= Look;
			playerController.OnMoveStart -= MoveStart;
			playerController.OnMoveComplete -= MoveComplete;
			playerController.OnSetSpeed -= Speed;
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
	}
}