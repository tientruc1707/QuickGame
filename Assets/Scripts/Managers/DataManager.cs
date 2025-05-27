using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    private const string LevelKey = "Level";
    private const string CoinKey = "Coin";

    override public void Awake()
    {
        if (!PlayerPrefs.HasKey(LevelKey))
        {
            PlayerPrefs.SetInt(LevelKey, 1);
        }
        if (!PlayerPrefs.HasKey(CoinKey))
        {
            PlayerPrefs.SetInt(CoinKey, 0);
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

    public void SaveGameData()
    {
        PlayerPrefs.Save();
    }

}
