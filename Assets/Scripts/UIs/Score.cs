using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private void Start()
    {
        EventManager.Instance.StartListening(StringConstant.EVENT.ENEMY_DEAD, UpdateScore);
    }
    private void OnDestroy()
    {
        EventManager.Instance.StopListening(StringConstant.EVENT.ENEMY_DEAD, UpdateScore);
    }
    public void UpdateScore()
    {
    }
}
