using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;



public class ItemDropingSystem : MonoBehaviour
{
    [System.Serializable]
    public class ItemDropInfor
    {
        public ItemPool pool;
        [Range(0, 100)]
        public int dropChance;
    }
    [SerializeField] private PooledItem pooledItem;
    [SerializeField] private List<ItemDropInfor> _itemDropList = new List<ItemDropInfor>();
    public void DropItem()
    {
        int randomValue = Random.Range(0, 100);

        foreach (ItemDropInfor itemDropInfor in _itemDropList)
        {
            if (randomValue <= itemDropInfor.dropChance)
            {
                // Drop the item from the pool
                GameObject droppedItem = itemDropInfor.pool.GetItem(pooledItem._itemType);
                droppedItem.transform.position = transform.position + Vector3.up;
                break;
            }
        }
    }


}
