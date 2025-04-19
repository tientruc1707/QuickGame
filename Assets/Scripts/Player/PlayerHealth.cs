using System;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    private Health health;
    [SerializeField] private Slider healthBar;
    private void Start()
    {
        health = GetComponent<Health>();
        health.MinHealth = 0;
        health.MaxHealth = StringConstant.PLAYER_DETAIL.HEALTH;
        health.CurrentHealth = health.MaxHealth;
    }
    private void Update()
    {
        UpdateHealthBar();
        if (health.CurrentHealth <= 0)
        {
            Dead();
        }
    }
    public void TakeDamage(int amount)
    {
        health?.Decrement(amount);
    }

    public void Heal(int amount)
    {
        health?.Increment(amount);
    }

    public void Reset()
    {
        health?.Regen();
    }
    public void Dead()
    {
        EventManager.Instance.TriggerEvent(StringConstant.EVENT.PLAYER_DEAD);
    }
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = health.CurrentHealth / health.MaxHealth;
        }
    }
}
