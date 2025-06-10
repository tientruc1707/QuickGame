
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class BossHealth : MonoBehaviour
{
    private int currentLevel;

    [SerializeField] private Slider _healthBar;

    public float health;


    void Start()
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
    }

    public float GetCurrentHealth()
    {
        return health;
    }

}
