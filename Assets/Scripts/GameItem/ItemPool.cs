
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public enum ItemType
{
    COIN,
    POTION,
    WEAPON,
    ARMOR,
}
public class ItemPool : MonoBehaviour
{
    [System.Serializable]
    public class ItemTypeInfor
    {
        public ItemType _itemType;
        public GameObject _itemPrefab;
        [HideInInspector] public IObjectPool<GameObject> _pool;
        public int _defaultSize;
        public int _maxSize;
    }
    [SerializeField] private List<ItemTypeInfor> _itemTypeList = new List<ItemTypeInfor>();
    // Dictionary to hold the item pools for each item type
    private Dictionary<ItemType, IObjectPool<GameObject>> _itemPools = new Dictionary<ItemType, IObjectPool<GameObject>>();
    private void Awake()
    {
        // Initialize the item pools based on the item type list
        foreach (var itemType in _itemTypeList)
        {
            var pool = new ObjectPool<GameObject>(
                () => CreateItem(itemType._itemPrefab),
                item => GetItemFromPool(item),
                item => ReturnItemToPool(item),
                item => DestroyItem(item),
                true,
                itemType._defaultSize, // Default size
                itemType._maxSize  // Maximum size
            );
            itemType._pool = pool;
            _itemPools.Add(itemType._itemType, pool);
        }
    }
    private GameObject CreateItem(GameObject itemPrefab)
    {
        GameObject item = Instantiate(itemPrefab);
        PooledItem pooledComponent = item.GetComponent<PooledItem>();
        pooledComponent.SetPool(this);
        return item;
    }
    private void GetItemFromPool(GameObject item)
    {
        item.SetActive(true);
    }
    private void ReturnItemToPool(GameObject item)
    {
        item.SetActive(false);
    }
    private void DestroyItem(GameObject item)
    {
        Destroy(item);
    }


    public GameObject GetItem(ItemType itemType)
    {
        if (_itemPools.TryGetValue(itemType, out var pool))
        {
            return pool.Get();
        }
        else
        {
            Debug.LogWarning($"Item pool for {itemType} not found.");
            return null;
        }
    }
    public void ReleaseItem(ItemType itemType, GameObject item)
    {
        if (_itemPools.TryGetValue(itemType, out var pool))
        {
            pool.Release(item);
        }
        else
        {
            Debug.LogWarning($"Item pool for {itemType} not found.");
        }
    }
}
