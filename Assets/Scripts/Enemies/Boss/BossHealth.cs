
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class BossHealth : MonoBehaviour
{
    private int currentLevel;
    public EnemyData enemyData;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Text heathText;
    private float health = 200;


    void Awake()
    {
        currentLevel = DataManager.Instance.GetLevel();
        _healthBar.maxValue = health;
    }

    void Update()
    {
        UpdateHealthBar();
    }

    public void DecreaseHealth(float value)
    {
        health -= value;
    }

    private void UpdateHealthBar()
    {
        _healthBar.value = health;
        heathText.text = $"{_healthBar.value}/{_healthBar.maxValue}";
    }

    public float GetCurrentHealth()
    {
        return health;
    }

    public void Regen()
    {
        health = enemyData.health;
    }
}
