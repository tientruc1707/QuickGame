using System;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    private Health health;
    private int _healthAmount = 20;
    private void Start()
    {
        health = GetComponent<Health>();
        health.MinHealth = 0;
        health.MaxHealth = StringConstant.PLAYER_DETAIL.HEALTH;
        health.CurrentHealth = health.MaxHealth;

        EventManager.Instance.StartListening("Heal", OnHeal);
    }

    private void OnHeal()
    {
        if (health.CurrentHealth < StringConstant.PLAYER_DETAIL.HEALTH)
        {
            health.Increment(_healthAmount);
        }
        else
        {
            Debug.Log("Health is full");
        }
    }
    private void OnDestroy()
    {
        EventManager.Instance.StopListening("Heal", OnHeal);
    }
    private void Update()
    {
        if (health.CurrentHealth <= 0)
        {
            Dead();
        }
    }
    public int CurrentHealth
    {
        get { return health.CurrentHealth; }
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
}
