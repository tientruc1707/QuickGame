using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Health health;
    void Start()
    {
        health = GetComponent<Health>();
        health.MinHealth = 0;
        health.MaxHealth = StringConstant.ENEMY_DETAIL.HEALTH;
    }
    void Update()
    {

    }
    public void OnDead()
    {
        gameObject.SetActive(false);
        EventManager.Instance.TriggerEvent(StringConstant.EVENT.ENEMY_DEAD);
    }

    public void TakeDamage(int amount)
    {
        health?.Decrement(amount);
        if (health.CurrentHealth <= 0)
        {
            OnDead();
        }
    }
}
