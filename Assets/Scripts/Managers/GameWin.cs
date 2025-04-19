using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour
{
    public void RestartGame()
    {
        UIManager.Instance.RestartGame();
    }

    public void MainMenu()
    {
        UIManager.Instance.MainMenu();
    }
    public void NextLevel()
    {
        GameManager.Instance.LoadNextLevel();
    }
}
