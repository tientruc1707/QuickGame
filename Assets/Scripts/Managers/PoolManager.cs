
using System.Collections.Generic;
using UnityEngine;


public class PoolManager : Singleton<PoolManager>
{
    private readonly Dictionary<GameObject, ObjectPool> dicPools = new();
    public List<GameObject> objectToPoolList = new();

    public override void Awake()
    {
        foreach (GameObject obj in objectToPoolList)
        {
            dicPools.Add(obj, new ObjectPool(obj));
            dicPools[obj].CreatePool(30);
        }
    }

    public void OnEnable()
    {
        EventManager.Instance.StartListening(StringConstant.EVENT.CHANGE_SCENE, CollectToPools);
    }

    public void OnDisable()
    {
        EventManager.Instance.StopListening(StringConstant.EVENT.CHANGE_SCENE, CollectToPools);
    }

    private void CollectToPools()
    {
        foreach (ObjectPool pool in dicPools.Values)
        {
            pool.SetActiveAll();
        }
    }

    public GameObject GetFromPool(GameObject obj)
    {
        if (!dicPools.ContainsKey(obj))
        {
            Debug.Log("Miss the pool of this object, bro!");
            dicPools.Add(obj, new ObjectPool(obj));
        }
        return dicPools[obj].Get();
    }

}
