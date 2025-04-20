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
    private void Start()
    {
        UpdateScoreText();
        UpdateCoinText();
        UpdateHealthSlider();
        EventManager.Instance.StartListening(StringConstant.EVENT.PLAYER_DEAD, OnPlayerDead);
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
        Time.timeScale = 0;
        UIManager.Instance.GamePause();
    }
    public void GetCheckPoint()
    {
        EventManager.Instance.TriggerEvent(StringConstant.EVENT.CHECKPOINT_REACHED);
    }
    private void OnPlayerDead()
    {
        UIManager.Instance.GameOver();
    }
    private void OnDestroy()
    {
        EventManager.Instance.StopListening(StringConstant.EVENT.PLAYER_DEAD, OnPlayerDead);
    }
}
