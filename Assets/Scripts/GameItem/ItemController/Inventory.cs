
using System.Collections.Generic;
using UnityEngine;


public class Inventory
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new();
        AddItem(new Item { itemType = ItemType.HEALTHPOTION, amount = 1 });
        AddItem(new Item { itemType = ItemType.COIN, amount = 1 });
        AddItem(new Item { itemType = ItemType.HEALTHPOTION, amount = 1 });
        AddItem(new Item { itemType = ItemType.HEALTHPOTION, amount = 1 });
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
