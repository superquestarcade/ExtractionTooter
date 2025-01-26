using UnityEngine;

public class Exit : MonoBehaviourPlus
{
    [SerializeField] private LayerMask playerLayer;

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (!playerLayer.Contains(_other.gameObject.layer)) return;
    }
}
