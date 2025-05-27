using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _coinText;
    [SerializeField] private Slider _healthSlider, _dashCooldownSlider, _gokakyoCooldownSlider;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private DashJutsu _dashJutsu;
    [SerializeField] private GokakyoNoJutsu _gokakyoNoJutsu;



    private void Start()
    {
        UpdateCoinText();

        _dashCooldownSlider.maxValue = 1f;

        _gokakyoCooldownSlider.maxValue = 1f;

        _healthSlider.maxValue = StringConstant.PLAYER_DETAIL.HEALTH;
        _healthSlider.value = _healthSlider.maxValue;

        EventManager.Instance.StartListening(StringConstant.EVENT.PLAYER_DEAD, OnPlayerDead);
        EventManager.Instance.StartListening(StringConstant.EVENT.CHECKPOINT_REACHED, GetCheckPoint);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                PauseGame();
            }
        }
        UpdateCoinText();
        UpdateHealthSlider();
        UpdateSkillCooldown();
    }


    private void UpdateCoinText()
    {
        _coinText.text = DataManager.Instance.GetCoin().ToString();
    }

    private void UpdateHealthSlider()
    {
        _healthSlider.value = _playerHealth.CurrentHealth();
    }

    private void UpdateSkillCooldown()
    {
        _dashCooldownSlider.value = _dashJutsu.GetCoolDownTime();
        _gokakyoCooldownSlider.value = _gokakyoNoJutsu.GetCoolDownTime();
    }

    public void PauseGame()
    {
        _uiManager.GamePause();
        //UIManager.Instance.GamePause();
    }

    public void GetCheckPoint()
    {
        _uiManager.LoadNextLevel();
        //UIManager.Instance.LoadNextLevel();
    }

    private void OnPlayerDead()
    {
        _uiManager.GameOver();
        //UIManager.Instance.GameOver();
    }

    private void OnDestroy()
    {
        EventManager.Instance.StopListening(StringConstant.EVENT.PLAYER_DEAD, OnPlayerDead);
        EventManager.Instance.StopListening(StringConstant.EVENT.CHECKPOINT_REACHED, GetCheckPoint);
    }
}
