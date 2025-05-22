using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotionItem : PooledItem, IIItem
{
    [SerializeField] private PlayerHealth _playerHealth;
    public void OnItemPickup()
    {
        EventManager.Instance.TriggerEvent("Heal");
    }
    public void ReturnItemToPool()
    {
        ReturnToPool();
    }
}
