
using UnityEngine;

[CreateAssetMenu(fileName = "New Coin", menuName = "Items/Coin")]
public class CoinData : ItemData
{
    public int value;

    public override void OnItemPickedUp()
    {
        DataManager.Instance.SetCoin(DataManager.Instance.GetCoin() + value);
    }
}


