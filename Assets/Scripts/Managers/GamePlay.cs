using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
        UIManager.Instance.GamePause();
    }
    public void GetCheckPoint()
    {
        EventManager.Instance.TriggerEvent(StringConstant.EVENT.CHECKPOINT_REACHED);
    }
}
