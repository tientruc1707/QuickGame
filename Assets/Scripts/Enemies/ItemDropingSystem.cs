using System.Collections;
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

public class ItemDropingSystem : MonoBehaviour
{
    [System.Serializable]
    public class DropItemInfor
    {
        public ItemType _itemInfor;
        public GameObject _dropPrefab;
        [HideInInspector] public IObjectPool<GameObject> _pool;
    }
    [SerializeField] private List<DropItemInfor> _dropableList = new List<DropItemInfor>();
    private Dictionary<ItemType, IObjectPool<GameObject>> _dropableDictionary = new Dictionary<ItemType, IObjectPool<GameObject>>();
    
    
    
    private void Awake()
    {
        foreach (var item in _dropableList)
        {
            var pool = new ObjectPool<GameObject>(
                () => Instantiate(item._dropPrefab),
                obj => obj.SetActive(true),
                obj => obj.SetActive(false),
                obj => Destroy(obj),
                true,
                10,
                20
            );
            item._pool = pool;
            _dropableDictionary.Add(item._itemInfor, pool);
        }
    }

    public void DropItem(ItemType itemType, Vector3 position)
    {
        if (!_dropableDictionary.ContainsKey(itemType))
        {
            Debug.LogError($"Item type {itemType} not found in pool.");
            return;
        }
        GameObject item = _dropableDictionary[itemType].Get();
        item.transform.position = position + new Vector3(0, 1, 0);
        item.transform.rotation = Quaternion.identity;
        item.SetActive(true);
    }

    public void ReturnItem(ItemType itemType, GameObject item)
    {
        if (_dropableDictionary.ContainsKey(itemType))
        {
            _dropableDictionary[itemType].Release(item);
        }
        else
        {
            Debug.LogError($"Item type {itemType} not found in pool.");
        }
    }
    
}
