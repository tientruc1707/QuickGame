
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class CoinItem : PoolManager<CoinItem>, iItem
{
    private int CoinValue => StringConstant.VALUE.COIN_VALUE;
    public void OnItemPickup()
    {
        DataManager.Instance.SetCoin(DataManager.Instance.GetCoin() + CoinValue);
        ReturnPoolObject(this);
    }
}


