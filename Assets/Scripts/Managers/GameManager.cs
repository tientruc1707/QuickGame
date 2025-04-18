using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    private void Start()
    {
        EventManager.Instance.StartListening(StringConstant.EVENT.PLAYER_DEAD, OnPlayerDead);
        EventManager.Instance.StartListening(StringConstant.EVENT.ENEMY_DEAD, OnEnemyDead);
        EventManager.Instance.StartListening(StringConstant.EVENT.COIN_COLLECTED, OnCoinCollected);
        EventManager.Instance.StartListening(StringConstant.EVENT.CHECKPOINT_REACHED, OnCheckPointReached);
    }
    private void OnDestroy()
    {
        EventManager.Instance.StopListening(StringConstant.EVENT.PLAYER_DEAD, OnPlayerDead);
        EventManager.Instance.StopListening(StringConstant.EVENT.ENEMY_DEAD, OnEnemyDead);
        EventManager.Instance.StopListening(StringConstant.EVENT.COIN_COLLECTED, OnEnemyDead);
        EventManager.Instance.StopListening(StringConstant.EVENT.CHECKPOINT_REACHED, OnCheckPointReached);
    }
    public void OnPlayerDead()
    {
        UIManager.Instance.GameOver();
    }
    public void OnEnemyDead()
    {
        DataManager.Instance.SetScore(DataManager.Instance.GetScore() + StringConstant.ENEMY_DETAIL.VALUE);
    }
    public void OnCoinCollected()
    {
        DataManager.Instance.SetCoin(DataManager.Instance.GetCoin() + StringConstant.VALUE.COIN_VALUE);
    }
    private void OnCheckPointReached()
    {
        UIManager.Instance.GameWin();
        DataManager.Instance.SaveGameData();
    }
    public void LoadNextLevel()
    {
        UIManager.Instance.LoadNextLevel();
    }
}
