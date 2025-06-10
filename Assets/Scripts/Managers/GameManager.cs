
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    private Animator[] anims;
    private List<GameObject> characters = new();
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
        if (anims.Length > 0)
            Array.Clear(anims, 0, anims.Length);
        if (characters.Count > 0)
            characters.Clear();
        anims = FindObjectsOfType<Animator>(true);
        foreach (var anim in anims)
        {
            if (anim.GetComponent<IMovable>() != null)
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
            character.GetComponent<IMovable>().FreezeObject();
        }
    }

    public void OnLoadScene(string name)
    {
        EventManager.Instance.TriggerEvent(StringConstant.EVENT.CHANGE_SCENE);
        SceneManager.LoadScene(name);
    }

}
