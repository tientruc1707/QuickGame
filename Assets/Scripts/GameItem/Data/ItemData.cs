

using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    public ItemType itemType;
    public Sprite sprite;

    public abstract void OnItemPickedUp();

}
