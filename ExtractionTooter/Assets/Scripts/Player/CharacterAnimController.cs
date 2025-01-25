using System;
using UnityEngine;

namespace Player
{
	public class CharacterAnimController : MonoBehaviourPlus
	{
		[SerializeField] private Animator animator;
		[SerializeField] private CharacterController characterController;
		[SerializeField] private string moveHorizontalParamName = "MoveH";
		[SerializeField] private string moveVerticalParamName = "MoveV";
		[SerializeField] private string moveStartParamName = "MoveStart";
		[SerializeField] private string moveCompleteParamName = "MoveComplete";
		[SerializeField] private string speedParamName = "Speed";

		private void Start()
		{
			characterController.OnLook += Look;
			characterController.OnMoveStart += MoveStart;
			characterController.OnMoveComplete += MoveComplete;
			characterController.OnSetSpeed += Speed;
		}
		
		private void OnDestroy()
		{
			characterController.OnLook -= Look;
			characterController.OnMoveStart -= MoveStart;
			characterController.OnMoveComplete -= MoveComplete;
			characterController.OnSetSpeed -= Speed;
		}
		
		private void MoveStart()
		{
			animator.SetTrigger(moveStartParamName);
		}

		private void MoveComplete()
		{
			animator.SetTrigger(moveCompleteParamName);
		}

		private void Look(Vector2 _direction)
		{
			animator.SetFloat(moveHorizontalParamName, _direction.x);
			animator.SetFloat(moveVerticalParamName, _direction.y);
		}

		private void Speed(float _speed)
		{
			animator.SetFloat(speedParamName, _speed);
		}
	}
}