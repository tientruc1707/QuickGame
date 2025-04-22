using UnityEngine;

public enum ItemType
{
    Coin,
    Health,
    Weapon,
    Armor,
    Key
}
public interface iItem
{
    void OnItemPickup();
}