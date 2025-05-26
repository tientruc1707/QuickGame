

using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    override public void Awake()
    {
        EventManager.Instance.StartListening(StringConstant.EVENT.PLAYER_DEAD, OnPlayerDead);
        EventManager.Instance.StartListening(StringConstant.EVENT.CHECKPOINT_REACHED, OnCheckPointReached);
    }
    private void OnDestroy()
    {
        EventManager.Instance.StopListening(StringConstant.EVENT.PLAYER_DEAD, OnPlayerDead);
        EventManager.Instance.StopListening(StringConstant.EVENT.CHECKPOINT_REACHED, OnCheckPointReached);
    }
    private void OnPlayerDead()
    {
        DataManager.Instance.SaveGameData();
    }
    private void OnCheckPointReached()
    {
        DataManager.Instance.SaveGameData();
    }
    private void OnGameStart()
    {

    }
    public void FreezeAllObjects(GameObject exception)
    {
        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody rb in allRigidbodies)
        {
            if (rb.gameObject != exception)
            {
                rb.isKinematic = true;
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
            rb.isKinematic = false;
        }
    }
    public void UnfreezeObject(GameObject gameObject)
    {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
