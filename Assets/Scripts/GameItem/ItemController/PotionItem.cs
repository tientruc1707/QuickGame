
using UnityEngine;

public class PotionItem : MonoBehaviour, IItem
{
    public PotionData potion;
    public void OnItemPickup()
    {
        potion.OnItemPickedUp();
    }

    public void ReturnItemToPool()
    {
        this.gameObject.SetActive(false);
    }
}
