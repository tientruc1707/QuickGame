

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

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

    public void FreezeAllObjects(GameObject exception)
    {
        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody rb in allRigidbodies)
        {
            if (rb.gameObject != exception)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
    public void FreezeObject(GameObject gameObject)
    {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void UnfreezeAllObjects()
    {
        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody rb in allRigidbodies)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
    public void UnfreezeObject(GameObject gameObject)
    {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void OnLoadScene(string name)
    {
        EventManager.Instance.TriggerEvent(StringConstant.EVENT.CHANGE_SCENE);
        SceneManager.LoadScene(name);
    }
}
