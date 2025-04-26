using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _coinText;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private UIManager _uiManager;
    private void Start()
    {
        UpdateScoreText();
        UpdateCoinText();
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
        UpdateScoreText();
        UpdateCoinText();
        UpdateHealthSlider();
    }
    private void UpdateScoreText()
    {
        _scoreText.text = DataManager.Instance.GetScore().ToString();
    }
    private void UpdateCoinText()
    {
        _coinText.text = DataManager.Instance.GetCoin().ToString();
    }
    private void UpdateHealthSlider()
    {
        _healthSlider.value = _playerHealth.CurrentHealth;
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
