
using UnityEngine;

public enum ItemType
{
    HEALTHPOTION,
    MANAPOTION,
    COIN
}


public abstract class ItemData : ScriptableObject
{
    public ItemType itemType;
    public Sprite sprite;

}
