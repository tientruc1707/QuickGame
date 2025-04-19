using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void RestartGame()
    {
        UIManager.Instance.RestartGame();
    }
    public void MainMenu()
    {
        UIManager.Instance.MainMenu();
    }
}
