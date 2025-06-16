

using UnityEngine;

public class Item
{

    public ItemType itemType;
    public ItemData itemData;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            case ItemType.HEALTHPOTION: return DataManager.Instance.healthPotionData.sprite;
            case ItemType.COIN: return DataManager.Instance.coinData.sprite;
            default:
                return null;
        }
    }
}
