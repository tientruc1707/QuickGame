
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    POTION,
    COIN
}
public class ItemDropingSystem : MonoBehaviour
{
    [System.Serializable]
    public class ItemDropInfor
    {
        public ItemType itemType;
        [Range(0, 100)]
        public int dropChance;
    }

    [SerializeField] private List<ItemDropInfor> _itemDropList = new List<ItemDropInfor>();
    public void DropItem()
    {
        int randomValue = Random.Range(0, 100);

        foreach (var item in _itemDropList)
        {
            if (randomValue <= item.dropChance)
            {
                GameObject dropItem = PoolManager.Instance.GetFromPool(this.gameObject);
                dropItem.transform.position = transform.position + Vector3.up;
                //if wanna drop only one item, uncomment break
                //break;
            }
        }
    }


}
