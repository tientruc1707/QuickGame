
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

    public void OnLoseGame()
    {
        AudioManager.Instance.PlaySoundEffect(StringConstant.SOUND.GAME_OVER);
        _gameOverPanel.SetActive(true);
        _gamePlayPanel.SetActive(false);
        _gameWinPanel.SetActive(false);
        _gamePausePanel.SetActive(false);
        Time.timeScale = 0;
    }

    public void OnWinGame()
    {
        AudioManager.Instance.PlaySoundEffect(StringConstant.SOUND.GAME_WIN);
        _gameWinPanel.SetActive(true);
        _gamePlayPanel.SetActive(false);
        _gameOverPanel.SetActive(false);
        _gamePausePanel.SetActive(false);
    }

    public void PauseGame()
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
        GameManager.Instance.OnLoadScene("Level" + _currentLevel);
        //EventManager.Instance.TriggerEvent(StringConstant.EVENT.RESTART_GAME);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        GameManager.Instance.OnLoadScene(StringConstant.SCENES.MAIN_MENU);
    }

    public void LoadNextLevel()
    {
        DataManager.Instance.SetLevel(_currentLevel + 1);
        GameManager.Instance.OnLoadScene("Level" + (_currentLevel + 1));
    }

}
