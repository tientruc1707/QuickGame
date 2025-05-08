
using System;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T _objectPrefab;
    private IObjectPool<T> _objectPool;
    private int _defaultSize = 10;
    private int _maxSize = 20;


    private void Awake()
    {
        _objectPool = new ObjectPool<T>(CreateObject, OnGetFromPool, OnReturnToPool, OnDestroyObject, true, _defaultSize, _maxSize);
    }

    private T CreateObject()
    {
        T obj = Instantiate(_objectPrefab);
        return obj;
    }

    public void OnGetFromPool(T item)
    {
        item.gameObject.SetActive(true);
    }

    public void OnReturnToPool(T item)
    {
        item.gameObject.SetActive(false);
    }

    private void OnDestroyObject(T item)
    {
        Destroy(item);
    }
    // This method is used to get the item from the pool and set its position
    public GameObject GetPoolObject()
    {
        return _objectPool.Get().gameObject;
    }
    // This method is used to return the item to the pool when it is picked up by the player    
    public void ReturnPoolObject(T item)
    {
        _objectPool.Release(item);
    }
}
