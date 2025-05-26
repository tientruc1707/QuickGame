
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _gameWinPanel;
    [SerializeField] private GameObject _gamePausePanel;
    [SerializeField] private GameObject _gamePlayPanel;
    [SerializeField] private GameObject _canvas;

    private int _currentLevel;
    private void Start()
    {
        _currentLevel = DataManager.Instance.GetLevel();
        InitializePanels();
    }
    private void InitializePanels()
    {
        _gameOverPanel.SetActive(false);
        _gameWinPanel.SetActive(false);
        _gamePausePanel.SetActive(false);
        _gamePlayPanel.SetActive(true);
    }
    public void GameOver()
    {
        AudioManager.Instance.PlaySoundEffect(StringConstant.SOUND.GAME_OVER);
        _gameOverPanel.SetActive(true);
        _gamePlayPanel.SetActive(false);
        _gameWinPanel.SetActive(false);
        _gamePausePanel.SetActive(false);
        Time.timeScale = 0;
    }
    public void GameWin()
    {
        AudioManager.Instance.PlaySoundEffect(StringConstant.SOUND.GAME_WIN);
        _gameWinPanel.SetActive(true);
        _gamePlayPanel.SetActive(false);
        _gameOverPanel.SetActive(false);
        _gamePausePanel.SetActive(false);
    }
    public void GamePause()
    {
        _gamePausePanel.SetActive(true);
        _gamePlayPanel.SetActive(false);
        _gameOverPanel.SetActive(false);
        _gameWinPanel.SetActive(false);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        _gamePausePanel.SetActive(false);
        _gamePlayPanel.SetActive(true);
        Time.timeScale = 1;
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        _gameOverPanel.SetActive(false);
        _gamePlayPanel.SetActive(true);
        _gamePausePanel.SetActive(false);
        _gameWinPanel.SetActive(false);
        SceneManager.LoadScene("Level" + _currentLevel);
        //EventManager.Instance.TriggerEvent(StringConstant.EVENT.RESTART_GAME);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(StringConstant.SCENES.MAIN_MENU);
    }
    public void LoadNextLevel()
    {
        InitializePanels();
        SceneManager.LoadScene("Level" + (_currentLevel + 1));
        DataManager.Instance.SetLevel(_currentLevel + 1);
    }
}
