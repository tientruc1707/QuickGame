using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action HealthChanged;
    private int currentHealth;

    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public int MinHealth { get; set; }
    public int MaxHealth { get; set; }

    public void Increment(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, MinHealth, MaxHealth);
        UpdateHealth();
    }

    public void Decrement(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, MinHealth, MaxHealth);
        UpdateHealth();
    }

    public void Restore()
    {
        currentHealth = MaxHealth;
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        HealthChanged?.Invoke();
    }
}
