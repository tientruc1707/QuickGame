using System;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    private Health health;
    [SerializeField] private Slider healthSlider;
    public event Action PlayerDeath;
    private void Start()
    {
        health = GetComponent<Health>();
        health.MinHealth = 0;
        health.MaxHealth = StringConstant.PLAYER_DETAIL.HEALTH;
        health.CurrentHealth = health.MaxHealth;
        if (health != null)
        {
            health.HealthChanged += OnHealthChanged;
        }
        Debug.Log("Player Health: " + health.CurrentHealth);
        UpdateView();
    }

    private void OnDestroy()
    {
        if (health != null)
        {
            health.HealthChanged -= OnHealthChanged;
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

    public void UpdateView()
    {
        if (health == null)
            return;

        if (healthSlider != null && health.MaxHealth != 0)
        {
            healthSlider.value = (float)health.CurrentHealth;
        }
    }

    public void OnHealthChanged()
    {
        UpdateView();
    }

    public void Dead()
    {
        PlayerDeath?.Invoke();
    }
}
