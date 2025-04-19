using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    private void Start()
    {
        EventManager.Instance.StartListening(StringConstant.EVENT.ENEMY_DEAD, UpdateScoreValue);
    }
    private void OnDestroy()
    {
        EventManager.Instance.StopListening(StringConstant.EVENT.ENEMY_DEAD, UpdateScoreValue);
    }
    public void UpdateScoreValue()
    {
        DataManager.Instance.SetScore(DataManager.Instance.GetScore() + StringConstant.ENEMY_DETAIL.VALUE);
    }
}
