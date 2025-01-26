using System;
using ARP;
using UnityEngine;

public class MovePlayerArea : MonoBehaviourPlus
{
    [SerializeField] private Vector2 moveDirection = Vector2.right;
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private LayerMask playerLayer;
    
    private Rigidbody2D playerRb;

    private void FixedUpdate()
    {
        if (playerRb == null) return;
        playerRb.AddForce(moveDirection * moveForce);
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (!playerLayer.Contains(_other.gameObject.layer)) return;
        var pRb = _other.gameObject.GetComponent<Rigidbody2D>();
        if(pRb == null) return;
        playerRb = pRb;
    }

    private void OnTriggerExit2D(Collider2D _other)
    {
        if (!playerLayer.Contains(_other.gameObject.layer)) return;
        var pRb = _other.gameObject.GetComponent<Rigidbody2D>();
        if(pRb == null) return;
        playerRb = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(moveDirection * moveForce));
        Gizmos.DrawWireSphere(transform.position + (Vector3) (moveDirection * moveForce), 0.2f);
    }
}
