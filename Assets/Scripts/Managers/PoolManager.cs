
using System;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T _objectPrefab;
    private IObjectPool<T> _objectPool;
    protected int DefaultSize { get; set; }
    protected int MaxSize { get; set; }


    private void Awake()
    {
        // _objectPool = new ObjectPool<T>(CreateObject, OnGetFromPool, OnReturnToPool, OnDestroyObject, true, DefaultSize, MaxSize);
    }

    public IObjectPool<T> ObjectPool
    {
        get
        {
            _objectPool ??= new ObjectPool<T>(CreateObject, OnGetFromPool, OnReturnToPool, OnDestroyObject, true, DefaultSize, MaxSize);
            return _objectPool;
        }
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
