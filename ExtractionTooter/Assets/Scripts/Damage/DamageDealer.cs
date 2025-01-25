using System;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float damage = 10f;

    private void OnCollisionEnter2D(Collision2D _other)
    {
        var damageReciever = _other.gameObject.GetComponent<DamageReciever>();
        if (damageReciever == null) return;
        damageReciever.TakeDamage(damage, transform);
    }
}
