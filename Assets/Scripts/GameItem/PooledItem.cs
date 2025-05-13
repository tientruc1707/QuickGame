using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledItem : MonoBehaviour
{
    public ItemType _itemType;
    private ItemPool _itemPool;

    public void SetPool(ItemPool itemPool)
    {
        _itemPool = itemPool;
    }

    public void ReturnToPool()
    {
        if (_itemPool != null)
        {
            _itemPool.ReleaseItem(_itemType, gameObject);
        }
        else
        {
            Debug.LogWarning("Item pool is not set. Cannot return item to pool.");
        }
    }
}
