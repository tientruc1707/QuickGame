using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _coinText;
    private void Start()
    {
        UpdateScoreText();
        UpdateCoinText();
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
    }
    private void UpdateScoreText()
    {
        _scoreText.text = DataManager.Instance.GetScore().ToString();
    }
    private void UpdateCoinText()
    {
        _coinText.text = DataManager.Instance.GetCoin().ToString();
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
}
