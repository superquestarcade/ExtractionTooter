using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
	public class InputManager : MonoBehaviourSingleton<InputManager>
	{
		public Action<Vector2> OnLook;
		public Action OnMoveStart;
		public Action OnMoveComplete;
		public void Look(InputAction.CallbackContext _callbackContext)
		{
			if (!_callbackContext.performed) return;
			var value = (_callbackContext.ReadValue<Vector2>()).normalized;
			// Debug.Log($"InputManager.Look {value}");
			OnLook?.Invoke(value);
		}

		public void Move(InputAction.CallbackContext _callbackContext)
		{
			Debug.Log($"InputManager.Move {_callbackContext.phase}");
			if (_callbackContext.started) OnMoveStart?.Invoke();
			if (_callbackContext.canceled) OnMoveComplete?.Invoke();
		}
	}
}