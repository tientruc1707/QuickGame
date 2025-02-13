
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private GameObject gameOverPanel;
    private GameObject gameWinPanel;
    private GameObject gamePausePanel;
    private GameObject gameUIPanel;
    private void Start()
    {
        gameOverPanel = GameObject.Find("GameOverPanel");
        gameWinPanel = GameObject.Find("GameWinPanel");
        gamePausePanel = GameObject.Find("GamePausePanel");
        gameUIPanel = GameObject.Find("GameUIPanel");
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
        if (gameUIPanel != null)
        {
            gameUIPanel.SetActive(true);
        }
    }
    public void GameOver()
    {

    }
}
