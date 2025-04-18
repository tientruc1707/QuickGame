
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    private GameObject gameOverPanel;
    private GameObject gameWinPanel;
    private GameObject gamePausePanel;
    private GameObject gamePlayPanel;

    private void Start()
    {
        gameOverPanel = GameObject.Find(StringConstant.UI.GAME_OVER);
        gameWinPanel = GameObject.Find(StringConstant.UI.GAME_WIN);
        gamePausePanel = GameObject.Find(StringConstant.UI.GAME_PAUSE);
        gamePlayPanel = GameObject.Find(StringConstant.UI.GAME_PLAY);
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        if (gameWinPanel != null)
        {
            gameWinPanel.SetActive(false);
        }
        if (gamePausePanel != null)
        {
            gamePausePanel.SetActive(false);
        }
        if (gamePlayPanel != null)
        {
            gamePlayPanel.SetActive(true);
        }
    }
    public void StartGame()
    {
        gamePlayPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        gameWinPanel.SetActive(false);
        gamePausePanel.SetActive(false);
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        gamePlayPanel.SetActive(false);
        gameWinPanel.SetActive(false);
        gamePausePanel.SetActive(false);
        Time.timeScale = 0;
    }
    public void GameWin()
    {
        gameWinPanel.SetActive(true);
        gamePlayPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gamePausePanel.SetActive(false);
    }
    public void GamePause()
    {
        gamePausePanel.SetActive(true);
        gamePlayPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameWinPanel.SetActive(false);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        gamePausePanel.SetActive(false);
        gamePlayPanel.SetActive(true);
        Time.timeScale = 1;
    }
    public void RestartGame()
    {
        gameOverPanel.SetActive(false);
        gamePlayPanel.SetActive(true);
        Time.timeScale = 1;
        //EventManager.Instance.TriggerEvent(StringConstant.EVENT.RESTART_GAME);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(StringConstant.SCENES.MAIN_MENU);
    }
    public void LoadNextLevel()
    {
        StartGame();
        Time.timeScale = 1;
        SceneManager.LoadScene("Level" + (SceneManager.GetActiveScene().buildIndex + 1));
    }
}
