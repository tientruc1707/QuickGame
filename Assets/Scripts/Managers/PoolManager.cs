
using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    private Dictionary<GameObject, ObjectPool> _dicPools = new Dictionary<GameObject, ObjectPool>();

    public GameObject GetFromPool(GameObject obj)
    {
        if (!_dicPools.ContainsKey(obj))
        {
            _dicPools.Add(obj, new ObjectPool(obj));
        }
        return _dicPools[obj].Get();
    }
}
