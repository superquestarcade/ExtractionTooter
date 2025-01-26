using System;
using ARP;
using Managers;
using UnityEngine;

public class Pickup : MonoBehaviourPlus
{
    [SerializeField] private int id;
    [SerializeField] private int count = 1;
    [SerializeField] private LayerMask playerLayer;

    /*private void OnCollisionEnter2D(Collision2D _other)
    {
        Debug.Log($"{gameObject.name} collision with {_other.gameObject.name}");
        if (!playerLayer.Contains(_other.gameObject.layer)) return;
        InventoryManager.singleton.AddToInventory(id, count);
        Destroy(this.gameObject);
    }*/

    private void OnTriggerEnter2D(Collider2D _other)
    {
        Debug.Log($"{gameObject.name} collision with {_other.gameObject.name}");
        if (!playerLayer.Contains(_other.gameObject.layer)) return;
        InventoryManager.singleton.AddToInventory(id, count);
        Destroy(this.gameObject);
    }
}
