
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    private List<Animator> anims = new();

    public void OnEnable()
    {
        EventManager.Instance.StartListening(StringConstant.EVENT.DEFEAT, OnDefeat);
        EventManager.Instance.StartListening(StringConstant.EVENT.VICTORY, OnVictory);
        EventManager.Instance.StartListening(StringConstant.EVENT.START_LEVEL, StartLevel);
    }

    private void OnDestroy()
    {
        EventManager.Instance.StopListening(StringConstant.EVENT.DEFEAT, OnDefeat);
        EventManager.Instance.StopListening(StringConstant.EVENT.VICTORY, OnVictory);
        EventManager.Instance.StopListening(StringConstant.EVENT.START_LEVEL, StartLevel);
    }

    private void OnDefeat()
    {
        DataManager.Instance.SaveGameData();
    }

    private void OnVictory()
    {
        DataManager.Instance.SaveGameData();
    }

    private void StartLevel()
    {
        if (anims.Count > 0)
            anims.Clear();
        anims = FindObjectsOfType<Animator>().ToList();
    }

    public void FreezeAllObjects(GameObject exception)
    {
        foreach (var anim in anims)
        {
            if (anim.gameObject != exception)
            {
                anim.GetComponent<IMovable>().FreezeObject();
            }
        }
    }

    public void UnfreezeAllObjects()
    {
        foreach (var anim in anims)
        {
            anim.GetComponent<IMovable>().UnFreezeObject();
            Debug.Log("Unfreeze done!");
        }
    }

    public void OnLoadScene(string name)
    {
        EventManager.Instance.TriggerEvent(StringConstant.EVENT.CHANGE_SCENE);
        SceneManager.LoadScene(name);
    }

}
