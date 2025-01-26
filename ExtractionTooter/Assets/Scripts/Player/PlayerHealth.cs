using System;
using System.Collections;
using Managers;
using Player;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private int startingHealth = 100;
    [SerializeField] private DamageReciever damageReciever;
    
    private float health;

    public Action OnDeath;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = startingHealth;
        UiManager.singleton.SetHealth(health/startingHealth);
        damageReciever.OnTakeDamage += TakeDamage;
    }

    private void TakeDamage(float _value, Transform _sourceTransform)
    {
        playerController.BounceAwayFromDamage(_sourceTransform);
        health = Mathf.Clamp(health - _value, 0, startingHealth);
        UiManager.singleton.SetHealth(health/startingHealth);
        if (health > 0) return;
        playerController.SetControlActive(false);
        OnDeath?.Invoke();
        StartCoroutine(DieAfterDelay());
    }

    private IEnumerator DieAfterDelay()
    {
        yield return new WaitForSeconds(3);
        GameManager.singleton.EndGame();
    }
}
