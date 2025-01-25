using System;
using System.Threading;
using Player;
using UnityEngine;

namespace Camera
{
	public class PlayerCameraZoom : MonoBehaviourPlus
	{
		[SerializeField] private PlayerController characterController;
		[SerializeField] private UnityEngine.Camera playerCamera;
		[SerializeField] private float zoomSpeedFactor = 1f;
		[SerializeField] private float zoomMin = 5f;
		[SerializeField] private float zoomMax = 20f;
		[SerializeField] private float zoomDamping = 0.5f;
		[SerializeField] private float zoomReturnDelay = 5f;
		private float speedTarget;
		private float zoomTarget;
		private float zoomDelayTimer = 0f;
		private float velocity;
		private void Start()
		{
			zoomTarget = zoomMin;
			characterController.OnSetSpeed += SetZoom;
		}

		private void Update()
		{
			UpdateZoomTarget();
			UpdateZoomDelay();
		}

		private void OnDestroy()
		{
			characterController.OnSetSpeed -= SetZoom;
		}

		private void SetZoom(float _speed)
		{
			speedTarget = Mathf.Clamp(zoomMin + (_speed * zoomSpeedFactor), zoomMin, zoomMax);
			if (speedTarget < zoomTarget && zoomDelayTimer > 0) return;
			zoomTarget = speedTarget;
			zoomDelayTimer = zoomReturnDelay;
		}

		private void UpdateZoomTarget()
		{
			if (Mathf.Approximately(playerCamera.orthographicSize, zoomTarget)) return;
			playerCamera.orthographicSize = Mathf.SmoothDamp(playerCamera.orthographicSize, zoomTarget, ref velocity, zoomDamping);
		}
		
		private void UpdateZoomDelay()
		{
			if (zoomDelayTimer <= 0) return;
			zoomDelayTimer -= Time.deltaTime;
		}
	}
}