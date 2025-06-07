using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private Stack<GameObject> _myPool = new Stack<GameObject>();
    private GameObject baseObject;
    private GameObject tmp;
    private ReturnToPool returnToPool;


    public ObjectPool(GameObject baseObj)
    {
        this.baseObject = baseObj;
    }

    public void CreatePool(int poolSize, GameObject obj)
    {
        for (int i = 0; i < poolSize; i++)
        {
            tmp = Object.Instantiate(baseObject);
            returnToPool = tmp.AddComponent<ReturnToPool>();
            returnToPool.pool = this;
            tmp.SetActive(false);
            tmp.transform.SetParent(obj.transform);
            AddToPool(tmp);
        }
    }

    public GameObject Get()
    {
        tmp = _myPool.Pop();
        tmp.SetActive(true);
        return tmp;
    }

    public void AddToPool(GameObject gameObject)
    {
        _myPool.Push(gameObject);
    }

    public void SetActiveAll()
    {
        foreach (GameObject obj in _myPool)
        {
            if (obj.activeSelf)
            {
                obj.SetActive(false);
            }
        }
    }
}
