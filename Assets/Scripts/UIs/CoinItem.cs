using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinItem : MonoBehaviour, iItem
{
    private EnemyHealth _enemy;
    private Vector3 _currentPosition;
    private void Start()
    {
        this.gameObject.SetActive(false);
        _enemy = GetComponentInParent<EnemyHealth>();
    }
    private void Update()
    {
        _currentPosition = this.transform.position;
        if (!_enemy.isActiveAndEnabled)
        {
            Drop();
        }
    }
    public void Drop()
    {
        this.gameObject.SetActive(true);
        this.transform.position = _currentPosition;
    }
    public void PickUp()
    {
        EventManager.Instance.TriggerEvent(StringConstant.EVENT.COIN_COLLECTED);
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(StringConstant.TAGS.PLAYER))
        {
            PickUp();
            AudioManager.Instance.PlaySoundEffect(StringConstant.SOUND.COIN_PICKUP);
        }
    }
}
