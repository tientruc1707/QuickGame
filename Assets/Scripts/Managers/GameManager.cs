
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    private List<Animator> anims = new();
    private List<GameObject> characters = new();
    public void OnEnable()
    {
        EventManager.Instance.StartListening(StringConstant.EVENT.DEFEAT, OnDefeat);
        EventManager.Instance.StartListening(StringConstant.EVENT.VICTORY, OnVictory);
    }

    private void OnDestroy()
    {
        EventManager.Instance.StopListening(StringConstant.EVENT.DEFEAT, OnDefeat);
        EventManager.Instance.StopListening(StringConstant.EVENT.VICTORY, OnVictory);
    }

    private void OnDefeat()
    {
        DataManager.Instance.SaveGameData();
    }

    private void OnVictory()
    {
        DataManager.Instance.SaveGameData();
    }

    public void StartLevel()
    {
        if (anims.Count > 0)
            anims.Clear();
        if (characters.Count > 0)
            characters.Clear();
        anims = FindObjectsOfType<Animator>(true).ToList();
        foreach (var anim in anims)
        {
            if (anim.GetComponent<IMovable>() != null && anim.gameObject.activeSelf)
            {
                characters.Add(anim.gameObject);
            }
        }
    }

    public void FreezeAllObjects(GameObject exception)
    {
        foreach (var character in characters)
        {
            if (character != exception)
            {
                character.GetComponent<IMovable>().FreezeObject();
            }
        }
    }

    public void UnfreezeAllObjects()
    {
        foreach (var character in characters)
        {
            character.GetComponent<IMovable>().UnFreezeObject();
        }
    }

    public void OnLoadScene(string name)
    {
        EventManager.Instance.TriggerEvent(StringConstant.EVENT.CHANGE_SCENE);
        SceneManager.LoadScene(name);
    }

}
