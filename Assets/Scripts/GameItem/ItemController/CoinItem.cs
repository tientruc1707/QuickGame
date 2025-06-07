
using UnityEngine;

public class CoinItem : MonoBehaviour, IItem
{
    public CoinData coin;

    public void OnItemPickup()
    {
        coin.OnItemPickedUp();
    }

    public void ReturnItemToPool()
    {
        this.gameObject.SetActive(false);
    }
}
