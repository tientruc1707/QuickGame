
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class BossHealth : MonoBehaviour
{
    private int currentLevel;
    public EnemyData enemyData;
    public float maxHealth;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Text heathText;
    private float currentHealth = 500;


    void Awake()
    {
        currentLevel = DataManager.Instance.GetLevel();
        _healthBar.maxValue = maxHealth;
    }

    void Update()
    {
        UpdateHealthBar();
    }

    public void DecreaseHealth(float value)
    {
        currentHealth -= value;
    }

    private void UpdateHealthBar()
    {
        _healthBar.value = currentHealth;
        heathText.text = $"{_healthBar.value}/{_healthBar.maxValue}";
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void Regen()
    {
        currentHealth = maxHealth;
    }
}
