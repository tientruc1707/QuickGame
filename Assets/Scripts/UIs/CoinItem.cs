using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour, iItem
{
    private void Start()
    {
        EventManager.Instance.StartListening(StringConstant.EVENT.ENEMY_DEAD, Drop);
        this.gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        EventManager.Instance.StopListening(StringConstant.EVENT.ENEMY_DEAD, Drop);
    }
    public void Drop()
    {
        this.gameObject.SetActive(true);
        this.transform.position = new Vector3(UnityEngine.Random.Range(-10, 10), 0.5f, UnityEngine.Random.Range(-10, 10));
    }
    public void PickUp()
    {
        EventManager.Instance.TriggerEvent(StringConstant.EVENT.COIN_COLLECTED);
        this.gameObject.SetActive(false);
    }
}
