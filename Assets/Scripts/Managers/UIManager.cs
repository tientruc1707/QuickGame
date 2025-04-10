
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    private GameObject gameOverPanel;
    private GameObject gameWinPanel;
    private GameObject gamePausePanel;
    private GameObject gameUIPanel;

    [SerializeField] private Text _score;
    [SerializeField] private Text _coinText;
    [SerializeField] private Slider _playerHealthSlider;
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
        _playerHealthSlider.maxValue = StringConstant.PLAYER_DETAIL.HEALTH;
        _playerHealthSlider.value = StringConstant.PLAYER_DETAIL.HEALTH;
        UpdateCoin(0);
    }
    public void StartGame()
    {
        gameUIPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        gameWinPanel.SetActive(false);
        gamePausePanel.SetActive(false);
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        gameUIPanel.SetActive(false);
        gameWinPanel.SetActive(false);
        gamePausePanel.SetActive(false);
        Time.timeScale = 0;
    }
    public void GameWin()
    {
        gameWinPanel.SetActive(true);
        gameUIPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gamePausePanel.SetActive(false);
    }
    public void GamePause()
    {
        gamePausePanel.SetActive(true);
        gameUIPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameWinPanel.SetActive(false);
        Time.timeScale = 0;
    }
    public void UpdateCoin(int coinValue)
    {
        _coinText.text = coinValue.ToString();
    }
    public void UpdateScore(int scoreValue)
    {
        _score.text = scoreValue.ToString();
    }
    public void UpdatePlayerHealth(int healthValue)
    {
        _playerHealthSlider.value = healthValue;
    }
}
