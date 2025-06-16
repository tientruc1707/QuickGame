
using UnityEngine;

public class CoinItem : MonoBehaviour, IItem
{
    public CoinData coin;

    public void OnItemPickup()
    {
        DataManager.Instance.SetCoin(DataManager.Instance.GetCoin() + coin.value);
    }

    public void ReturnItemToPool()
    {
        this.gameObject.SetActive(false);
    }
}
