using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    private const string LevelKey = "Level";
    private const string CoinKey = "Coin";
    private const string ScoreKey = "Score";
    private const string BestScoreKey = "BestScore";

    private void Start()
    {
        if (!PlayerPrefs.HasKey(LevelKey))
        {
            PlayerPrefs.SetInt(LevelKey, 1);
        }
        if (!PlayerPrefs.HasKey(CoinKey))
        {
            PlayerPrefs.SetInt(CoinKey, 0);
        }
        if (!PlayerPrefs.HasKey(ScoreKey))
        {
            PlayerPrefs.SetInt(ScoreKey, 0);
        }
        if (!PlayerPrefs.HasKey(BestScoreKey))
        {
            PlayerPrefs.SetInt(BestScoreKey, 0);
        }
    }
    public int GetLevel()
    {
        return PlayerPrefs.GetInt(LevelKey);
    }
    public int GetCoin()
    {
        return PlayerPrefs.GetInt(CoinKey);
    }
    public int GetScore()
    {
        return PlayerPrefs.GetInt(ScoreKey);
    }
    public int GetBestScore()
    {
        return PlayerPrefs.GetInt(BestScoreKey);
    }
    public void SetLevel(int level)
    {
        PlayerPrefs.SetInt(LevelKey, level);
        PlayerPrefs.Save();
    }
    public void SetCoin(int coin)
    {
        PlayerPrefs.SetInt(CoinKey, coin);
        PlayerPrefs.Save();
    }
    public void SetScore(int score)
    {
        PlayerPrefs.SetInt(ScoreKey, score);
        PlayerPrefs.Save();
    }
    public void SetBestScore(int bestScore)
    {
        PlayerPrefs.SetInt(BestScoreKey, bestScore);
        PlayerPrefs.Save();
    }
    public void ResetData()
    {
        //PlayerPrefs.SetInt(LevelKey, 1);
        PlayerPrefs.SetInt(CoinKey, 0);
        PlayerPrefs.SetInt(ScoreKey, 0);
        PlayerPrefs.SetInt(BestScoreKey, 0);
    }
}
