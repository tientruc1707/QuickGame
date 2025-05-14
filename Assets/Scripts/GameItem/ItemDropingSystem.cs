
using System.Collections.Generic;
using UnityEngine;

public class ItemDropingSystem : MonoBehaviour
{
    [System.Serializable]
    public class ItemDropInfor
    {
        public ItemType itemType;
        [Range(0, 100)]
        public int dropChance;
    }
    private ItemPool _itemPool;
    private void Start()
    {
        _itemPool = GetComponentInParent<ItemPool>();
        if (_itemPool == null)
        {
            Debug.LogError("ItemPool not found in parent");
        }
    }
    [SerializeField] private List<ItemDropInfor> _itemDropList = new List<ItemDropInfor>();
    public void DropItem()
    {
        int randomValue = Random.Range(0, 100);

        foreach (var item in _itemDropList)
        {
            if (randomValue <= item.dropChance)
            {
                GameObject droppedItem = _itemPool.GetItem(item.itemType);
                droppedItem.transform.position = transform.position + Vector3.up;
                //if wanna drop only one item, uncomment break
                //break;
            }
        }
    }


}
