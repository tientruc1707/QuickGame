using System;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public PlayerData playerData;
    private float health;
    private float currentHealth;

    private void Start()
    {
        health = playerData.health;
        currentHealth = playerData.health;
    }

    public float CurrentHealth()
    {
        return currentHealth;
    }

    public void DeacreaseHealth(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, health);
    }

    public void IncreaseHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, health);
    }

}
