
using System;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T _itemPrefab;
    [SerializeField] private ItemType _itemType;
    [SerializeField][Range(0, 100)] int _itemDropRate;
    private IObjectPool<T> _itemPool;
    private int _defaultSize = 10;
    private int _maxSize = 20;


    private void Awake()
    {
        _itemPool = new ObjectPool<T>(CreateItem, OnGetFromPool, OnReturnToPool, OnDestroyItem, true, _defaultSize, _maxSize);
    }

    private T CreateItem()
    {
        T obj = Instantiate(_itemPrefab);
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

    private void OnDestroyItem(T item)
    {
        Destroy(item);
    }
    // This method is used to get the item from the pool and set its position
    public T GetPoolObject()
    {
        T item = _itemPool.Get();
        item.transform.position = transform.position;
        return item;
    }
    // This method is used to return the item to the pool when it is picked up by the player    
    public void ReturnPoolObject(T item)
    {
        _itemPool.Release(item);
    }
}
