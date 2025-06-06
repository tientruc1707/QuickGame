
using UnityEngine;

public class CoinItem : MonoBehaviour, IItem
{
    CoinData coin;

    public void OnItemPickup()
    {
        coin.OnItemPickedUp();
    }

    public void ReturnItemToPool()
    {
        this.gameObject.SetActive(false);
    }
}
